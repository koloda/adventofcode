using Gtk;

namespace Adventofcode.GUI;

class MainWindow : Window
{
    private List<string> taskClasses;

    public MainWindow(List<string> taskClassesArg): base("Advent of Code")
    {
        taskClasses = taskClassesArg;

        SetDefaultSize(800, 600);
        SetPosition(WindowPosition.Center);
        DeleteEvent += delegate { Application.Quit(); };

        var grid = new Grid();
        // full window
        grid.ColumnHomogeneous = true;
        grid.RowHomogeneous = true;

        var sidebar = ComposeSidebar();
        grid.Attach(sidebar, 0, 0, 1, 1);

        var stack = sidebar.Stack;
        grid.Attach(stack, 1, 0, 1, 1);

        Add(grid);

        ShowAll();
    }

    private StackSidebar ComposeSidebar()
    {
        var sidebar = new StackSidebar();

        // add a stack
        var stack = new Stack();

        foreach (var taskClass in taskClasses)
        {
            stack.AddTitled(TaskUI(taskClass), taskClass, taskClass);
        }

        sidebar.Stack = stack;

        return sidebar;
    }

    private Widget TaskUI(string taskClass)
    {
        switch (taskClass)
        {
            case "ColumnDistanceCalculator":
                return new FileChoseAndCalcUI(taskClass, "Column Distance Calculator");
            case "ColumnSimilarityCalculator":
                return new FileChoseAndCalcUI(taskClass, "Column Similarity Calculator");

            default:
                return new Label("Task not implemented");
        }
    }
}