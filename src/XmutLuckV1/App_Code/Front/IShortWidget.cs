using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmutLuckV1.Front
{
    public interface IShortWidget
    {
        int MaxContentLength { get; set; }

        bool EnableShortContent { get; set; }
    }
}
