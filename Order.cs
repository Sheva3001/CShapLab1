namespace Sharp1
{
    public class Order // Класс "Заказ"
    {
        public string name; // Название
        public Type orderComponents; // Составляющие заказа
        public int time; // Время

        public Order(string _name, Type _components, int _time)
        {
            name = _name;
            orderComponents = _components;
            time = _time;
        }
    }
}
