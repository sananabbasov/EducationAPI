using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CourseContentDTO
    {
        public string CategoryId { get; set; }
        public string CourseId { get; set; }
        public string AuthorName { get; set; }
        public string PhotoUrl { get; set; }
        public string CourseName { get; set; }
    }
}
