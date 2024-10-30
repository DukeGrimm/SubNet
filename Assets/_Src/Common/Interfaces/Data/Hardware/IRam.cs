using EmberToolkit.Common.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Interfaces.Data.Hardware
{
    public interface IRam : IEmberObject
    {
        int Size { get; }
    }
}
