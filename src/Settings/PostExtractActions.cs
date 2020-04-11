using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piksel.Dearchiver.Settings
{
    [Flags]
    public enum PostExtractActions
    {
        None = 0,
        Delete = 0b0001,
        Open   = 0b0010,
        Close  = 0b0100,
        Launch = 0b1000,
    }
}
