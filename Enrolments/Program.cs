using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolments
{
	class Program
	{	
		static void Main(string[] args)
		{
			// Initialising 3 student objects and adding them to our generic List
			List<Student> studentCollection = new List<Student>();
			studentCollection.Add(new Student("Ashna", "C."));
			studentCollection.Add(new Student("Ryan", "F."));
			studentCollection.Add(new Student("That", "Other Guy"));

			Teacher[] teachers = { new Teacher("Nick", "A.") };

			Course course = new Course("Programming With C#", studentCollection, teachers[0]);

			Degree degree = new Degree("ASP.NET MVC With Entity Framework", DegreeType.Bachelor);
			degree.Courses.Add(course);

			UProgram program = new UProgram("IT");
			program.Degrees.Add(degree);

			PrintStudentInfo(program, studentCollection);
			AssignGrades(studentCollection);
			ShowGrades(studentCollection);

			Console.ReadKey();
		}
		// Making sure students have random grades
		private static readonly Random randomGrade = new Random(5);

		static void AssignGrades(List<Student> studentCollection)
		{

			foreach (var student in studentCollection)
			{
				for (int i = 0; i < 5; i++)
				{
					student.Grades.Push(randomGrade.Next(60, 100));
				}
			}
		}


		private static void ShowGrades(List<Student> studentCollection)
		{
			foreach (var student in studentCollection)
			{
				Console.WriteLine("{0} {1} has the following grades: \n", student.FirstName, student.LastName);
				foreach (var grade in student.Grades)
				{
					Console.WriteLine(grade);
				}
				Console.WriteLine();
			}
		}

		internal static void PrintStudentInfo(UProgram program, List<Student> students)
		{
			var degrees = program.Degrees.First();
			Console.WriteLine("The {0} program contains the {1} degree.\n", program.Name, degrees.Name);

			var course = degrees.Courses.First();
			Console.WriteLine("The {0} degree contains the course {1} and is taught by {2}\n",
				degrees.Name, course.Name, course.Teachers.ToString());
			Console.WriteLine("The {0} course has {1} students:\n", course.Name, students.Count);

			course.ListStudents();
		}
	}
}