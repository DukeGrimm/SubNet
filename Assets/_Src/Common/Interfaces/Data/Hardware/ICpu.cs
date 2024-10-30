using EmberToolkit.Common.Interfaces.Repository;

namespace SubNet.Common.Interfaces.Data.Hardware
{
    public interface ICpu : IEmberObject
    {
        int Speed { get; }
    }
}
