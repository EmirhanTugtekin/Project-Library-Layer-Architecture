using Autofac;
using Autofac.Integration.Mvc;
using ProjectLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectLibrary.Admin
{
    public static class Bootstrapper
    {
        //herhangi controller içinden interfacde bir istekte bulununca constructor injector yardımıyla gerekli nesne bize gönderilecek
        public static void RunConfig()
        {
            BuildAutofac();
        }
        private static void BuildAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<BorrowingRepository>().As<IBorrowingRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();
            builder.RegisterType<FineRepository>().As<IFineRepository>();
            builder.RegisterType<LibrarySituationRepository>().As<ILibrarySituationRepository>();
            builder.RegisterType<LocationRepository>().As<ILocationRepository>();
            builder.RegisterType<MemberRepository>().As<IMemberRepository>();
            builder.RegisterType<StuffRepository>().As<IStuffRepository>();

            var container = builder.Build();//IContainer nesnesi oluşur

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
        }
    }
}