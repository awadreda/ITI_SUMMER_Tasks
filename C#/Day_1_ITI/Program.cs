namespace LinqExamples;
using System;
using System.Collections.Generic;
using System.Linq; // Needed for LINQ methods

public class Student
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Subject[] subjects { get; set; }
}

public class Subject
{
    public int Code { get; set; }
    public string Name { get; set; }
}

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

        var query1 = numbers.Distinct().OrderBy(num => num);
        Console.WriteLine("Distinct and ordered numbers:\n");
        foreach (var number in query1)
        {
            Console.WriteLine(number);
        }

        var query2 = query1.Select(num => new { Number = num, Multiply = num * 2 });
        Console.WriteLine("Numbers and their multiples of 2:");
        foreach (var item in query2)
        {
            Console.WriteLine($"Number: {item.Number}, Multiply: {item.Multiply}");
        }

        string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };
        var queryNamesMethod = names.Where(name => name.Length == 3);
        Console.WriteLine("Names with length 3:");
        foreach (var name in queryNamesMethod)
        {
            Console.WriteLine(name);
        }

        var queryNamesMethod2 = names
            .Where(name => name.ToLower().Contains("a"))
            .OrderBy(name => name.Length);
        Console.WriteLine("Names containing 'a' ordered by length:\n");
        foreach (var name in queryNamesMethod2)
        {
            Console.WriteLine(name);
        }

        var queryNameMethod3 = names.Take(2);
        Console.WriteLine("First two names:");
        foreach (var name in queryNameMethod3)
        {
            Console.WriteLine(name);
        }

        List<Student> students = new List<Student>()
        {
            new Student()
            {
                ID = 1,
                FirstName = "Ali",
                LastName = "Mohammed",
                subjects = new Subject[]
                {
                    new Subject() { Code = 22, Name = "EF" },
                    new Subject() { Code = 33, Name = "UML" }
                }
            },
            new Student()
            {
                ID = 2,
                FirstName = "Mona",
                LastName = "Gala",
                subjects = new Subject[]
                {
                    new Subject() { Code = 22, Name = "EF" },
                    new Subject() { Code = 34, Name = "XML" },
                    new Subject() { Code = 25, Name = "JS" }
                }
            },
            new Student()
            {
                ID = 3,
                FirstName = "Yara",
                LastName = "Yousf",
                subjects = new Subject[]
                {
                    new Subject() { Code = 22, Name = "EF" },
                    new Subject() { Code = 25, Name = "JS" }
                }
            },
            new Student()
            {
                ID = 1,
                FirstName = "Ali",
                LastName = "Ali",
                subjects = new Subject[]
                {
                    new Subject() { Code = 33, Name = "UML" }
                }
            }
        };


        var queryStudent = students.Select(s => new
        {
            FullName = s.FirstName + " " + s.LastName,
            NoOfSubjects = s.subjects.Length
        });


        Console.WriteLine("Students with full names and number of subjects:\n");
        foreach (var student in queryStudent)
        {
            Console.WriteLine($"Full Name: {student.FullName}, Number of Subjects: {student.NoOfSubjects}");
        }


        var queryStudent2 = students.OrderByDescending(s => s.FirstName).ThenBy(s => s.LastName).Select(s => new
        {
            FirstName = s.FirstName,
            LastName = s.LastName
        });

        Console.WriteLine("Students ordered by First Name (desc) and Last Name (asc):\n");
        foreach (var student in queryStudent2)
        {
            Console.WriteLine($"First Name: {student.FirstName}, Last Name: {student.LastName}");
        }





        var querystudent3 = students.SelectMany(s => s.subjects, (s, subj) => new
        {
            StudentName = s.FirstName + " " + s.LastName,
            SubjectName = subj.Name
        });
        Console.WriteLine("Students and their subjects: \n");
        foreach (var item in querystudent3)
        {
            Console.WriteLine($"Student: {item.StudentName}, Subject: {item.SubjectName}");
        }
   

            var bonusQuery = students.SelectMany(s => s.subjects, (s, subj) => new { s.FirstName, s.LastName, subj.Name })
                       .GroupBy(x => x.Name)
                       .Select(g => new
                       {
                           SubjectName = g.Key,
                           Students = g.Select(x => x.FirstName + " " + x.LastName)
                       });
            Console.WriteLine("Students and their subjects: \n");
            foreach (var item in bonusQuery)
            {
                Console.WriteLine($"Subject: {item.SubjectName}, Students: {string.Join(", ", item.Students)}");
            }
   
    }
    



}
