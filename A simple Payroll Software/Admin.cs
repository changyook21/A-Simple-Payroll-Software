using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_simple_Payroll_Software
{
    class Admin : Staff
    {
        private const float overTimeRate = 15.5F;
        private const float adminHourlyRate = 30;

        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate)
        {

        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
            {
                Overtime = overTimeRate * (HoursWorked - 160);
            }
        }
        public override string ToString()
        {
            return "Total Pay: " + TotalPay + "Basic Pay: " + BasicPay + "Name of Staff: " + NameOfStaff;
        }
    }
}
