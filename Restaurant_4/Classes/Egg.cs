using Restaurant_4.Abstract;
using System;

namespace Restaurant_4.Classes
{
    public class Egg : CookedFood, IDisposable
    {
        private static Random rand = new();
        private bool isCracked = false;
        private bool shellsDiscarded = false;
        private bool disposed = false;

        public int Quality { get; private set; }

        public Egg()
        {
            Quality = rand.Next(1, 101); // quality assigned once
        }

        public void Crack()
        {
            isCracked = true;
        }

        public override void Cook()
        {
            if (!isCracked) isCracked = true; // auto-crack if forgot
            // simulate cooking
        }

        public override void Serve()
        {
            // optional check
        }

        public void DiscardShells()
        {
            shellsDiscarded = true;
        }

        public override void Obtain()
        {
            // simulate obtain
        }

        public void Dispose()
        {
            if (!disposed)
            {
                DiscardShells(); // always discard shells
                disposed = true;
            }
        }

        public override string ToString()
        {
            return $"Egg (Q: {Quality})";
        }
    }
}
