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
            name = _name;
            departments = _departments;
            orders = _orders;
        }

        public Product completeTask(Order task) // Выполнить заказ
        {
            if(task == null)
            {
                return null;
            }
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].IsTaskBeCompletedInTime(task))
                {
                    return departments[i].CompleteTask(task);
                }
            }
            return null;
        }
        public bool isCompleteTask(Order task) // Проверить выполнения
        {
            if (task == null)
            {
                return false;
            }
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].IsTaskBeCompletedInTime(task))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
