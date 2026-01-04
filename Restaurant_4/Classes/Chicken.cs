using Restaurant_4.Abstract;

namespace Restaurant_4.Classes
{
    public class Chicken : CookedFood
    {
        public override void Obtain()
        {
            // Simulate obtaining raw chicken from storage
        }

        public void CutUp()
        {
            // Simulate cutting up the chicken
        }

        public override void Cook()
        {
            // Simulate cooking the chicken
        }

        public override void Serve()
        {
            // Simulate serving the chicken to the customer
        }

        public override string ToString()
        {
            return "Chicken";
        }
    }
}
