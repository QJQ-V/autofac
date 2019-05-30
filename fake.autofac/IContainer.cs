using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fake.autofac
{
    public interface IContainer
    {
        T Resolve<T>() where T : class;
    }
}
