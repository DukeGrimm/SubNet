using EmberToolkit.Common.Interfaces.Repository;

namespace SubNet.Common.Interfaces.Data.Servers
{
    public interface IQuadObject : IEmberObject
    {
        int Size { get; }
    }
}
