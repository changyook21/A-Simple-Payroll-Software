using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A_simple_Payroll_Software
{
    class PaySlip
    {
        private int month;
        private int year;
        enum MonthsOfYear { JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEPT, OCT, NOV, DEC };

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach(Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                if (f.GetType().ToString() == "Manager")
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear) month, year);
                        sw.WriteLine("======================");
                        sw.WriteLine(" Name of Staff: " + f.NameOfStaff);
                        sw.WriteLine(" Hours Worked: " + f.HoursWorked);
                        sw.WriteLine(" Basic Pay: {0: C} ", f.BasicPay);
                        sw.WriteLine(" Allowance: " + ((Manager)f).Allowance);
                        sw.WriteLine("======================");
                        sw.WriteLine(" Total Pay: " + f.TotalPay);
                        sw.WriteLine("======================");
                        
                    }
                    sw.Close();

                }

                if (f.GetType().ToString() == "Admin")
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                        sw.WriteLine("======================");
                        sw.WriteLine(" Name of Staff: " + f.NameOfStaff);
                        sw.WriteLine(" Hours Worked: " + f.HoursWorked);
                        sw.WriteLine(" Basic Pay: {0: C}", f.BasicPay);
                        sw.WriteLine(" Overtime pay: " + ((Admin)f).Overtime);
                        sw.WriteLine("======================");
                        sw.WriteLine(" Total Pay: " + f.TotalPay);
                        sw.WriteLine("======================");
                        
                    }
                    sw.Close();
                }

            }

        }
        public void GenerateSummary(List<Staff> myStaff)
        {
            var lessThan10 =
                from i in myStaff
                orderby i.NameOfStaff ascending
                where i.HoursWorked < 10
                select new { i.NameOfStaff, i.HoursWorked };

            string path = "summary.txt";

            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                
                foreach( var workers in lessThan10)
                {
                    sw.WriteLine("Name of Staff {0}, Hours Worked: {1}", workers.NameOfStaff, workers.HoursWorked);
                }
                sw.Close();
            }

        }
    }
}
