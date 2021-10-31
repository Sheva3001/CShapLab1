using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp1
{
    public enum Type : byte
    {
        DesktopApp,
        MobileApp,
        WebApp
    };

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

    public class Product // Класс "Продукт"
    {
        public string name; // Название

        public Product(string _name) // Инициализация продукта
        {
            this.name = _name;
        }
    }

    public class Order // Класс "Заказ"
    {
        public string name; // Название
        public Type orderComponents; // Составляющие заказа
        public int time; // Время

        public Order(string _name, Type _components, int _time)
        {
            this.name = _name;
            this.orderComponents = _components;
            this.time = _time;
        }
    }

    public class Department // Класс "Отдел"
    {
        public string name; // Название
        public List<Employee> staff; // Сотрудники
        public Type type; // Тип отдела

        public Department(string _name, List<Employee> _staff, Type _type) // Инициализация отдела
        {
            this.name = _name;
            this.staff = _staff;
            this.type = _type;
        }

        public bool IsTaskBeCompleted(Order task) // Проверка возможности выполнить заказ
        {
            return task.orderComponents == this.type;
        }
        public Product CompleteTask(Order task) // Выполнение задачи
        {
            int index = 0;
            int minCompleteTasksCount = 1000000;
            for (int i = 1; i < this.staff.Count; i++)
            {
                if(this.staff[i].IsTaskBeCompleted(task) && this.staff[i].completedOrdersCount <= minCompleteTasksCount)
                {
                    index = i;
                    minCompleteTasksCount = this.staff[i].completedOrdersCount;
                }
            }
            return this.staff[index].CompleteTask(task);
        }
        public bool IsTaskBeCompletedInTime(Order task) // Проверка может ли отдел выполнить указанную задачу в срок
        {
            if (!this.IsTaskBeCompleted(task))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < this.staff.Count; i++)
                {
                    if(this.staff[i].IsTaskBeCompleted(task))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }

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
            int index = 0;
            isCompleteTask(task, index);
            return this.departments[index].CompleteTask(task);
        }
        public bool isCompleteTask(Order task, int index) // Проверить выполнения
        {
            for (int i = 0; i < this.departments.Count; i++)
            {
                if (this.departments[i].IsTaskBeCompletedInTime(task))
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Сотрудники
            Employee DesktopEmpl1 = new Employee("DesktopEmpl1", Type.DesktopApp, 5, 7);
            Employee DesktopEmpl2 = new Employee("DesktopEmpl2", Type.DesktopApp, 3, 6);
            List<Employee> DesktopEmpl = new List<Employee>();
            DesktopEmpl.Add(DesktopEmpl1); DesktopEmpl.Add(DesktopEmpl2);

            Employee MobileEmpl1 = new Employee("MobileEmpl1", Type.MobileApp, 4, 8);
            Employee MobileEmpl2 = new Employee("MobileEmpl2", Type.MobileApp, 9, 1);
            Employee MobileEmpl3 = new Employee("MobileEmpl3", Type.MobileApp, 1, 10);
            List<Employee> MobileEmpl = new List<Employee>();
            MobileEmpl.Add(MobileEmpl1); MobileEmpl.Add(MobileEmpl2); MobileEmpl.Add(MobileEmpl3);

            Employee WebEmpl1 = new Employee("WebEmpl1", Type.WebApp, 3, 5);
            List<Employee> WebEmpl = new List<Employee>();
            WebEmpl.Add(WebEmpl1);

            // Отделы
            Department DesktopDepartment = new Department("DesktopDepartment", DesktopEmpl, Type.DesktopApp);
            Department MobileDepartment = new Department("MobileDepartment", MobileEmpl, Type.MobileApp);
            Department WebDepartment = new Department("WebDepartment", WebEmpl, Type.WebApp);
            List<Department> Departments = new List<Department>();
            Departments.Add(DesktopDepartment); Departments.Add(MobileDepartment); Departments.Add(WebDepartment);

            // Задачи
            Order TaskDesk = new Order("TaskDesk", Type.DesktopApp, 4);
            Order MobileDesk = new Order("MobileDesk", Type.MobileApp, 1);
            Order WebDesk = new Order("WebDesk", Type.WebApp, 4);
            List<Order> Tasks = new List<Order>();
            Tasks.Add(TaskDesk); Tasks.Add(MobileDesk); Tasks.Add(WebDesk);

            // Компания
            Company Comp = new Company("Comp", Departments, Tasks);

            // Main
            Product prod = Comp.completeTask(Comp.orders[0]);
            Console.WriteLine(prod.name);
        }
    }
}