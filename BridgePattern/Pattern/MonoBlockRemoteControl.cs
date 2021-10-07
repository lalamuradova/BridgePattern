using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Pattern
{
    public class MonoBlockRemoteControl : AbstractRemoteControl
    {
        public MonoBlockRemoteControl(MonoBlock mono) : base(mono)
        {
        }
        public override void SetChangeVolume()
        {
            this.monoBlock.SetChangeVolume();
        }

        public override void SetMute()
        {
            this.monoBlock.SetMute();
        }

        public override void SetOpenBrowser()
        {
            this.monoBlock.SetOpenBrowser();
        }

        public override void SetOpenCalculator()
        {
            this.monoBlock.SetOpenCalculator();
        }

        public override bool SwitchOnOff()
        {
            return this.monoBlock.SwitchOnOff();
        }
    }
}
