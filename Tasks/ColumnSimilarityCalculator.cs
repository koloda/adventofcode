using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Adventofcode;

namespace Adventofcode.Tasks;

public class ColumnSimilarityCalculator: ITaskInterface, IWorksWithTwoColumnsInterface
{
    private List<int> firstColumn = new List<int>();
    private List<int> secondColumn = new List<int>();

    int totalSimilarity = 0;

    public void SetColumns(List<int> firstColumn, List<int> secondColumn)
    {
        this.firstColumn = firstColumn;
        this.secondColumn = secondColumn;
    }

    public void Run()
    {
        totalSimilarity = CalculateTotalSimilarity();
    }

    public string GetResult()
    {
        return totalSimilarity.ToString();
    }

    public void PrintResult()
    {
        PrintTotalSimilarity();
    }

    private int CalculateTotalSimilarity()
    {
        int totalSimilarity = 0;

        for (int i = 0; i < firstColumn.Count; i++)
        {
            int id = firstColumn[i];
            int count = secondColumn.Count(x => x == id);

            totalSimilarity += id * count;
        }

        return totalSimilarity;
    }

    private void PrintTotalSimilarity()
    {
        Console.WriteLine("Total similarity between columns: " + totalSimilarity);
    }
}