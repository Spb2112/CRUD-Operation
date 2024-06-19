
using CRUD_OPERATION.Entities;
using CRUD_OPERATION;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

class Program
{
    static void Main(string[] args)
    {
        string message = "Hello World!!";

        Console.WriteLine(message);
        TestDatabase();
    }

    public static void TestDatabase()
    {

        var context = new DataContext();
        var repo = new Repo(context);


        var user1 = new User
        {
            Name = "SAHIL",
            Email = "sahil@example.com",
            PhoneNumber = "888-237-4567"
        };
        repo.Create<User>(user1);
        repo.CommitTransacton();

        List<User> users = repo.GetAll<User>();

        Console.WriteLine("User List");
        foreach (User user in users)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}, PhoneNumber: {user.PhoneNumber}");
        }



        user1.Name = "Kathiyavaad";
        user1.Email = "jeel@gmail.com";
        repo.Update<User>(user1);
        repo.CommitTransacton();

        List<User> users1 = repo.GetAll<User>();

        Console.WriteLine("User List");
        foreach (User user in users1)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}, PhoneNumber: {user.PhoneNumber}");
        }


        repo.Delete<User>(1);
        repo.CommitTransacton();
        List<User> users2 = repo.GetAll<User>();

        Console.WriteLine("User List");
        foreach (User user in users2)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Email: {user.Email}, PhoneNumber: {user.PhoneNumber}");
        }


    }
}