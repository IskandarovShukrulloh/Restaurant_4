using Restaurant_4.Classes;
using System;

namespace Restaurant_4.Logic
{
    public class Cook
    {
        private int eggQuality = -1;
        public int EggQuality => eggQuality;

        // Event: raised when all food is prepared
        public event Action? OrdersProcessed;

        //  Subscriber for Server event
        public void OnTableRequestsReady(TableRequest requests)
        {
            Process(requests);
            OrdersProcessed?.Invoke();
        }

        //  Cooking logic 
        private void Process(TableRequest requests)
        {
            // --- Cook chickens ---
            foreach (var chicken in requests.Get<Chicken>())
            {
                chicken.Obtain();
                chicken.CutUp();
                chicken.Cook();
            }

            // --- Cook eggs ---
            var eggs = requests.Get<Egg>();

            if (eggs.Count > 0)
            {
                // Quality is determined ONCE for the table
                eggQuality = eggs[0].Quality;

                foreach (var egg in eggs)
                {
                    using (egg)
                    {
                        egg.Obtain();
                        egg.Cook(); // Egg handles cracking internally
                    }
                }
            }
        }
    }
}
