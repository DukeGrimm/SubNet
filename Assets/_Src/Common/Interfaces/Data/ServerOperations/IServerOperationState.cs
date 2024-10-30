using SubNet.Common.Enum.Data.ServerOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Interfaces.Data.ServerOperations
{
    public interface IServerOperationState
    {
        EServerOperationState State { get; }

    }
}
