using Restaurant_4.Interfaces;

namespace Restaurant_4.Abstract
{
    public abstract class CookedFood : MenuItem, ICookedFood
    {
        public abstract void Cook(); 
    }
}
