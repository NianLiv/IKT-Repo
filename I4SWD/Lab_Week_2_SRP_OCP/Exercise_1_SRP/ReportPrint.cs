using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerator
{

    public enum ReportOutputFormatType
    {
        NameFirst,
        SalaryFirst
    }

    internal class ReportPrint
    {
        private ReportOutputFormatType _currentOutputFormat;

        public ReportPrint()
        {
            _currentOutputFormat = ReportOutputFormatType.NameFirst;
        }

        public void PrintReportToConsole(List<Employee> employees)
        {
            // All employees collected - let's output them
            switch (_currentOutputFormat)
            {
                case ReportOutputFormatType.NameFirst:
                    Console.WriteLine("Name-first report");
                    foreach (var e in employees)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("------------------");
                    }
                    break;

                case ReportOutputFormatType.SalaryFirst:
                    Console.WriteLine("Salary-first report");
                    foreach (var e in employees)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("------------------");
                    }
                    break;

                default:
                    break;
            }
        }

        public void PrintReportToDebug(List<Employee> employees)
        {
            // All employees collected - let's output them
            switch (_currentOutputFormat)
            {
                case ReportOutputFormatType.NameFirst:
                    Debug.WriteLine("Name-first report");
                    foreach (var e in employees)
                    {
                        Debug.WriteLine("------------------");
                        Debug.WriteLine("Name: {0}", e.Name);
                        Debug.WriteLine("Salary: {0}", e.Salary);
                        Debug.WriteLine("------------------");
                    }
                    break;

                case ReportOutputFormatType.SalaryFirst:
                    Debug.WriteLine("Salary-first report");
                    foreach (var e in employees)
                    {
                        Debug.WriteLine("------------------");
                        Debug.WriteLine("Salary: {0}", e.Salary);
                        Debug.WriteLine("Name: {0}", e.Name);
                        Debug.WriteLine("------------------");
                    }
                    break;

                default:
                    break;
            }
        }

        public void SetOutputFormat(ReportOutputFormatType format)
        {
            _currentOutputFormat = format;
        }
    }
}