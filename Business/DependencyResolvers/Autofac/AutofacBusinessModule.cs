using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthManager>();

            builder.RegisterType<UserManager>().As<IUserManager>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<CourseManager>().As<ICourseService>();
            builder.RegisterType<CoureseDal>().As<ICourseDal>();

            builder.RegisterType<CourseCategoryManager>().As<ICourseCategoryServices>();
            builder.RegisterType<CourseCategoryDal>().As<ICourseCategoryDal>();


        }
    }
}
