using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDEmployees
{
    class Employee
    {
        int employee_id;
        string first_name;
        string last_name;
        string email;
        string phone_number;
        DateTime hire_date;
        int fkjob_id;
        decimal salary;
        int? fkmanager_id;
        int? fkdepartment_id;

        public Employee(string first_name, string last_name, string email, string phone_number, DateTime hire_date, int fkjob_id, decimal salary, int fkmanager_id, int fkdepartment_id)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.phone_number = phone_number;
            this.hire_date = hire_date;
            this.fkjob_id = fkjob_id;
            this.salary = salary;
            this.fkmanager_id = fkmanager_id;
            this.fkdepartment_id = fkdepartment_id;
        }

        public Employee()
        {

        }

        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Email { get => email; set => email = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public DateTime Hire_date { get => hire_date; set => hire_date = value; }
        public int Fkjob_id { get => fkjob_id; set => fkjob_id = value; }
        public decimal Salary { get => salary; set => salary = value; }
        public int? Fkmanager_id { get => fkmanager_id; set => fkmanager_id = value; }
        public int? Fkdepartment_id { get => fkdepartment_id; set => fkdepartment_id = value; }
        public int Employee_id { get => employee_id; set => employee_id = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
