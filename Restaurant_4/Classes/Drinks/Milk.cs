using Restaurant_4.Abstract;

namespace Restaurant_4.Classes.Drinks
{
    public class Milk : MenuItem
    {
        public override void Obtain()
        {
            // Simulate obtaining milk from fridge
        }

        public override void Serve()
        {
            // Simulate serving milk to the customer
        }

        public override string ToString()
        {
            return "Milk";
        }
    }
}
