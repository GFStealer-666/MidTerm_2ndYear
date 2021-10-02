using System;
using System.Collections.Generic;
using System.Collections;

namespace Library
{
    enum Mainmenu
    {
        Login = 1,
        Register
    }

    class Program
    {
        static PersonList personList;


        static void Main(string[] args)
        {

            Program.personList = new PersonList();
            PrintMainMenu();

        }

        static void PrintMainMenu()
        {
            PrintHeader(1);
            PrintMenuList();
            InputMenuFromKeyboard();
        }

        static void PrintMenuList()
        {
            Console.WriteLine("1. Login ");
            Console.WriteLine("2. Register");
        }

        static void InputMenuFromKeyboard()
        {
            Console.Write("Select Menu : ");
            Mainmenu menu = (Mainmenu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }

        static void PresentMenu(Mainmenu menu)
        {
            if (menu == Mainmenu.Login)
            {
                LoginMenu();
            }
            else if (menu == Mainmenu.Register)
            {
                RegisterMenu();
            }
            else
                InputMainMenuError();
            
        }

        static void LoginMenu()
        {
            PrintHeader(3);
            DisplayLogin();
        }

        static void DisplayLogin()
        {
            string name = InputName();
            string password = InputPassword();

            LoginStuff(name, password);
        }

        static void LoginStuff(string name, string password)
        {
            Person Test = new Person("0", "0");

            int counter = 0;

            foreach (Person person in Program.personList.GetPersonList())
            {
                if (name == person.username)
                {
                    Test = person;
                    break;
                }


                counter++;
            }

            if (Test.username == "0")
            {
                Console.WriteLine("Invalid User name Input , please try again");

                Console.WriteLine("");

                PrintMainMenu();
            }

            if (password == Test.GetPassword())
            {
                Console.WriteLine("User exist on Database ");

                Console.WriteLine("");

            }
            else
            {
                Console.WriteLine("Invaild Password Input , please try again");

                Console.WriteLine("");

                PrintMainMenu();
            }

            if (Test is Student)
            {
                List<Person> numberList = personList.GetPersonList();
                Student TStudent = numberList[counter] as Student;

                PrintHeader(4);
                PrintName(name);
                PrintStudentID(TStudent.studentID);

                BorrowBook();
            }

            if (Test is Employee)
            {
                List<Person> numberList = personList.GetPersonList();
                Employee TEmployee = numberList[counter] as Employee;

                PrintHeader(5);
                PrintName(name);
                PrintEmployeeID(TEmployee.employeeID);

                ShowBookList();
            }
        }

        static void ShowBookList()
        {
            Console.WriteLine("Book List");

            Console.WriteLine("-----------------");

            List<string> bookList = new List<string>();

            bookList.Add("NOW I UNDERSTAND");
            bookList.Add(" REVOLUTIONARY WEALTH");
            bookList.Add("Six Degrees");
            bookList.Add("Les Vacances");

            for (int i = 0; i < bookList.Count; i++)
            {
                Console.WriteLine("Book ID : {0}", i);
                Console.WriteLine("Book name : {0}", bookList[i]);
            }

            Console.ReadLine();
        }

        static void BorrowBook()
        {
            Console.WriteLine("----------");

            StudentInputMenu(); 

        }

        static void StudentInputMenu()
        {
            Console.WriteLine("1. Borrow Book");

            Console.Write("Input Menu : ");

            int menu = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            BookList();
        }

        /*  static void CheckStudentInputMenu()
          {
        
          } */

        static void BookList()
        {
            string bookid = "1";

            BookList book = new BookList();

            book.AddNewBook("NOW I UNDERSTAND", 1);
            book.AddNewBook(" REVOLUTIONARY WEALTH", 2);
            book.AddNewBook("Six Degrees", 3);
            book.AddNewBook("Les Vacances", 4);

            int bookamount = book.GetBookList().Count;

            while (bookid != "exit")
            { 

                /*  for (int i = 0; i < bookamount; i++) 
                  {
                      Console.WriteLine("Book ID : {0}", book.GetBookList()[i].ID);
                      Console.WriteLine("Book name : {0}", book.GetBookList()[i].name);
                  } */

                book.ShowBook();

                if (bookamount != 0 && bookid != "exit")
                {
                    bookid = InputBookID();

                    if (bookid == "exit")
                    {
                        break;
                    }

                    int bookid2 = Int32.Parse(bookid);

                    //     book.GetBookList().RemoveAt(bookid2 - 1);

                    book.RemoveBook(bookid2-1); 
                    bookamount--;
                }
                
                if (bookamount == 0)
                {
                    Console.WriteLine("Book list is currently empty");

                    Console.WriteLine(" ");

                    Console.WriteLine("Input Exit to exit");

                    bookid = InputBookID();
                }
            }
        }
        static string InputBookID()
        {
            Console.Write("Input Book ID : ");

            string bookid = Console.ReadLine();

            return bookid;
        }
        static void PrintName(string name)
        {
            Console.WriteLine("Name : {0}", name);
        }

        static void PrintStudentID(string input)
        {
            Console.WriteLine("StudentID : {0}", input);

        }

        static void PrintEmployeeID(string employeeid)
        {
            Console.WriteLine("EmployeeID : {0}", employeeid);
        }

        static void RegisterMenu()
        {
            PrintHeader(2);
            RegisterFromKeyboard();
        }

        static void RegisterFromKeyboard()
        {
            string name = InputName();
            string password = InputPassword();
            int menutype = InputUserType();

            CheckWhatType(name, password, menutype);

        }

        static void PrintHeader(int menu)
        {
            if (menu == 1)
            {
                Console.WriteLine("Welcome to the Digital Library!");
                Console.WriteLine("-------------------------------");
            }

            if (menu == 2)
            {
                Console.WriteLine("Register new Person");
                Console.WriteLine("--------------------");
            }

            if (menu == 3)
            {
                Console.WriteLine("Login Screen");
                Console.WriteLine("-----------------");
            }

            if (menu == 4)
            {
                Console.WriteLine("Student Management");
                Console.WriteLine("-------------------");
            }

            if (menu == 5)
            {
                Console.WriteLine("Employee Management");
                Console.WriteLine("--------------------");
            }


        }

        static string InputName()
        {
            Console.Write("Input name : ");

            string name = Console.ReadLine();

            return name;
        }

        static string InputPassword()
        {
            Console.Write("Input password : ");

            string password = Console.ReadLine();

            return password;
        }

        static int InputUserType()
        {
            Console.Write("Input User Type 1 = Student, 2 = Employee : ");

            int usertype = int.Parse(Console.ReadLine());

            return usertype;
        }

        /* static int InputUserType()
         {
             int usertype =1;

             while(usertype != 0)
             {
                 Console.Write("Input User Type 1 = Student, 2 = Employee : ");

                 usertype = int.Parse(Console.ReadLine());

                 if (usertype <= 0 || usertype >= 3)
                 {
                     Console.WriteLine("Invaild value input , Please try again");

                     InputUserType();

                 }
                 else
                     break;


             }

             return usertype;
         } */

        static string StudentID()
        {
            Console.Write("Student ID : ");

            string studentid = Console.ReadLine();

            return studentid;
        }

        static string EmployeeID()
        {
            Console.Write("Employee ID : ");

            string employeeid = Console.ReadLine();

            return employeeid;
        }

        static void InputMainMenuError()
        {
            Console.WriteLine("Invaild menu input , Please try again ");

            Console.WriteLine("");

            PrintMainMenu();
        }

        static void CheckWhatType(string name, string password, int usertype)
        {
            if (usertype == 1)
            {
                Student student = CreateNewStudent(name, password);
                Program.personList.AddNewPerson(student);

                PrintMainMenu();
            }
            else if (usertype == 2)
            {
                Employee employee = CreateEmployee(name, password);
                Program.personList.AddNewPerson(employee);

                PrintMainMenu();

            }
        }

        static Student CreateNewStudent(string name, string password)
        {
            return new Student(name, password, StudentID());
        }

        static Employee CreateEmployee(string name, string password)
        {
            return new Employee(name, password, EmployeeID());
        }
    }
    class Book
    {
        public string name;

