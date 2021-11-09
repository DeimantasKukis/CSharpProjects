using System;
using VismaDeveloperTask;

namespace VismaDeveloperTask
{
    public class LibraryBooks
    {
        public int bksBorrowed;
        public object[,] book = new object[5, 2];
        public object[,] bookIssue = new object[3, 2];

        public virtual void catalogue()
        {
            Console.WriteLine("Admin Catalogue Management");
        }
        public LibraryBooks()
        {
            char va = 'a';
            for(int i=0; i<5; i++)
            {
                for(int j=0; j<1; j++)
                {
                    book[i, j] = va;
                    va++;
                }
                for(int j=1; j<2; j++)
                {
                    book[i, j] = 5;
                }
            }
        }
    }
}
public interface Lib
{
    bool searchB(string s);
    void borrow(String bor, DateTime t);
    void returnBook(string s);
    void Details();
}
class Faculty : LibraryBooks, Lib
{
    public Faculty() : base()
    {
        bksBorrowed = 0;
        for(int i=0; i<3; i++)
        {
            for(int j=0; j<2; j++)
            {
                bookIssue[i, j] = 0;
            }
        }
        
    }
    public bool searchB(string s)
    {
        bool a = true;
        for (int i=0; i<5; i++)
        {
            for(int j=0; j<1; j++)
            {
                String ff = book[i, j].ToString();
                if (ff.Equals(s))
                {
                    a = true;
                    return a;
                }
                else
                    a = false;

            }
        }
        return a;

    }
    public void borrow(string bor, DateTime t)
    {
        if (bor.Equals("b"))
        {
            Console.WriteLine("You cannot brrow this book");
            return;

        }
        if (this.bksBorrowed < 5)
        {
            bookIssue[this.bksBorrowed, 0] = bor;
            bookIssue[this.bksBorrowed, 1] = t;
            this.bksBorrowed++;
        }
        else
        {
            Console.WriteLine("Sorry, you are not eligible");
        }
    }
    public void returnBook(string s)
    {
        for (int i=0; i<5; i++)
        {
            for(int j=0; j<1; j++)
            {
                if (book[i, j].Equals(s))
                {
                    book[i, j + 1] = (int)book[i, j + 1] + 1;
                }
            }
      
        }
    for(int i=0; i<this.bksBorrowed; i++)
        {
            for (int j=0; j<1; j++)
            {
                if (this.bookIssue[i, j].Equals(s))
                {
                    TimeSpan? f;

                    f = DateTime.Today - (DateTime)this.bookIssue[i, j + 1];
                    if (f?.TotalDays > 365)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Your penalty is: " + f?.TotalDays * 2);
                        Console.WriteLine("");
                    }
                }
            }
        
        }
        bksBorrowed--;
    }
    public void Details()
    {
        Console.WriteLine("Name" + "  " + "Issue Date");
        for(int i=0; i<this.bksBorrowed; i++)
        {
            for(int j=0; j<2; j++)
            {
                Console.Write(this.bookIssue[i, j] + " " + "  ");

            }
            Console.WriteLine();
        }
    }
