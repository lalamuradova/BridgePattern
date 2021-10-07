using BridgePattern.Command;
using BridgePattern.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BridgePattern.ViewModel
{
    public class AppViewModel : BaseViewModel
    {
        public Ellipse Dot { get; set; }
        public Rectangle Back { get; set; }       

        Thickness LeftSide = new Thickness(-39, 0, 0, 0);
        Thickness RightSide = new Thickness(0, 0, -39, 0);
        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(197, 14, 46));
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(7, 98, 23));
        private bool Toggled = false;
        public RelayCommand CalculatorCommand { get; set; }
        public RelayCommand BrowserCommand { get; set; }
        public RelayCommand VoiceCommand { get; set; }
        public RelayCommand MuteCommand { get; set; }
        public RelayCommand BackCommand { get; set; }
        public RelayCommand DotCommand { get; set; }       
        public bool Toggled1 { get => Toggled; set => Toggled = value; }

        public bool click { get; set; } = true;

        public Border CalculatorButton { get; set; }
        public Border BrowserButton { get; set; }
        public Slider Voice { get; set; }
        public Image Mute { get; set; }


        [DllImport("user32.dll")]

        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
        IntPtr wParam, IntPtr lParam);

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        MonoBlock monoBlock = new MonoBlock();
        AbstractRemoteControl RemoteControl;

        public AppViewModel()
        {
            RemoteControl = new MonoBlockRemoteControl(monoBlock);
            BackCommand = new RelayCommand((e) =>
            {
                if (RemoteControl.SwitchOnOff())
                {
                    PowerOn();
                    Dot.Fill = On;
                    Toggled = true;
                    Dot.Margin = RightSide;
                }
                else
                {
                    PowerOff();
                    Dot.Fill = Off;
                    Toggled = false;
                    Dot.Margin = LeftSide;
                }
            });

            DotCommand = new RelayCommand((e) =>
            {

                if (RemoteControl.SwitchOnOff())
                {
                    PowerOn();
                    Dot.Fill = On;
                    Toggled = true;
                    Dot.Margin = RightSide;
                }
                else
                {
                    PowerOff();
                    Dot.Fill = Off;
                    Toggled = false;
                    Dot.Margin = LeftSide;
                }
            });


            

            CalculatorCommand = new RelayCommand((e) =>
            {
                RemoteControl.SetOpenCalculator();
            });

            BrowserCommand = new RelayCommand((e) =>
            {
                RemoteControl.SetOpenBrowser();
            });

            VoiceCommand = new RelayCommand((e) =>
            {

                RemoteControl.SetChangeVolume();

            });
            
            MuteCommand = new RelayCommand((e) =>
            {
                if (click)
                {
                    Mute.Source = new BitmapImage(new Uri(@"../image/mute.png", UriKind.Relative));
                    click = false;
                    RemoteControl.SetMute();
                }
                else
                {
                    Mute.Source = new BitmapImage(new Uri(@"../image/mute2.png", UriKind.Relative));
                    click = true;
                }
            });



        }
        public void PowerOn()
        {
            BrowserButton.IsEnabled = true;
            CalculatorButton.IsEnabled = true;
            Voice.IsEnabled = true;
            Mute.IsEnabled = true;
        }
        public void PowerOff()
        {
            BrowserButton.IsEnabled = false;
            CalculatorButton.IsEnabled = false;
            Voice.IsEnabled = false;
            Mute.IsEnabled = false;
        }
    }
    }
