using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Le_Vendue.Models
{
    public class UniqueIdGenerator
    {
        public static string generateUniqueID(int _characterLength = 11)
        {
            StringBuilder _builder = new StringBuilder();
            Enumerable
                .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(_characterLength)
                .ToList().ForEach(e => _builder.Append(e));
            return _builder.ToString();
        }
    }
}