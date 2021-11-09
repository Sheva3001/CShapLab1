using System.Collections.Generic;
using System.Linq;

namespace Sharp1
{
    public class Department // Класс "Отдел"
    {
        public string name; // Название
        public List<Employee> staff; // Сотрудники
        public Type type; // Тип отдела

        public Department() // Инициализация отдела
        {}

        public bool IsTaskBeCompleted(Order task) // Проверка возможности выполнить заказ
        {
            return staff.Any(e => e.specialization == task.orderComponents && e.IsTaskBeCompleted(task));
        }
        public Product CompleteTask(Order task) // Выполнение задачи
        {

            if (IsTaskBeCompleted(task))
            {
                var employee = staff
                    .Where(e => e.IsTaskBeCompleted(task))
                    .OrderBy(e => e.completedOrdersCount)
                    .First();
                return employee.CompleteTask(task);
            }

            return null;
        }
        public bool IsTaskBeCompletedInTime(Order task) // Проверка может ли отдел выполнить указанную задачу в срок
        {
            if (!IsTaskBeCompleted(task))
            {
                return false;
            }
            for (int i = 0; i < staff.Count; i++)
            {
                if (staff[i].IsTaskBeCompleted(task))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class DesktopDepartment : Department
    {
        public DesktopDepartment(string _name, List<Employee> _staff) // Инициализация отдела
        {
            name = _name;
            staff = _staff;
            type = Type.DesktopApp;
        }
    }

    public class MobileDepartment : Department
    {
        public MobileDepartment(string _name, List<Employee> _staff) // Инициализация отдела
        {
            name = _name;
            staff = _staff;
            type = Type.MobileApp;
        }
    }

    public class WebDepartment : Department
    {
        public WebDepartment(string _name, List<Employee> _staff) // Инициализация отдела
        {
            name = _name;
            staff = _staff;
            type = Type.WebApp;
        }
    }
}
