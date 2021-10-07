using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BridgePattern.Pattern
{
    public class MonoBlock : IMonoBlock
    {
        bool ischecked;
        public void SetChangeVolume()
        {
            MessageBox.Show("Change Volume");
        }

        public void SetMute()
        {
            MessageBox.Show("Mute");
        }

        public void SetOpenBrowser()
        {
            System.Diagnostics.Process.Start("http://google.com");
        }

        public void SetOpenCalculator()
        {
            System.Diagnostics.Process.Start("calc");
        }


        public bool SwitchOnOff()
        {
            if (ischecked)
            {
                ischecked = false;
            }
            else
            {
                ischecked = true;
            }
            return ischecked;
        }
    }

}
