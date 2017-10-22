using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRESTWcf
{
    public class Student
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public Student()
        {

        }
        
        public override string ToString()
        {
            return $"Id: {Id}, Price: {Age}, Location: {Name}";
        }
    }
}