using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payFlow.Application.Common.Sortables
{
    public interface ISortable<TOrderBy>
    {
        TOrderBy OrderBy { get; set; }
        bool Descending { get; set; }   
    }
}
