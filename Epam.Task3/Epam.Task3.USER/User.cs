using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.USER
{
    public class User
    {
        private readonly DateTime now = DateTime.Now;

        public User(string sn, string n, string patr, string db)
        {
                this.Test(ref sn);
                this.Test(ref n);
                this.Test(ref patr);
                this.Test(db, out DateTime d);
                this.Surname = sn;
                this.Name = n;
                this.Patronymic = patr;
                this.Birth = d;
                this.Age = (this.now.Month > this.Birth.Month)
                ? (this.now.Year - this.Birth.Year) : (this.now.Year - this.Birth.Year - 1);
        }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public DateTime Birth { get; set; }

        public int Age { get; set; }

        public void Test(ref string s)
        {
            s = s.Trim();
            s = s.Replace("\t", string.Empty);
            var sb = new StringBuilder(s);
            sb[0] = char.ToUpper(sb[0]);
            s = sb.ToString();
            foreach (var item in s)
            {
                if (!char.IsLetter(item))
                {
                    throw new Exception("Wrong data!");
                }
            }
        }

        public void Test(string db, out DateTime d)
        {
            if (!DateTime.TryParse(db, out d))
            {
                throw new Exception("Wrong date format!");
            }
        }
    }
}
