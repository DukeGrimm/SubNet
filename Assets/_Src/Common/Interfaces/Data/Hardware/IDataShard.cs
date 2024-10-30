using EmberToolkit.Common.Interfaces.Repository;

namespace SubNet.Common.Interfaces.Data.Hardware
{
    public interface IDataShard : IEmberObject
    {
        int Size { get; }
    }
}
