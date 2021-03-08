using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _5951071092_LeTranXuanSon_.Models;

namespace _5951071092_LeTranXuanSon_.Controllers
{
    public class StudentController : ApiController
    {
        StudentInfo[] students = new StudentInfo[]
        {
            new StudentInfo {Id = 1, Name = "Son", Lop = "CNTT K59",  NamSinh = "2000"},
            new StudentInfo {Id = 2, Name = "Thang", Lop = "CNTT K59",  NamSinh = "2000"},
            new StudentInfo {Id = 3, Name = "Tho", Lop = "CNTT K59",  NamSinh = "2000"}
        };
        // GET: api/Student
        public IEnumerable<StudentInfo> Get()
        {
            return students;
        }

        // GET: api/Student/5
        public StudentInfo Get(int id)
        {
            if (id - 1 < students.Length)
            {
                return students.ElementAt(id-1);
            }

            return new StudentInfo
            {
                Id = students.Length + 1,
                Name = "Invalid ID",
                Lop = "Error",
                NamSinh = "Error"
            };
        }
    }
}
