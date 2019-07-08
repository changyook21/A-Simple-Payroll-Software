using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_simple_Payroll_Software
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            int year = 0;
            int month = 0;

            try
            {
                while (year == 0)
                {
                    Console.WriteLine("\nPlease enter the year: ");
                    year = Convert.ToInt32(Console.ReadLine());
                }

                while (month == 0)
                {
                    Console.WriteLine("\nPlease enter the month: ");
                    
                    month = Convert.ToInt32(Console.ReadLine());

                    if (month < 1 && month > 12)
                    {
                        month = 0;
                        Console.WriteLine("Re-enter a valid month");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine("Enter hours worked for {0}", myStaff[i].NameOfStaff);

                    int hours = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].HoursWorked = hours;

                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    i--;
                }
            }
            PaySlip ps = new PaySlip(month, year);

            ps.GeneratePaySlip(myStaff);

            ps.GenerateSummary(myStaff);

            Console.Read();

        }
    }
}
