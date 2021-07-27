using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using OzerNet.Dal.EntityFrameWork.Base;

namespace OzerNet.Dal.EntityFrameWork.Base
{
    public class ContextFactory<T> : IContextFactory where T : EfContext, new()
    {
        public EfContext Create()
        {
            return new T();
        }
    }
}
