using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zad1;

namespace Zad4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.GroupBy(x => x)
                .Select(i => "Broj " + i.Key + " ponavlja se " + i.Count() + " puta")
                .OrderBy(x => x)
                .ToArray();

        }
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(noman => noman.Students.Length == noman.Students.Count(s => s.Gender == Zad1.Gender.Male))
                .ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            double average = universityArray.Average(s => s.Students.Length);
            return universityArray.Where(s => s.Students.Length < average).ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students)
                                  .Distinct()
                                  .ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.All(s => s.Gender == Gender.Male) || u.Students.All(s => s.Gender == Gender.Female))
                                  .SelectMany(u => u.Students)
                                  .Distinct()
                                  .ToArray();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students)
                                      .GroupBy(s => s)
                                      .Where(g => g.Count() >= 2)
                                      .Select(g => g.Key)
                                      .Distinct()
                                      .ToArray();
        }
    }

    public class University
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }
    }

}