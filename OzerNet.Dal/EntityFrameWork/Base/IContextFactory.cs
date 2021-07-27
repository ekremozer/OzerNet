using System;
using System.Collections.Generic;
using System.Text;
using OzerNet.Dal.EntityFrameWork.Base;

namespace OzerNet.Dal.EntityFrameWork.Base
{
    public interface IContextFactory
    {
        EfContext Create();
    }
}
