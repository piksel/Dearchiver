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
        Delete = 0b001,
        Open   = 0b010,
        Close  = 0b100,
    }
}
