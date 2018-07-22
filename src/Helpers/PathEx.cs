using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piksel.Dearchiver.Helpers
{
    public static class PathEx
    {
        internal static string GetFileExtension(string name)
        {
            var lastDot = name.LastIndexOf('.');
            return lastDot >= 0 ? name.Substring(lastDot) : string.Empty;
        }
    }
}
