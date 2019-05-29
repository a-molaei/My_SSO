using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class SecurityLevelMode
    {
        private SecurityLevel _SecurityLevel;
        private SecurityMode _SecurityMode;
        public SecurityLevelMode()
        {
        }
        private ILazyLoader LazyLoader { get; set; }
        private SecurityLevelMode(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        public int Id { get; set; }
        public int SecurityLevelId { get; set; }
        public SecurityLevel SecurityLevel
        {
            get => LazyLoader.Load(this, ref _SecurityLevel);
            set => _SecurityLevel = value;
        }
        public int SecurityModeId { get; set; }
        public SecurityMode SecurityMode
        {
            get => LazyLoader.Load(this, ref _SecurityMode);
            set => _SecurityMode = value;
        }
    }
}
