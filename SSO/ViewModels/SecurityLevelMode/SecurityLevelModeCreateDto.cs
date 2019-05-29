using SSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class SecurityLevelModeCreateListDto
    {
        public List<SecurityLevelModeRecordDto> List { get; set; }
    }
    public class SecurityLevelModeRecordDto
    {
        public int SecurityLevelId { get; set; }
        public int SecurityModeId { get; set; }
        public SecurityLevelMode LoadFrom()
        {
            var obj = new SecurityLevelMode()
            {
                SecurityLevelId = SecurityLevelId,
                SecurityModeId = SecurityModeId
            };
            return obj;
        }
    }
}
