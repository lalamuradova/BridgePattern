using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Pattern
{
    public abstract class AbstractRemoteControl
    {
        protected MonoBlock monoBlock;
        protected AbstractRemoteControl(MonoBlock mono)
        {
            this.monoBlock = mono;
        }
        public abstract bool SwitchOnOff();
        public abstract void SetOpenCalculator();
        public abstract void SetOpenBrowser();
        public abstract void SetChangeVolume();
        public abstract void SetMute();
    }
}
