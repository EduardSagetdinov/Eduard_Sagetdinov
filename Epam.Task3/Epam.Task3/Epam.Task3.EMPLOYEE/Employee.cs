using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task3.USER;

namespace Epam.Task3.EMPLOYEE
{
    public class Employee : User
    {
        private int a;

        public Employee(string sn, string n, string patr, string db, string pos, string ex)
            : base(sn, n, patr, db)
        {
            base.Test(ref pos);
            this.Position = pos;
            this.Test(ex);
            this.Experience = ex;
        }

        public string Position { get; set; }

        public string Experience { get; set; }

        public void Test(string ex)
        {
            if (!int.TryParse(ex, out this.a))
            {
                throw new Exception("Wrong data!");
            }

            if (this.a > this.Age - 16)
            {
                throw new Exception("It is not your experience!");
            }
        }
    }
}
