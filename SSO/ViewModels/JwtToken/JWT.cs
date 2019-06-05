using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class JWT
    {
        public string Access_Token { get; set; }
        public long Expires { get; set; }
        public int PageId { get; set; }
    }
}
