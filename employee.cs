using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee
{
    class employee
    {
        public String name;
        public String type;
        public String joiningDate;
        public String Department;
        public String address;
        public long contact;
        public float salary;
    }

    class adHoc : employee
    {
        public adHoc(String n, String t, String d, String dept, String add, long cont, float sal) {
            this.name = n;
            this.type = t;
            this.joiningDate = d;
            this.Department = dept;
            this.address = add;
            this.contact = cont;
            this.salary = setSalary(sal);
        }

        public float setSalary(float sal)
        {
            if (sal >= 10000 && sal <= 15000)
                return sal + (sal * (95 / 100)) + (sal * (15 / 100)) + 1200;
            else if (sal > 15000 && sal <= 20000)
                return sal + (sal * (115 / 100)) + (sal * (18 / 100)) + 1200;
            else
                return sal + (sal * (125 / 100)) + (sal * (22 / 100)) + 1200;
        }

        public void showDetails()
        {
            Console.WriteLine("This is an ad-hoc employee : ");
            Console.WriteLine("Name : " + this.name);
            Console.WriteLine("Joining Date : " + this.joiningDate);
            Console.WriteLine("Department : " + this.Department);
            Console.WriteLine("Correspondence Address : " + this.address);
            Console.WriteLine("Contact Details : " + this.contact);
            Console.WriteLine("Salary : " + this.salary);
        }
    }

    class permanent : employee
    {
        public permanent(String n, String t, String d, String dept, String add, long cont, float sal)
        {
            this.name = n;
            this.type = t;
            this.joiningDate = d;
            this.Department = dept;
            this.address = add;
            this.contact = cont;
            this.salary = setSalary(sal);
        }

        public float setSalary(float sal)
        {
            if (sal >= 10000 && sal <= 15000)
                return sal + (sal * (95 / 100)) + (sal * (15 / 100)) - (sal * (15 / 100));
            else if (sal > 15000 && sal <= 20000)
                return sal + (sal * (115 / 100)) + (sal * (18 / 100))-(sal * (15 / 100));
            else
                return sal + (sal * (125 / 100)) + (sal * (22 / 100)) - (sal * (15 / 100));
        }

        public void showDetails()
        {
            Console.WriteLine("This is a permanent employee : ");
            Console.WriteLine("Name : " + this.name);
            Console.WriteLine("Joining Date : " + this.joiningDate);
            Console.WriteLine("Department : " + this.Department);
            Console.WriteLine("Correspondence Address : " + this.address);
            Console.WriteLine("Contact Details : " + this.contact);
            Console.WriteLine("Salary : " + this.salary);
        }
    }

    class main
    {
        public static void Main(String[] args)
        {
            adHoc emp1 = new adHoc("John", "adHoc", "2015-11-14", "IT", "Some Address", 975462468274, 12302);
            permanent emp2 = new permanent("Doe", "permanent", "2015-10-12", "Accounts", "Some other address", 4587634581, 54624);
            emp1.showDetails();
            Console.WriteLine("\n\n");
            emp2.showDetails();
        }
    }
}
