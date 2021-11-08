using System.Collections.Generic;

namespace Sharp1
{
    public class Company // Класс "Компания"
    {
        public string name; // Название
        public List<Department> departments; // Отделы
        public List<Order> orders; // Заказы

        public Company(string _name, List<Department> _departments, List<Order> _orders)
        {
            this.name = _name;
            this.departments = _departments;
            this.orders = _orders;
        }

        public Product completeTask(Order task) // Выполнить заказ
        {
            for (int i = 0; i < this.departments.Count; i++)
            {
                if (this.departments[i].IsTaskBeCompletedInTime(task))
                {
                    return this.departments[i].CompleteTask(task);
                }
            }
            return null;
        }
        public bool isCompleteTask(Order task) // Проверить выполнения
        {
            for (int i = 0; i < this.departments.Count; i++)
            {
                if (this.departments[i].IsTaskBeCompletedInTime(task))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
