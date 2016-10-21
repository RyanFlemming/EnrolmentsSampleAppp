using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolments
{
	internal enum DegreeType
	{
		Associate, Bachelor, Master, Doctorate
	}

	internal abstract class Person
	{
		private string _firstName;
		private string _lastName;

		public Person(string firstName, string lastName)
		{
			_firstName = firstName;
			_lastName = lastName;
		}
		public string FirstName
		{
			get { return _firstName; }
			set { _firstName = value; }
		}
		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}
	}
	internal class Student : Person
	{
		private Stack<int> _grades;

		public Stack<int> Grades
		{
			get { return _grades; }
			set { _grades = value; }
		}

		// Calling the base constructor, in order to set first & lastname
		public Student(string firstName, string lastName)
			: base(firstName, lastName)
		{
			_grades = new Stack<int>();
		}
	}

	internal class Teacher : Person
	{
		public Teacher(string firstName, string lastName)
			: base(firstName, lastName)
		{
		}
		public override string ToString()
		{
			return string.Format("{0} {1}", FirstName, LastName);
		}
	}

	internal class Course
	{
		private List<Student> _students;
		private Teacher _teachers;
		private string _name;

		internal List<Student> Students
		{
			get { return _students; }
			set { _students = value; }
		}
		
		internal Teacher Teachers
		{
			get { return _teachers; }
			set { _teachers = value; }
		}

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		internal Course(string name, List<Student> students, Teacher teachers)
		{
			_name = name;
			_students = students;
			_teachers = teachers;
		}

		public void ListStudents()
		{
			var h = this.Students.Cast<string>().OrderBy(item => int.Parse(item));
			foreach (Student s in this._students)
			{
				Console.WriteLine("First Name: {0}\nLast Name: {1}\n", s.FirstName, s.LastName);
			}
		}
	}

	internal class Degree
	{
		private string courseName;
		private DegreeType levelOfDegree;
		private List<Course> courses;

		public string Name
		{
			get { return courseName; }
			set { courseName = value; }
		}

		internal List<Course> Courses
		{
			get { return courses; }
			set { courses = value; }
		}

		internal DegreeType LevelOfDegree
		{
			get { return levelOfDegree; }
			set { levelOfDegree = value; }
		}

		internal Degree(string name, DegreeType degreeType, List<Course> coursesChosen)
		{
			this.courseName = name;
			this.levelOfDegree = degreeType;
			this.courses = coursesChosen;
		}

		internal Degree(string name, DegreeType degreeType)
			: this(name, degreeType, new List<Course>())
		{
		}
	}

	internal class UProgram
	{
		private string _name;
		private List<Degree> _degrees;

		internal List<Degree> Degrees
		{
			get { return _degrees; }
			set { _degrees = value; }
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		internal UProgram(string courseName, List<Degree> degrees)
		{
			this._name = courseName;
			this._degrees = degrees;
		}

		internal UProgram(string courseName)
			: this(courseName, new List<Degree>())
		{
		}
	}
}