public void renew(string k)
    {
        for(int i=0; i<this.bksBorrowed; i++)
        {
            for(int j=0; j<1; j++)
            {
                if (bookIssue[i, j].Equals(k))
                {
                    bookIssue[i, j + 1] = DateTime.Today;
                }
            }
        }
        Console.WriteLine("Book has been renewed");
    }
}
sealed class Admin : LibraryBooks
{
    public int facNo;
    public int StuNo;
    public Admin()
    {
        facNo = 0;
        StuNo = 0;
    }
    String[,] fname = new string[5, 2];
    String[,] sname = new string[5, 2];
    public void createFaculty(String name, String pwd)
    {
        for (int i = 0; i <= this.facNo; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                this.fname[i, j] = name;

            }
            for (int j = 1; j < 2; j++)
            {
                this.fname[i, j] = pwd;
            }
        }

    }
    public void createStudent(String name, String pawd)
    {
        for (int i = 0; i <= this.StuNo; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                this.sname[i, j] = name;
            }
            for (int j = 1; j < 2; j++)
            {
                this.sname[i, j] = pawd;
            }
        }
    }
    public int facchk(String n, String p)
    {
        int dla = 0;
        if (this.facNo == 0)
        {
            return 2;
        }
        else
        {
            for (int i = 0; i < this.facNo; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    string ko = this.fname[i, j];
                    if (ko.Equals(n))
                    {
                        dla = 1;
                        if (this.fname[i, j + 1].Equals(p))
                        {
                            return 1;
                        }
                    }
                }
            }
        }
        if (dla == 0)
            return 2;
        else
            return 0;
    }
    public int Stuchk(String n, String p)
    {
        int dla = 0;
        if (this.StuNo == 0)
        {
            return 2;
        }
        else
        {
            for (int i = 0; i < StuNo; i++)
            {
                for (int j = 0; j < StuNo; j++) // pakeiciau is i i j!!!!!
                {
                    if (this.sname[i, j].Equals(n))
                    {
                        dla = 1;
                        if (this.sname[i, j + 1].Equals(n))
                        {
                            return 1;
                        }
                    }
                }
            }
        }
        if (dla == 0)
            return 2;
        else
            return 0;
    }
    public void viewfac()
    {
        Console.WriteLine("Name " + "    " + "Password");
        for (int i = 0; i < this.facNo; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine(this.fname[i, j] + "          ");
            }
            Console.WriteLine(" ");
        }

    }
    public void viewStu()
    {
        Console.WriteLine("Name" + "     " + "Pasword");
        for (int i = 0; i < this.StuNo; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine(this.sname[i, j] + "    ");
            }
            Console.WriteLine(" ");
        }
    }
    public override void catalogue()
    {
        String ans = "yes";
        do
        {
            Console.WriteLine("1. View Books");
            Console.WriteLine("2. Add Books");
            Console.WriteLine("3. Delete Books");
            Console.WriteLine("4. Return to main menu");
            Console.WriteLine("Please enter your choice");
            Console.WriteLine("      ");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("Book Name" + "   " + "Available copies");
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 2; j++)
                        {
                            Console.Write(this.book[i, j]);
                        }
                    Console.WriteLine("");
                    break;


                case 2:
                    Console.WriteLine("Enter the name of the book");
                    String sn = Console.ReadLine();
                    Console.WriteLine("Enter the no. of copies you want to add");
                    int ner = int.Parse(Console.ReadLine());
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            String sd = book[i, j].ToString();
                            if (sd.Equals(sn))
                            {
                                book[i, j + 1] = (int)book[i, j + 1] + ner;
                                break;
                            }
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the name of the books");
                    String sn1 = Console.ReadLine();
                    Console.WriteLine("Enter the no. of copies you want to remove");
                    int n2 = int.Parse(Console.ReadLine());
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 1; j++)
                        {
                            String sd = book[i, j].ToString();
                            if (sd.Equals(sn1))
                            {
                                book[i, j + 1] = (int)book[i, j + 1] - n;
                                break;
                            }
                        }
                    }
                    break;
                case 4:
                    return;

            }
        } while (ans.Equals("yes"));
    }
    class Student : LibraryBooks, Lib
    {
        public Student() : base()
        {
            bksBorrowed = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    bookIssue[i, j] = 0;
                }
            }
        }
        public bool searchB(string s)
        {
            bool a = true;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    String ff = book[i, j].ToString();
                    if (ff.Equals(s))
                    {
                        a = true;
                        return a;
                    }
                    else
                        a = false;
                }
            }
            return a;
        }
        public void borrow(String bor, DateTime t)
        {
            if (bor.Equals("b"))
            {
                Console.WriteLine("Sorrry this book only for reference");
                return;
            }
            Console.WriteLine(this.bksBorrowed);
            if (this.bksBorrowed < 2)
            {
                bookIssue[this.bksBorrowed, 0] = bor;
                bookIssue[this.bksBorrowed, 1] = t;
                this.bksBorrowed++;
            }
            else
            {
                Console.WriteLine("Sorry you cannot borrow anymore books");
                Console.WriteLine("");
            }
        }
        public void returnBook(string s)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (book[i, j].Equals(s))
                    {
                        book[i, j + 1] = (int)book[i, j + 1] + 1;
                    }
                }
            }
            for (int i = 0; i < this.bksBorrowed; i++)
            {
                for (int J = 0; J < this.bksBorrowed; J++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        if (this.bookIssue[i, j].Equals(s))
                        {
                            TimeSpan? f;
                            f = DateTime.Today - (DateTime)this.bookIssue[i, j + 1];
                            if (f?.TotalDays > 15)
                            {
                                Console.WriteLine("Your penalty is: " + f?.TotalDays * 2);
                                Console.WriteLine(" ");
                            }
                        }
                    }

                }
                bksBorrowed--;
            }

        } public void Details()
        {
            Console.WriteLine("Name " + "  " + "Issue Date");
            for (int i = 0; i < this.bksBorrowed; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(this.bookIssue[i, j] + "    " + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(" ");
        }
        class Program
        {
            static void Main(String[] args)
            {
                String ans = "yes";
                Admin ade = new Admin();
                do
                {
                    Console.WriteLine("WELCOME TO BOOK LIBRARY");
                    Console.WriteLine("Please login into the any of the following acounts: ");
                    Console.WriteLine("1. Admin");
                    Console.WriteLine("2. Faculty");
                    Console.WriteLine("3. Student");
                    Console.WriteLine("Note: PLEASE ENTER YOUR CHOISE ACCORDINGLY");

                    Console.WriteLine("");
                    Console.WriteLine("");
                    int ch = int.Parse(Console.ReadLine());
                    Program p = new Program();
                    switch (ch)
                    {
                        case 1:
                            p.adm(ade);
                            break;
                        case 2:
                            Console.WriteLine("Please enter your name");
                            String name = Console.ReadLine();
                            Console.WriteLine("Please enter your password");
                            String pwd = Console.ReadLine();
                            int w = ade.facchk(name, pwd);
                            if (w == 1)
                                p.fac(ade);
                            else if (w == 2)
                            {
                                Console.WriteLine("NEW USER");
                                ade.createFaculty(name, pwd);
                                p.fac(ade);
                            }
                            else
                                Console.WriteLine("Wrong password or username");
                            break;
                        case 3:
                            Console.WriteLine("Please enter your name");
                            String nam = Console.ReadLine();
                            Console.WriteLine("Please enter your password");
                            String pw = Console.ReadLine();
                            int b = ade.Stuchk(nam, pw);
                            if (b == 1)
                                p.Stu(ade);
                            else if (b == 2)
                            {
                                Console.WriteLine("New user");
                                ade.createStudent(nam, pw);
                                p.Stu(ade);
                            }
                            else
                                Console.WriteLine("Sorry!! Wrong password or username");
                            break;
                        default:
                            Console.WriteLine("Please enter a valid choice");
                            break;
                    }
                    Console.WriteLine("Do you want to continue?");
                    ans = Console.ReadLine();
                } while (ans.Equals("yes"));
            }
        }
        public void fac(Admin ade)
        {
            String ans = "yes";
            Faculty f = new Faculty();
            ade.facNo += 1;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Please make a choice from the following");
                Console.WriteLine("1.Search books");
                Console.WriteLine("2. Return books");
                Console.WriteLine("3. Borrow books");
                Console.WriteLine("4. Renew a book");
                Console.WriteLine("5. View book issue details");
                Console.WriteLine("6. Return to main menu");
                Console.WriteLine("");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        Console.WriteLine("Enter name of the book");
                        string name = Console.ReadLine();
                        bool p = f.searchB(name);
                        if (p == true)
                            Console.WriteLine("Book found!");
                        else
                            Console.WriteLine("Book not found!");
                        break;
                    case 2:
                        Console.WriteLine("Enter the book you want to return");
                        String g = Console.ReadLine();
                        f.returnBook(g);
                        break;
                    case 3:
                        Console.WriteLine("Enter the name of the book");
                        string y = Console.ReadLine();
                        Console.WriteLine("Enter the issue date");
                        DateTime t = Convert.ToDateTime(Console.ReadLine());
                        f.borrow(y, t);
                        break;
                    case 4:
                        Console.WriteLine("Enter book to renew");
                        string k = Console.ReadLine();
                        f.renew(k);
                        break;
                    case 5:
                        f.Details();
                        break;
                    case 6:
                        return;
                }
                Console.WriteLine("Do you want to Continue?");
                ans = Console.ReadLine();

            } while (ans.Equals("yes"));
        }
    

        public void Stu(Admin ade)
            {
                String ans = "yes";
                ade.StuNo++;
        Student 1 = new Student();

                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("Please make a choice from the following");
                    Console.WriteLine("1. Search books");
                    Console.WriteLine("2. Return books");
                    Console.WriteLine("3. Borrow books");
                    Console.WriteLine("4. Renew a book");
                    Console.WriteLine("5. View book issue details");
                    Console.WriteLine("6. Return to main menu");
                    Console.WriteLine("");
                    int ch = int.Parse(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Console.WriteLine("Enter name of the book");
                            string name = Console.ReadLine();
                            bool p = f.searchB(name);
                            if (p == true)
                                Console.WriteLine("Book found!");
                            else
                                Console.WriteLine("Book not found!");
                            break;
                        case 2:
                            Console.WriteLine("Enter the book you want to return");
                            String g = Console.ReadLine();
                            f.returnBook(g);
                            break;
                        case 3:
                            Console.WriteLine("Enter the name of the book");
                            string y = Console.ReadLine();
                            Console.WriteLine("Enter the issue date");
                            DateTime t = Convert.ToDateTime(Console.ReadLine());
                            f.borrow(y, t);
                            break;
                        case 4:
                            Console.WriteLine("Enter book to renew");
                            string k = Console.ReadLine();
                            f.renew(k);
                            break;
                        case 5:
                            f.Details();
                            break;
                        case 6:
                            return;
                    }
                    Console.WriteLine("Do you want to Continue?");
                    ans = Console.ReadLine();

                } while (ans.Equals("yes"));

            }
        }
    