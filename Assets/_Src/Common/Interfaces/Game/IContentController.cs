using System;
using System.Collections.Generic;

namespace SubNet.Common.Interfaces.Game
{
    public delegate C ContentFactory<SO, C>(SO contentSO);
    public interface IContentController
    {
        void LoadContentFromResources<SO, C>(object key, ContentFactory<SO, C> factoryMethod, Action<List<C>> callback);
    }
}
