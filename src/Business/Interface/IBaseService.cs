using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Presentation.Criteria;
using Presentation.UIView;

namespace Business.Interface
{
    public interface IBaseService<TKey, TPresentation, TCriteria>
        where TPresentation : BasePresentation, new()
        where TCriteria : BaseCriteria, new()
    {
        TPresentation Get(TKey key);

        TPresentation Get(TCriteria criteria);

        EntityCollection<TPresentation> GetAll(TCriteria criteria);

        ActionResult Save(TPresentation presentation);

        ActionResult SaveAll(IList<TPresentation> presentations);

        ActionResult DeleteByTKey(TKey key);
    }
}
