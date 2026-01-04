using Restaurant_4.Abstract;

namespace Restaurant_4.Classes.Drinks
{
    public class Water : MenuItem
    {
        public override void Obtain()
        {
            // Simulate obtaining water from storage
        }

        public override void Serve()
        {
            // Simulate serving water to the customer
        }

        public override string ToString()
        {
            return "Water";
        }
    }
}
