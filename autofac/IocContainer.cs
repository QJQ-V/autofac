using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autofac
{
    /// <summary>
    /// IOC容器
    /// </summary>
    public class IocContainer
    {
        private ContainerBuilder _builder;

        public IocContainer()
        {
            _builder = new ContainerBuilder();
        }

        #region 注册

        #region 反射组件

        /// <summary>
        /// 通过类型注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RegisterType<T>() where T : class
        {
            _builder.RegisterType<T>().AsSelf().As<T>();
        }

        #endregion


        #endregion
    }
}
