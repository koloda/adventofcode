using Adventofcode.Tasks;
using Adventofcode.GUI;
using Gtk;

namespace Adventofcode;

class Program
{
    private static readonly List<int> firstColumn = new List<int>();
    private static readonly List<int> secondColumn = new List<int>();
    private static string? inputPath;

    public static List<string> GetTaskClasses()
    {
        return [
          typeof(ColumnDistanceCalculator).Name,
        typeof(ColumnSimilarityCalculator).Name,
      ];
    }
    static void Main(string[] args)
    {
        Application.Init();
        new MainWindow(GetTaskClasses());
        Application.Run();

        int taskNumber;

        if (args.Length > 0)
        {
            taskNumber = ParseTaskNumber(args[0]);
        }
        else
        {
            Console.WriteLine("Please provide a task number");
            string? arg = Console.ReadLine();

            if (arg == null)
            {
                throw new Exception("Task number not provided");
            }

            taskNumber = ParseTaskNumber(arg);
        }

        var task = InstantiateTaskByNumber(taskNumber) as ITaskInterface;

        if (task == null)
        {
            throw new Exception("Task not instantiated");
        }

        ReadAndProcessInput();

        if (task is IWorksWithTwoColumnsInterface taskWithColumns)
        {
            taskWithColumns.SetColumns(firstColumn, secondColumn);
        }

        task.Run();
        task.PrintResult();
    }

    public static string RunAndReturnResult(string taskName, string inputPathArg)
    {
        var task = InstantiateTaskByName(taskName) as ITaskInterface;

        if (task == null)
        {
            throw new Exception("Task not instantiated");
        }

        inputPath = inputPathArg;

        ReadAndProcessInput();

        if (task is IWorksWithTwoColumnsInterface taskWithColumns)
        {
            taskWithColumns.SetColumns(firstColumn, secondColumn);
        }

        task.Run();

        return task.GetResult();
    }

    private static int ParseTaskNumber(string arg)
    {
        if (!int.TryParse(arg, out int taskNumber))
        {
            throw new Exception("Task number must be an integer");
        }

        return taskNumber;
    }

    public static Object InstantiateTaskByNumber(int taskNumber)
    {
        var taskClasses = GetTaskClasses();

        if (taskNumber < 0 || taskNumber >= taskClasses.Count)
        {
            throw new Exception("Task number out of range");
        }

        var taskClassName = taskClasses[taskNumber];

        return InstantiateTaskByName(taskClassName);
    }

    public static Object InstantiateTaskByName(string taskName)
    {
        var taskClass = Type.GetType("Adventofcode.Tasks." + taskName);

        if (taskClass == null)
        {
            throw new Exception("Task class not found");
        }

        var instance = Activator.CreateInstance(taskClass);

        if (instance == null)
        {
            throw new Exception("Task instance not created");
        }

        return instance;
    }

    private static void ReadAndProcessInput()
    {
        var lines = File.ReadLines(inputPath);

        foreach (var line in lines)
        {
            // each line is a string with two numbers separated by 1-4 spaces or tabs
            var lineParts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            firstColumn.Add(int.Parse(lineParts[0]));
            secondColumn.Add(int.Parse(lineParts[1]));
        }
    }

    public static void Quit()
    {
        Application.Quit();
    }
}