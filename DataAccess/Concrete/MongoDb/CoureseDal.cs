using Core.DataAccess.MongoDb;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MongoDb
{
    public class CoureseDal : MongoEntityRepositoryBase<Course>, ICourseDal
    {
        public List<CourseContentDTO> GetCourseContent()
        {
            var database = new MongoClient("mongodb://localhost:27017").GetDatabase("education");
            var courses = database.GetCollection<Course>("courses");
            var res = courses.Find(x => true).ToList();

            AppDbContext _context = new();

            List<CourseContentDTO> result = new();

            foreach (var item in res)
            {
                CourseContentDTO course = new()
                {
                    CategoryId = item.CategoryId,
                    CourseId = item._id,
                    CourseName = item.Name,
                    PhotoUrl = item.PhotoUrl,
                    AuthorName = _context.Users.FirstOrDefault(x=>x.Id == item.UserId).Name,
                };
                result.Add(course);
            }
            return result;
        }
    }
}
