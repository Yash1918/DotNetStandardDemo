using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework40Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp = MultitargetStandardLibrary.DemoClass.GetEmployee("111634");
            if (emp != null)
                Console.WriteLine(emp.id + " " + emp.employee_name + " " + emp.employee_salary);
            else
                Console.WriteLine("Employee record not found.");
        }
    }
}
