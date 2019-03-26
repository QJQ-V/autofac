using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofac
{
    public class ContainerService
    {
        public static IContainer Container;

        static ContainerService()
        {
            // 获取容器
            var builder = new ContainerBuilder();

            // 注册组件（类），并公开服务（接口）
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();

            // 存储容器
            Container = builder.Build();
        }
    }
}
