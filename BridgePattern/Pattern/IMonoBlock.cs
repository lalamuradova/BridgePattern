using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern.Pattern
{
    public interface IMonoBlock
    {
        bool SwitchOnOff();
        void SetOpenCalculator();
        void SetOpenBrowser();
        void SetChangeVolume();
        void SetMute();

    }
}
