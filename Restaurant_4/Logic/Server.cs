using Restaurant_4.Abstract;
using Restaurant_4.Classes;
using Restaurant_4.Classes.Drinks;
using Restaurant_4.Interfaces;
using Restaurant_4.Logic;


namespace Restaurant_4
{
    public class Server
    {
        private readonly TableRequest tableRequests = new();
        private readonly List<string> customersInOrder = new(); // порядок прихода (пока так)
        private int  _customerCount = 0;
        private bool cooked = false;

        //  EVENT: raised when all table requests are ready
        public event Action<TableRequest>? TableRequestsReady;

        //  Новый метод: принимаем по ИМЕНИ
        public void ReceiveRequest(string customerName, int chickenQty, int eggQty, string drinkName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new Exception("Customer name is required.");

            if (!customersInOrder.Contains(customerName))
                customersInOrder.Add(customerName);

            if (_customerCount >= 8)
                throw new Exception("Maximum customer limit for a table reached!");

            // Add chickens
            for (int i = 0; i < chickenQty; i++)
                tableRequests.Add<Chicken>(customerName);

            // Add eggs
            for (int i = 0; i < eggQty; i++)
                tableRequests.Add<Egg>(customerName);

            // Add drink (if not NoDrink)
            if (!string.IsNullOrWhiteSpace(drinkName) && drinkName != "NoDrink")
            {
                // выбираем тип напитка без создания объектов
                switch (drinkName)
                {
                    case "Coffee":
                        tableRequests.Add<Coffee>(customerName); break;
                    case "Cola":
                        tableRequests.Add<Cola>(customerName);   break;
                    case "Milk":
                        tableRequests.Add<Milk>(customerName);   break;
                    case "Tea":
                        tableRequests.Add<Tea>(customerName);    break;
                    case "Water":
                        tableRequests.Add<Water>(customerName);  break;
                    case "Juice":
                        tableRequests.Add<Juice>(customerName);  break;
                    default:
                        throw new Exception($"Unknown drink: {drinkName}");
                }
            }

            cooked = false;
            _customerCount++;
        }

        

        // SEND button logic → raise event instead of calling Cook
        public void SendToCook()
        {
            if (tableRequests.CustomerCount == 0)
                throw new Exception("No orders to cook.");

            cooked = true;
            TableRequestsReady?.Invoke(tableRequests);
            _customerCount = 0;
        }

        // Serve food to customers (by current order list)
        public string ServeFood()
        {
            if (!cooked)
                return "Orders haven't been cooked yet.";

            string result = "";

            foreach (string customerName in customersInOrder)
            {
                List<IMenuItem> items = tableRequests[customerName];
                if (items.Count == 0)
                    continue;

                int chickenCount = 0;
                int eggCount = 0;
                string? drink = "NoDrink";

                // 1) DRINKS FIRST (по твоему правилу: drink = not CookedFood)
                foreach (var item in items)
                {
                    if (item is not CookedFood)
                    {
                        item.Obtain(); // Server obtains drinks
                        drink = item.ToString();
                        item.Serve();
                    }
                }

                // 2) THEN FOOD
                foreach (var item in items)
                {
                    if (item is CookedFood)
                    {
                        if (item is Chicken) chickenCount++;
                        else if (item is Egg) eggCount++;

                        item.Serve();
                    }
                }

                result += $"{customerName} is served {chickenCount} chicken, {eggCount} egg, {drink}.\n";
            }

            result += "\nPlease enjoy your meal!";
            return result;
        }
    }
}
