using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Student objAStudent)) return false;
            return Jmbag.Equals(objAStudent.Jmbag);
        }

        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }

        public static Boolean operator ==(Student a, Student b)
        {
            return a.Jmbag.Equals(b.Jmbag);
        }

        public static Boolean operator !=(Student a, Student b)
        {
            if (a == null) return true;
            return !(a == b);
        }

    }

    public enum Gender
    {
        Male, Female
    }

}
