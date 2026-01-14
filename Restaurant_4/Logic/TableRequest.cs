using Restaurant_4.Abstract;
using Restaurant_4.Interfaces;
using System;
using System.Collections;

namespace Restaurant_4.Logic
{
    // Improvement 4: implements IEnumerable
    public class TableRequest : IEnumerable<IMenuItem>
    {
        // customer name -> list of requested items
        private Dictionary<string, List<IMenuItem>> requests = new();

        // ===== Add item by TYPE =====
        public void Add<T>(string customerName)
            where T : IMenuItem, new()
        {
            if (string.IsNullOrWhiteSpace(customerName))
                throw new Exception("Customer name is required");

            if (!requests.ContainsKey(customerName))
                requests[customerName] = new List<IMenuItem>();



            requests[customerName].Add(new T());
        }

        // Get all items of a specific type 
        public List<T> Get<T>() where T : IMenuItem
        {
            List<T> result = new();

            foreach (var customerItems in requests.Values)
                foreach (var item in customerItems)
                    if (item is T typedItem)
                        result.Add(typedItem);

            return result;
        }

        //  Indexer by customer NAME 
        public List<IMenuItem> this[string customerName]
        {
            get
            {
                if (!requests.ContainsKey(customerName))
                    return new List<IMenuItem>();

                return requests[customerName];
            }
        }

        //  Improvement 4: Iterator (drinks first, then food) 
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            // 1) Drinks first (not CookedFood)
            foreach (var customerItems in requests.Values)
            {
                foreach (var item in customerItems)
                {
                    if (item is not CookedFood)
                        yield return item;
                }
            }

            // 2) Then cooked food
            foreach (var customerItems in requests.Values)
            {
                foreach (var item in customerItems)
                {
                    if (item is CookedFood)
                        yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // ===== Info =====
        public int CustomerCount => requests.Count;

        public IEnumerable<string> Customers => requests.Keys;
    }
}
