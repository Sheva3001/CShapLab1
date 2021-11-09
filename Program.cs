using System;
using System.Collections.Generic;

namespace Sharp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сотрудники
            DesktopEmployee DesktopEmpl1 = new DesktopEmployee("DesktopEmpl1", 5, 7);
            DesktopEmployee DesktopEmpl2 = new DesktopEmployee("DesktopEmpl2", 3, 6);
            List<Employee> DesktopEmpl = new List<Employee>();
            DesktopEmpl.Add(DesktopEmpl1); DesktopEmpl.Add(DesktopEmpl2);

            MobileEmployee MobileEmpl1 = new MobileEmployee("MobileEmpl1", 4, 8);
            MobileEmployee MobileEmpl2 = new MobileEmployee("MobileEmpl2", 9, 1);
            MobileEmployee MobileEmpl3 = new MobileEmployee("MobileEmpl3", 1, 10);
            List<Employee> MobileEmpl = new List<Employee>();
            MobileEmpl.Add(MobileEmpl1); MobileEmpl.Add(MobileEmpl2); MobileEmpl.Add(MobileEmpl3);

            WebEmployee WebEmpl1 = new WebEmployee("WebEmpl1", 3, 5);
            List<Employee> WebEmpl = new List<Employee>();
            WebEmpl.Add(WebEmpl1);

            // Отделы
            DesktopDepartment DesktopDepartment = new DesktopDepartment("DesktopDepartment", DesktopEmpl);
            MobileDepartment MobileDepartment = new MobileDepartment("MobileDepartment", MobileEmpl);
            WebDepartment WebDepartment = new WebDepartment("WebDepartment", WebEmpl);
            List<Department> Departments = new List<Department>();
            Departments.Add(DesktopDepartment); Departments.Add(MobileDepartment); Departments.Add(WebDepartment);

            // Задачи
            Order TaskDesk = new Order("TaskDesk", Type.DesktopApp, 6);
            Order MobileDesk = new Order("MobileDesk", Type.MobileApp, 1);
            Order WebDesk = new Order("WebDesk", Type.WebApp, 4);
            List<Order> Tasks = new List<Order>();
            Tasks.Add(TaskDesk); Tasks.Add(MobileDesk); Tasks.Add(WebDesk); Tasks.Add(null);

            // Компания
            Company Comp = new Company("Comp", Departments, Tasks);

            // Main
            for(int i = 0; i<Tasks.Count; i++)
            {
                if (Comp.isCompleteTask(Comp.orders[i]))
                {
                    Product prod = Comp.completeTask(Comp.orders[i]);
                    Console.WriteLine(prod.name);
                }
                else
                {
                    Console.WriteLine("Не может быть выполнено");
                }
            }


        }
    }
}