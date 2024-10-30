using EmberToolkit.Common.Interfaces.Repository;
using SubNet.Common.Enum.Data.Corps;
using System;

namespace SubNet.Common.Interfaces.Corps
{
    public interface ICorp : IEmberObject
    {
        ECorpClass Class { get; }



    }
}
