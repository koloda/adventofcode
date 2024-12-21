using System;
using System.Collections.Generic;
using System.IO;
using Adventofcode;

namespace Adventofcode.Tasks;

public class ColumnDistanceCalculator: ITaskInterface, IWorksWithTwoColumnsInterface
{
    private List<int> firstColumn = new List<int>();
    private List<int> secondColumn = new List<int>();
    private int totalDistance = 0;

    public void SetColumns(List<int> firstColumn, List<int> secondColumn)
    {
        this.firstColumn = firstColumn;
        this.secondColumn = secondColumn;
    }

    public void Run()
    {
        ReadAndProcessInput();
        totalDistance = CalculateTotalDistance();
    }

    public string GetResult()
    {
        return totalDistance.ToString();
    }

    public void PrintResult()
    {
        PrintTotalDistance();
    }

    private void ReadAndProcessInput()
    {
        firstColumn.Sort();
        secondColumn.Sort();
    }

    private int CalculateTotalDistance()
    {
        int totalColumnsDistance = 0;

        for (int i = 0; i < firstColumn.Count; i++)
        {
            totalColumnsDistance += Math.Abs(firstColumn[i] - secondColumn[i]);
        }

        return totalColumnsDistance;
    }

    private void PrintTotalDistance()
    {
        Console.WriteLine("Total distance between columns: " + totalDistance);
    }
}
