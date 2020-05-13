using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Shared
{
    public interface IUrlFilter
    {
        void Apply(ref List<JobUrl> urls);
    }
}
