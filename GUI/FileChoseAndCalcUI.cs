using Gtk;

namespace Adventofcode.GUI;

class FileChoseAndCalcUI : Box
{
    protected string labelText;
    protected Label label;
    protected Label inputLabel;
    protected Button calculateButton;
    protected string? inputPath;
    protected string? taskClass;
    protected string? result;
    protected Label resultLabel;

    public FileChoseAndCalcUI(string taskClassArg, string labelTextArg = "Column Distance Calculator")
    {
        taskClass = taskClassArg;
        labelText = labelTextArg;
        // box padding and spacing
        Margin = 10;
        Spacing = 10;
        // vertical box
        Orientation = Orientation.Vertical;

        label = new Label(labelText);
        Add(label);

        // open file dialog
        var openButton = new Button("Open file");
        openButton.Clicked += OpenButtonClicked;
        Add(openButton);

        // print file path
        inputLabel = new Label("Input file: " + inputPath);
        Add(inputLabel);

        // separator and spacing
        var separator = new Separator(Orientation.Horizontal);
        separator.MarginTop = 10;
        separator.MarginBottom = 10;
        Add(separator);

        // calculate button and result label
        calculateButton = new Button("Calculate");
        // disable the button if no input file is selected
        calculateButton.Sensitive = false;
        calculateButton.Clicked += CalculateButtonClicked;
        Add(calculateButton);

        resultLabel = new Label("Result: ");
        Add(resultLabel);
    }

    private void OpenButtonClicked(object sender, EventArgs e)
    {
        var dialog = new FileChooserDialog("Select input file", null, FileChooserAction.Open, "Cancel", ResponseType.Cancel, "Open", ResponseType.Accept);

        if (dialog.Run() == (int)ResponseType.Accept)
        {
            inputPath = dialog.Filename;
            dialog.Destroy();

            // update the label
            inputLabel.Text = "Input file: " + inputPath;
            // enable the calculate button
            calculateButton.Sensitive = true;
        }
    }

    private void CalculateButtonClicked(object sender, EventArgs e)
    {
        if (taskClass == null || inputPath == null)
        {
            return;
        }

        result = Program.RunAndReturnResult(taskClass, inputPath);

        // update the result label
        resultLabel.Text = "Result: " + result;
    }
}
