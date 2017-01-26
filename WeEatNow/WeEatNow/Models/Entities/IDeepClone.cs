using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeEatNow.Models.Entities
{
    public interface IDeepClone
    {
        T Clone<T>();

    }
}
