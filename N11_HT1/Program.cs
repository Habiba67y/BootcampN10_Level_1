using System.Data;
var tdl = new ToDoList();
while (true)
{
    Console.Write("\nChoose a command:\n\ndisplay all - d\nmark done - m\nadd - a\nexit - e\n\n=> ");
    char command = char.Parse(Console.ReadLine());
    switch (command)
    {
        case 'd':
            tdl.Display(tdl.listToDo);
            break;
        case 'm':
            tdl.MarkDone(tdl.listToDo);
            break;
        case 'a':
            Console.Write("Task name: ");
            var tn = Console.ReadLine();
            var td = new ToDo()
            {
                taskName = tn,
            };
            tdl.Add(td);
            break;
    }
    if(command == 'e')
    {
        break;
    }
}
public class ToDoList
{
    public List<ToDo> listToDo = new List<ToDo>();
    public void Display(List<ToDo> listToDo)
    {
        if (listToDo.Count != 0)
        {
            for (int i = 0; i < listToDo.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {listToDo[i].taskName}");
            }
        }
        else
        {
            Console.WriteLine("There is not any task");
        }
    }
    public void MarkDone(List<ToDo> listToDo)
    {
        Console.WriteLine("Choose which task: ");
        Display(listToDo);
        while (true)
        {
            try
            {
                Console.Write("=> ");
                var choose = Console.ReadLine();
                if (int.TryParse(choose, out var c))
                {
                    if (c > listToDo.Count())
                    {
                        throw new ArgumentOutOfRangeException("Wrong choice");
                    }
                    Console.WriteLine($"Task \"{listToDo[c - 1].taskName}\" masked as done");
                    listToDo[c - 1].isDone = true;
                    break;
                }
                else
                {
                    throw new FormatException("Not a number!");
                }
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                Console.WriteLine(argumentOutOfRangeException);
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
    public void Add(ToDo task)
    {
        listToDo.Add(task);
    }
}
public class ToDo
{
    public string taskName { get; set; }
    public bool isDone = false;
}
