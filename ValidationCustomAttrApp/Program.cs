using System;
using System.Reflection;
using System.Text.Json;
using ValidationCustomAttrApp.Models;

[assembly: AssemblyDescription("This description is self-descriptive!")]

namespace ValidationCustomAttrApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new();
            Department dept = new();

            Type employeeType = typeof(Employee);
            Type departmentType = typeof(Department);

            if (GetInput(employeeType, "Please enter the employee's id", "Id", out string empId))
            {
                emp.Id = Int32.Parse(empId);
            }
            if (GetInput(employeeType, "Please enter the employee's first name", "FirstName", out string firstName))
            {
                emp.FirstName = firstName;
            }
            if (GetInput(employeeType, "Please enter the employee's post code", "PostCode", out string postCode))
            {
                emp.PostCode = postCode;
            }
            if (GetInput(departmentType, "Please enter the employee's department code", "DeptShortName", out string deptShortName))
            {
                dept.DeptShortName = deptShortName;
            }

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Thank you! Employee with first name, {emp.FirstName}, and Id, {emp.Id}, has been entered successfully!!");
            Console.ResetColor();

            Console.ReadKey();

            var employeeJSON = JsonSerializer.Serialize(emp);

            Console.WriteLine(employeeJSON);

            Console.ReadKey();
        }

        private static bool GetInput(Type t, string promptText, string fieldName, out string fieldValue)
        {
            fieldValue = "";
            string enteredValue = "";
            string errorMessage = null;

            do
            {
                Console.WriteLine(promptText);

                enteredValue = Console.ReadLine();

                if (!Validation.PropertyValueIsValid(t, enteredValue, fieldName, out errorMessage))
                {
                    fieldValue = null;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(errorMessage);
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    fieldValue = enteredValue;
                    break;
                }
            }
            while (true);

            return true;
        }

        private static void OutputGlobalAttributeInformation()
        {
            Assembly thisAssem = typeof(Program).Assembly;

            AssemblyName thisAssemName = thisAssem.GetName();

            Version thisAssemVersion = thisAssemName.Version;

            object[] attributes = thisAssem.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

            Console.WriteLine($"Assembly Name: {thisAssemName}");
            Console.WriteLine($"Assembly Version: {thisAssemVersion}");

            if (attributes[0] is AssemblyDescriptionAttribute thisAssemDescriptionAttribute)
                Console.WriteLine($"Assembly Description: {thisAssemDescriptionAttribute.Description}");
        }
    }
}