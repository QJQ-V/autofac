using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fake.autofac
{
    public class Container : IContainer
    {
        private readonly Dictionary<Type, Resolver> _typePool = new Dictionary<Type, Resolver>();
        public Container(Dictionary<Type, Resolver> typePool)
        {
            _typePool = typePool;

            foreach (var resolver in _typePool.Values)
            {
                resolver.GetParameterInstanceEventHandler = Resolve;
            }
        }

        public T Resolve<T>() where T : class
        {
           return (T) Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            if (_typePool.Any(r => r.Key == type))
            {
                var reslover = _typePool[type];
                return reslover.GetInstance(reslover.RealType);
            }
            else
            {
                Console.WriteLine("{0} 尚未注册", type.ToString());
                return null;
            }
        }
    }
}
