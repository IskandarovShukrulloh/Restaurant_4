using Restaurant_4.Abstract;

namespace Restaurant_4.Classes.Drinks
{
    public class Tea : MenuItem
    {
        public override void Obtain()
        {
            // Simulate obtaining tea from storage
        }

        public override void Serve()
        {
            // Simulate serving tea to the customer
        }

        public override string ToString()
        {
            return "Tea";
        }
    }
}
