using System;
using System.Collections.Generic;
using System.Text;

namespace OzerNet.Dal.EntityFrameWork
{
    public interface IContextFactory
    {
        EfContext Create();
    }
}
