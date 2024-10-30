using SubNet.Common.Interfaces.Corps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubNet.Common.Interfaces.Game.Corps
{
    public interface ICorpManager
    {
        IEnumerable<ICorp> GetAllCorps();
        ICorp GetCorp(Guid id);
        IEnumerable<ICorp> GetCorpsWhere(Func<ICorp, bool> filter);
        ICorp GetRandomCorp();
        ICorp GetRandomCorpWhere(Func<ICorp, bool> filter);
    }
}
