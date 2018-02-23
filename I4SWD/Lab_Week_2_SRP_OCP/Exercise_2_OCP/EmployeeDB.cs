using System.Collections.Generic;

namespace Exercise_2_OCP
{
    internal class EmployeeDB
    {
        private readonly List<Employee> _employees;
        private int _currentEmployeeIndex;

        public EmployeeDB()
        {
            _employees = new List<Employee>();
            Reset();
        }

        public void Reset()
        {
            _currentEmployeeIndex = 0;
        }

        public Employee GetNextEmployee()
        {
            return _currentEmployeeIndex == _employees.Count ? null : _employees[_currentEmployeeIndex++];
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }
    }
}
