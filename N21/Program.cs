using N21;

var Admin = new User("falonchi", "f1357", 1, "falonchi@gmail.com");
var taskManagerService = new TaskManagerSystem();
while (true)
{
    Console.Write("Kirish - k\nChiqish - c\n=> ");
    var k = Convert.ToByte(Console.ReadKey());
    if (k == 'k')
    {
        if (Admin.RoleId == 1)
        {
            Console.Write("Buyruqni tanlang:" +
                "\n\tProject yaratish - 1" +
                "\n\tTask yaratish - 2" +
                "\n\tUser yaratish - 3" +
                "\n\tNotification yaratish - 4\n-> ");
            var buyruq = Convert.ToInt32(Console.ReadLine());
            switch (buyruq)
            {
                case 1:

                    //taskManagerService.CreateProject();
                    break;

            }
        }
    }
    else if (k == 'c')
    {
        break;
    }
    else
    {
        Console.WriteLine("Xato buyruq!");
    }
}
