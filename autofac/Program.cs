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
            using (var scope = ContainerService.Container.BeginLifetimeScope())
            {
                //解析组件（功能类似于new一个IDateWriter的实现类）
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }

            Console.ReadKey();
        }
    }
}
