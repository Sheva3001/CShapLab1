using System;
using System.Collections.Generic;

namespace Sharp1
{
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
            if (Comp.isCompleteTask(Comp.orders[2])) {
                Product prod = Comp.completeTask(Comp.orders[2]);
                Console.WriteLine(prod.name);
            }
        }
    }
}