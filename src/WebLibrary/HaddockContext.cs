using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Presentation.UIView;
using WebLibrary.Helper;

namespace WebLibrary
{
    [Serializable]
    public class HaddockContext
    {
        private HaddockContext()
        {
            
        }

        public LoginUserPresentation CurrentUser
        {
            get
            {
                return AuthorizeHelper.GetCurrentUser(HttpContext.Current.User.Identity.Name);
            }
        }

        private readonly static object LockObject=new object();
        private readonly static object LockObject2 = new object();
        private static HaddockContext _Current;
        public static HaddockContext Current
        {
            get
            {
                lock (LockObject)
                {
                    if (_Current == null)
                    {
                        lock (LockObject2)
                        {
                            if (_Current == null)
                            {
                                _Current = new HaddockContext();
                            }
                        }
                    }
                }
                return _Current;
            }
        }
    }
}
