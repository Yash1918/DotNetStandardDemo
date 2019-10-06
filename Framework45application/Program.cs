using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework45application
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp = MultitargetStandardLibrary.DemoClass.GetEmployeeAsync("111634").Result;
            if (emp != null)
                Console.WriteLine(emp.id + " " + emp.employee_name + " " + emp.employee_salary);
            else
                Console.WriteLine("Employee record not found.");
        }
    }
}
