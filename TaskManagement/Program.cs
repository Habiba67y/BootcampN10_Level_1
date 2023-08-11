using TaskManagement.Model;
using TaskManagement.Service;

public static class Program
{
    static ProjectManager user1 = new ProjectManager("admin", "admin");
    static Developer user2 = new Developer("user", "user");
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Task Management Service!");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            int result = TaskManagerSystem.AuthenticateUser(username, password, user1);
            
            if(result == (int)UserRole.ProjectManager)
            {

            }

        }
    }
}