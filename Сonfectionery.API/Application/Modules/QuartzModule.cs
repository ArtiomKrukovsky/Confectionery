﻿using System.Reflection;
using Autofac;
using Quartz;
using Module = Autofac.Module;

namespace Сonfectionery.API.Application.Modules
{
    public class QuartzModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(x => typeof(IJob).IsAssignableFrom(x)).InstancePerDependency();
        }
    }
}