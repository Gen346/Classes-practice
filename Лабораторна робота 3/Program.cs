using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

class Program
{
    static List<Salary> employees = new List<Salary>();

    static void Main(string[] args) 
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add a new salary");
            Console.WriteLine("2. Show salary information");
            Console.WriteLine("3. Load data from file");
            Console.WriteLine("4. Clear file");
            Console.WriteLine("5. Exit the program");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewSalary();
                    break;
                case "2":
                    ShowSavedData();
                    break;
                case "3":
                    LoadDataFromFile();
                    break;
                case "4":
                    ClearXmlFile();
                    break;
                case "5": 
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddNewSalary()
    {
        Salary salary = new Salary();

        Console.WriteLine("Enter full name:");
        salary.FullName = Console.ReadLine();

        Console.WriteLine("Enter base salary:");
        salary.BaseSalary = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter hire year:");
        salary.HireYear = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter bonus percentage:");
        salary.BonusPercentage = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter worked days:");
        salary.WorkedDays = Convert.ToDouble(Console.ReadLine());

        salary.CalculateAccruedAmount();
        salary.CalculateWithheldSalary();
        salary.CalculateExperience();
        employees.Add(salary);
        SaveAllToXml();
        Console.Clear();
        Console.WriteLine("Salary added successfully!");
        Thread.Sleep(1000);
        Console.Clear();

    }

    static void ShowSavedData()
    {
        Console.Clear();
        foreach (var salary in employees)
        {
            Console.WriteLine(salary.ToString());
        }
        Console.WriteLine("Press any button button to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    static void SaveAllToXml()
    {
        Console.Clear();
        XmlSerializer serializer = new XmlSerializer(typeof(List<Salary>));
        using (StreamWriter writer = new StreamWriter("data.xml"))
        {
            serializer.Serialize(writer, employees);
        }
        Console.WriteLine("All employees data saved to file successfully.");
        Thread.Sleep(1000);
        Console.Clear();
    }

    static void LoadDataFromFile()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Salary>));
        using (StreamReader reader = new StreamReader("data.xml"))
        {
            List<Salary> loadedEmployees = (List<Salary>)serializer.Deserialize(reader);
            employees.AddRange(loadedEmployees);
            Console.Clear();
            Console.WriteLine("Salary information loaded successfully.");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }

    static void ClearXmlFile()
    {
        string fileName = "data.xml";
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
            Console.Clear();
            Console.WriteLine("XML file cleared successfully!");
            Thread.Sleep(1000);
            Console.Clear();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("XML file not found!");
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}