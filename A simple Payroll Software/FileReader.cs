using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A_simple_Payroll_Software
{
    class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", "};

            if (File.Exists(path))
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string current = sr.ReadLine();
                        result = current.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);

                        if (result[1].Equals("Manager"))
                        {
                            myStaff.Add(new Manager(result[0]));
                        }
                        if (result[1].Equals("Admin"))
                        {
                            myStaff.Add(new Admin(result[0]));
                        }
                    }
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
            return myStaff;
        }
    }
}
