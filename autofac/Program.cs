using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            // 使用原始Autofac实现
            var container = RegisterIoc();
            using (var scope = container.BeginLifetimeScope())
            {
                //解析组件（功能类似于new一个IDateWriter的实现类）
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }

            //使用自定义Autofac实现
            var container2 = RegisterFakeIoc();
            var writer2 = container2.Resolve<IDateWriter>();
            writer2.WriteDate();

            Console.ReadKey();
        }

        private static IContainer RegisterIoc()
        {
            var builder = new ContainerBuilder();

            // 注册组件（类），并公开服务（接口）
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TodayWriter>().As<IDateWriter>();

            // 创建容器
            return builder.Build();
        }

        private static fake.autofac.IContainer RegisterFakeIoc()
        {
            var builder = new fake.autofac.ContainerBuilder();

            // 注册组件（类），并公开服务（接口）
            builder.RegisterType<ConsoleOutput>().AsImplementedInterfaces();
            builder.RegisterType<TodayWriter>().AsImplementedInterfaces();

            // 创建容器
            return builder.Build();
        }
    }
}
