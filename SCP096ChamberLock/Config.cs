using Exiled.API.Interfaces;
using System.ComponentModel;

namespace SCP096ChamberLock
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("How long SCP 096 should be locked in their chamber")]
        public int WaitTime { get; set; } = 60;
    }
}
