using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fake.autofac
{
    public class ContainerBuilder
    {
        // 类型池
        private readonly Dictionary<Type, Resolver> _typePool = new Dictionary<Type, Resolver>();

        // 当前类型
        private Type _currentKey;

        public ContainerBuilder RegisterType<T>() where T : class
        {
            _currentKey = typeof(T);
            _typePool.Add(typeof(T), new Resolver { RealType = _currentKey});

            return this;
        }

        public ContainerBuilder AsImplementedInterfaces()
        {
            var interfaces = _currentKey.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                _typePool[@interface] = _typePool[_currentKey];
            }

            return this;
        }

        // 创建Container
        public IContainer Build()
        {
            return new Container(_typePool);
        }
    }
}
