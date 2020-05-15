using Autofac;
using SkDemo1.Services;
using SkDemo1.Services.Interfaces;
using SkDemo1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkDemo1.Configuration
{
    public class IoCContainer
    {
        public static IContainer Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProjectDataService>().As<IProjectDataService>();

            builder.RegisterType<NewProjectViewModel>();
            builder.RegisterType<CompanyListViewModel>();
            
            return builder.Build();
        }
    }
}
