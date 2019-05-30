using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fake.autofac
{
    public class Resolver
    {
        public Type RealType { get; set; }

        public Func<Type, object> GetParameterInstanceEventHandler { get; set; }

        public object GetInstance(Type type)
        {
            // 获取构造函数
            var constructors = type.GetConstructors();
            var paramsInfos = constructors[constructors.Length - 1].GetParameters();

            // 准备构造函数的参数
            var @params = new List<object>();
            foreach (var paramsInfo in paramsInfos)
            {
                if (!paramsInfo.ParameterType.IsPrimitive)
                {
                    @params.Add(GetParameterInstanceEventHandler(paramsInfo.ParameterType));
                }
                else
                {
                    Type parameterType = paramsInfo.ParameterType;
                    var paramInstanse = type.Assembly.CreateInstance(parameterType.FullName);
                    @params.Add(paramInstanse);
                }
            }

            // 利用构造函数创建对象
            return constructors[0].Invoke(@params.ToArray());
        }
    }
}
