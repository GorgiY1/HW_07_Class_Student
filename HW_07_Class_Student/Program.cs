using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_07_Class_Student
{
    enum Subject
    {
        JS,
        Piton,
        Unity_3D
    }
    class Student
    {
        public string Name { get; set; } = "Johnni";
        public int Age { get; set; } = 21;
        public string PhoneNumber { get; set; } = "+380680538556";

        public string[][] numArr = new string[3][];

        Random random = new Random();
        public Student()
        {
            for (int i = 0; i < numArr.Length; i++)
            {
                numArr[i] = new string[random.Next(4, 7)];
            }

            numArr[0][0] = "HTML_CSS";
            numArr[1][0] = "Cpp     ";
            numArr[2][0] = "CS      ";

            GiveMark();
        }

        public void GiveMark()
        {
            for (int i = 0; i < numArr.Length; i++)
            {
                for (int j = 1; j < numArr[i].Length; j++)
                {
                    numArr[i][j] = $"{random.Next(9, 12)}";
                }
            }
        }

        public void GiveMark(int intdexSubject, string mark)
        {
            Array.Resize<string>(ref numArr[intdexSubject - 1], numArr[intdexSubject-1].Length + 1);
            numArr[intdexSubject-1][numArr[intdexSubject-1].Length - 1] = mark;
        }
        public void ShowMark()
        {
            for (int i = 0; i < numArr.Length; i++)
            {
                for (int j = 0; j < numArr[i].Length; j++)
                {
                    Console.Write($"{numArr[i][j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void ShowMark(int index_subjects)
        {
            for (int j = 0; j < numArr[index_subjects - 1].Length; j++)
            {
                Console.Write($"{numArr[index_subjects - 1][j]}\t");
            }
            Console.WriteLine();
        }

        //public string this[string name]
        //{
        //    get
        //    {
        //        return $"Subject {1234}";
        //        return "This subject does not exist!";
        //    }
        //    set
        //    {
        //        //if (numArr.Length[i][0] == name)
        //        //{ laptopArr[(int)Enum.Parse(typeof(Vendors), name)] = value;
        //    }
        //}
        public override string ToString()
        {
            return $"Student Name: {Name}\nStudent Age: {Age}\nStudent Phone Number: {PhoneNumber}\n";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Необходимо создать класс Student.

                Реализовать в нем следующую функциональность:

                - массив оценок по трем предметам (jagged);
                - метод выставления оценок;
                - метод показа оценок по определенному предмету;
                - метод вывода информации о студенте.
             */

            Student student = new Student();

            int menu = 0;
            int menu1 = 0;
            string mark = null;
            do
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine($"\n   Select operation: ");
                Console.WriteLine($"1. Show Student: ");
                Console.WriteLine($"2. Generation of grades: ");
                Console.WriteLine($"3. Grade on selected subjects, from 1 to 12: ");
                Console.WriteLine($"4. Show all grades in all subjects: ");
                Console.WriteLine($"5. Show grades by selected subjects: ");
                Console.WriteLine("=============================\n");

                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:

                        Console.WriteLine(student);
                        break;

                    case 2:

                        student.GiveMark();
                        student.ShowMark();
                        break;

                    case 3:

                        Console.WriteLine("Select of a subject");
                        Console.WriteLine($"\t1. HTML_CSS: ");
                        Console.WriteLine($"\t2. Cpp: ");
                        Console.WriteLine($"\t3. CS: ");
                        Console.WriteLine($"Enter subject number: ");

                        try
                        {
                            menu1 = int.Parse(Console.ReadLine());
                            if (menu1 >= 1 && menu1 <= 3)
                            {
                                Console.WriteLine($"Enter mark by the subject: ");

                                mark = Console.ReadLine();
                                if (int.Parse(mark) >= 1 && int.Parse(mark) <= 12)
                                {
                                    student.GiveMark(menu1, mark);
                                    student.ShowMark();
                                }
                                else throw new Exception("Error! the mark does not exist! Input mark from 1 to 12");
                            }
                            else throw new Exception("Error! the subject does not exist! Input number from 1 to 3");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:

                        student.ShowMark();
                        break;

                    case 5:

                        Console.WriteLine("Select of a subject");
                        Console.WriteLine($"\t1. HTML_CSS: ");
                        Console.WriteLine($"\t2. Cpp: ");
                        Console.WriteLine($"\t3. CS: ");
                        Console.WriteLine($"Enter subject number: ");

                        try
                        {
                            menu1 = int.Parse(Console.ReadLine());
                            if (menu1 >= 1 && menu1 <= 3)
                            {
                               student.ShowMark(menu1);
                            }
                            else throw new Exception("Error! the subject does not exist! Input number from 1 to 3");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        
                        break;

                    default:
                        Console.WriteLine("This item does not exist!");
                        break;
                }

            } while (menu != 0);

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
