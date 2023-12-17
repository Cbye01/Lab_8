using System;


public interface IChart
{
    void Draw();
}


public class LineChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing a line chart...");
    }
}


public class BarChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing a bar chart...");
    }
}


public class PieChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing a pie chart...");
    }
}


public class GraphFactory
{
    public IChart CreateChart(string chartType)
    {
        switch (chartType.ToLower())
        {
            case "line":
                return new LineChart();
            case "bar":
                return new BarChart();
            case "pie":
                return new PieChart();
            default:
                throw new ArgumentException("Invalid chart type");
        }
    }
}


public class VisualizationApp
{
    private GraphFactory graphFactory;

    public VisualizationApp()
    {
        graphFactory = new GraphFactory();
    }

    public void Run()
    {
        Console.WriteLine("Enter the chart type (line, bar, pie):");
        string chartType = Console.ReadLine();

        Console.WriteLine("Enter data for visualization:");
        string data = Console.ReadLine();

        // Create the chart using the factory
        IChart chart = graphFactory.CreateChart(chartType);

        // Visualize the chart
        chart.Draw();
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        VisualizationApp app = new VisualizationApp();
        app.Run();
    }
}