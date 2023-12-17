
using System;


interface IDataFormatPrototype
{
    void ExportData();
}


class CSVDataFormat : IDataFormatPrototype
{
    public void ExportData()
    {
        Console.WriteLine("Експорт даних в CSV форматі");
        
    }
}


class XMLDataFormat : IDataFormatPrototype
{
    public void ExportData()
    {
        Console.WriteLine("Експорт даних в XML форматі");
        
    }
}


class JSONDataFormat : IDataFormatPrototype
{
    public void ExportData()
    {
        Console.WriteLine("Експорт даних в JSON форматі");
       
    }
}


class DataFormatAdapter : IDataFormatPrototype
{
    private readonly IDataFormatPrototype _dataFormatPrototype;

    public DataFormatAdapter(IDataFormatPrototype dataFormatPrototype)
    {
        _dataFormatPrototype = dataFormatPrototype;
    }

    public void ExportData()
    {
       
        Console.WriteLine("Адаптація даних перед експортом");
        _dataFormatPrototype.ExportData();
    }
}


class Program
{
    static void Main(string[] args)
    {
       
        string sourceFormat = "CSV";
        string targetFormat = "XML";
        
        
        IDataFormatPrototype sourceFormatPrototype;
        IDataFormatPrototype targetFormatPrototype;

        if (sourceFormat == "CSV")
            sourceFormatPrototype = new CSVDataFormat();
        else if (sourceFormat == "XML")
            sourceFormatPrototype = new XMLDataFormat();
        else if (sourceFormat == "JSON")
            sourceFormatPrototype = new JSONDataFormat();
        else
            throw new ArgumentException("Непідтримуваний формат вихідних даних");

        if (targetFormat == "CSV")
            targetFormatPrototype = new CSVDataFormat();
        else if (targetFormat == "XML")
            targetFormatPrototype = new XMLDataFormat();
        else if (targetFormat == "JSON")
            targetFormatPrototype = new JSONDataFormat();
        else
            throw new ArgumentException("Непідтримуваний формат цільових даних");

        
        IDataFormatPrototype adapter = new DataFormatAdapter(sourceFormatPrototype);
        adapter.ExportData();

        
        targetFormatPrototype.ExportData();
    }
}