        public int ID;

        public Book(string name, int ID)
        {
            this.name = name;
            this.ID = ID;
        }

        public int Have = 1;

    }
    class BookList

    {
        public int amount = 0;

        static protected List<Book> booklist;

        public int a;

        public BookList()
        {
            booklist = new List<Book>();
        }

        public List<Book> GetBookList()
        {
            return booklist;
        }

        public void AddNewBook(string name, int ID)
        {
            Book book = new Book(name, ID);
            booklist.Add(book);
            amount++;
        }

        public void ShowBook()
        {
            for (int i = 0; i < amount; i++)
            {

                if (booklist[i].Have == 1) 
                {
                    Console.WriteLine("Book ID : {0}", booklist[i].ID);
                    Console.WriteLine("Book name : {0}", booklist[i].name);
                    Console.WriteLine("----------------------");
                }            
            }
        }
        public void RemoveBook(int ID)
        {
            booklist[ID].Have = 0;

        }
    }
    class Person
    {
        public string username;

        protected string password;

        public Person(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string GetName()
        {
            return this.username;
        }

        public string GetPassword()
        {
            return this.password;
        }
    }

    class PersonList
    {
        protected List<Person> personlist;

        public PersonList()
        {
            this.personlist = new List<Person>();
        }

        public void AddNewPerson(Person person)
        {
            this.personlist.Add(person);
        }

        public List<Person> GetPersonList()
        {
            return this.personlist;
        }

    }   

    class Student : Person
    {
        public string studentID;

        public Student(string username, string password, string studentID) : base(username, password)
        {
            this.studentID = studentID;

        }

        public string GetStudentID()
        {
            return this.studentID;
        }


    }

    class Employee : Person
    {
        public string employeeID;

        public Employee(string username, string password, string employeeID) : base(username, password)
        {
            this.employeeID = employeeID;
        }

        public string GetEmployeeID()
        {
            return this.employeeID;
        }
    }
}
