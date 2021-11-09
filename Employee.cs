using System;
using System.Collections.Generic;

namespace Sharp1
{
    public abstract class Employee // Класс "Сотрудник"
    {
        public string name; // Фио
        public Type specialization; // Специализация
        public int completedOrdersCount; // Количество выполненных заказов
        public int copleteTaskTime; // Необходимое время для выполнения задачи

        public Employee() // Инициализация сотрудника
        {
        }

        public Product CompleteTask(Order task) // Выполнить задачу
        {
            Product result = new Product(task.name);
            completedOrdersCount++;
            return result; // Возвращаем продукт
        }
        public bool IsTaskBeCompleted(Order task) // Проверить возможность выполнения заказа
        {
            return copleteTaskTime <= task.time;
        }
    }

    public class DesktopEmployee : Employee
    {
        public DesktopEmployee(string _name, int _count, int _time) // Инициализация сотрудника
        {
            name = _name;
            specialization = Type.DesktopApp;
            completedOrdersCount = _count;
            copleteTaskTime = _time;
        }
    }
    public class MobileEmployee : Employee
    {
        public MobileEmployee(string _name, int _count, int _time) // Инициализация сотрудника
        {
            name = _name;
            specialization = Type.MobileApp;
            completedOrdersCount = _count;
            copleteTaskTime = _time;
        }
    }
    public class WebEmployee : Employee
    {
        public WebEmployee(string _name, int _count, int _time) // Инициализация сотрудника
        {
            name = _name;
            specialization = Type.WebApp;
            completedOrdersCount = _count;
            copleteTaskTime = _time;
        }
    }
}

