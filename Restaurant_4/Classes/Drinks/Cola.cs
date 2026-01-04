using Restaurant_4.Abstract;

namespace Restaurant_4.Classes.Drinks
{
    public class Cola : MenuItem
    {
        public override void Obtain()
        {
            // Simulate obtaining cola from fridge
        }

        public override void Serve()
        {
            // Simulate serving cola to the customer
        }

        public override string ToString()
        {
            return "Cola";
        }
    }
}
