using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Criteria.DepartAdmin;
using Presentation.UIView;
using Presentation.UIView.DepartAdmin;

namespace Business.Interface.DepartAdmin
{
    public interface IDepartMessageService
    {
        DepartMessagePresentation Get(int id);

        ActionResult Save(DepartMessagePresentation presentation);

        EntityCollection<DepartMessagePresentation> GetAll(DepartMessageCriteria criteria);

        ActionResult Delete(int id);

        EntityCollection<DepartMessagePresentation> GetTop20FrontMessageList();

        EntityCollection<MessageUiPresentation> GetFrontMessageList(int pageIndex, int pageSize);

        ActionResult SetStatus(int departAdminId, int id, bool isOnline);
    }
}
