using Restaurant_4.Abstract;

namespace Restaurant_4.Classes.Drinks
{
    public class Coffee : MenuItem
    {
        public override void Obtain()
        {
            // Simulate obtaining coffee from storage
        }

        public override void Serve()
        {
            // Simulate serving coffee to the customer
        }

        public override string ToString()
        {
            return "Coffee";
        }
    }
}
