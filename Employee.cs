using System;
using System.Collections.Generic;

namespace Sharp1
{
    public class Employee // Класс "Сотрудник"
    {
        public string name; // Фио
        public Type specialization; // Специализация
        public int completedOrdersCount; // Количество выполненных заказов
        public int copleteTaskTime; // Необходимое время для выполнения задачи

        public Employee(string _name, Type _spec, int _count, int _time) // Инициализация сотрудника
        {
            this.name = _name;
            this.specialization = _spec;
            this.completedOrdersCount = _count;
            this.copleteTaskTime = _time;
        }

        public Product CompleteTask(Order task) // Выполнить задачу
        {
            Product result = new Product(task.name);
            return result; // Возвращаем продукт
        }
        public bool IsTaskBeCompleted(Order task) // Проверить возможность выполнения заказа
        {
            return this.copleteTaskTime >= task.time;
        }
    }
}
