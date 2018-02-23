using System;

namespace ReportGenerator
{
    internal class ReportGeneratorClient
    {
        private static void Main()
        {
            var db = new EmployeeDB();

            // Add some employees
            db.AddEmployee(new Employee("Anne", 3000));
            db.AddEmployee(new Employee("Berit", 2000));
            db.AddEmployee(new Employee("Christel", 1000));

            var reportGenerator = new ReportGenerator(db);
            var reportPrinter = new ReportPrint();

            // Create a default (name-first) report
            reportPrinter.PrintReportToConsole(reportGenerator.CompileReport());

            Console.WriteLine("");
            Console.WriteLine("");

            // Create a salary-first report
            reportPrinter.SetOutputFormat(ReportOutputFormatType.SalaryFirst);
            reportPrinter.PrintReportToConsole(reportGenerator.CompileReport());
        }
    }
}