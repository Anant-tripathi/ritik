using System;

namespace Student_Grade_Calculator
{

    class Student
    {
        public String name;
        public String cl;
        public String section;
        public String enrollmentNo;
        public float[] marks;
        public String grade;

        public Student()
        {
            Console.WriteLine("Enter the data values for the Student: ");
            Console.Write("\nName :");
            this.name = Console.ReadLine();
            Console.Write("\n Class: ");
            this.cl = Console.ReadLine();
            Console.Write("\n Section: ");
            this.section = Console.ReadLine();
            Console.Write("\n Enrollment Number: ");
            this.enrollmentNo = Console.ReadLine();

            marks = new float[5];

            Console.WriteLine("Enter the values of marks: ");
            for (int i = 0; i < 5; i++)
                marks[i] = Convert.ToInt32(Console.ReadLine());
        }

        public void getDetails()
        {
            Console.WriteLine("Name : " + this.name);
            Console.WriteLine("Class : " + this.cl);
            Console.WriteLine("Section : " + this.section);
            Console.WriteLine("Enrollment no : " + this.enrollmentNo);
            Console.WriteLine("Marks : ");
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine(this.marks[i]);
            }
            Console.WriteLine("Grade : " + this.grade);
        }

        public void calculateGrade()
        {
            float perc = 0;
                float sum=0;
            for(int i = 0; i < 5; i++)
            {
                sum += marks[i];
            }
            perc = sum/500 * 100;

            if (perc >= 75)
                this.grade = "A+";
            else if (perc >= 60 && perc < 75)
                this.grade = "A";
            else if (perc >= 50 && perc < 59)
                this.grade = "A";
            else if (perc >= 40 && perc < 49)
                this.grade = "C";
            else
                this.grade = "F";

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.getDetails();
            Console.ReadLine();
        }
    }
}
