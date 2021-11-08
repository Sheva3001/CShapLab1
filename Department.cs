using System.Collections.Generic;
using System.Linq;

namespace Sharp1
{
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
            if (!this.IsTaskBeCompleted(task))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < this.staff.Count; i++)
                {
                    if (this.staff[i].IsTaskBeCompleted(task))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
