using LedCSharp;
using Microsoft.Win32;
using System;
using System.Configuration;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LogiNumLockLEDIndicator
{
    public partial class Form1 : Form
    {
        /// DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        private static extern short GetKeyState(int keyCode);

        /// Hotkeys' IDs
        const int NUMLOCK_STATE_HOTKEY_ID = 1;
        const int EXIT_APPLICATION_HOTKEY_ID = 2;
        const int OPEN_CONFIG_WINDOW_HOTKEY_ID = 3;

        public Form1()
        {
            InitializeComponent();

            /// Initialization hotkeys
            /// ALT = 0x1; CTRL = 0x2; SHIFT = 0x4; WIN = 0x8
            RegisterHotKey(this.Handle, NUMLOCK_STATE_HOTKEY_ID, 0, (int)Keys.NumLock);         // NumLock
            RegisterHotKey(this.Handle, EXIT_APPLICATION_HOTKEY_ID, 8, (int)Keys.NumLock);      // Win + NumLock
            RegisterHotKey(this.Handle, OPEN_CONFIG_WINDOW_HOTKEY_ID, 9, (int)Keys.NumLock);    // Win + Alt + NumLock
        }

        bool NumLockState = (GetKeyState(0x90) & 1) > 0;

        /// Init NumLock colors from app.config
        static double[] NumLockOnRGB = { Convert.ToDouble(ConfigurationManager.AppSettings["NumLockOnR"]), Convert.ToDouble(ConfigurationManager.AppSettings["NumLockOnG"]), Convert.ToDouble(ConfigurationManager.AppSettings["NumLockOnB"]) };
        static double[] NumLockOffRGB = { Convert.ToDouble(ConfigurationManager.AppSettings["NumLockOffR"]), Convert.ToDouble(ConfigurationManager.AppSettings["NumLockOffG"]), Convert.ToDouble(ConfigurationManager.AppSettings["NumLockOffB"]) };

        /// Init convert from 255 to '%'
        static int[] NumLockOnRGBPerCent = { Convert.ToInt32(NumLockOnRGB[0] / 255 * 100), Convert.ToInt32(NumLockOnRGB[1] / 255 * 100), Convert.ToInt32(NumLockOnRGB[2] / 255 * 100) };
        static int[] NumLockOffRGBPerCent = { Convert.ToInt32(NumLockOffRGB[0] / 255 * 100), Convert.ToInt32(NumLockOffRGB[1] / 255 * 100), Convert.ToInt32(NumLockOffRGB[2] / 255 * 100) };

        void changeNumLockState()
        {
            NumLockState = (GetKeyState(0x90) & 1) > 0;
            if (NumLockState)
            {
                // NumLock On
                LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.NUM_LOCK, NumLockOnRGBPerCent[0], NumLockOnRGBPerCent[1], NumLockOnRGBPerCent[2]);
            }
            else
            {
                // NumLock Off
                LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.NUM_LOCK, NumLockOffRGBPerCent[0], NumLockOffRGBPerCent[1], NumLockOffRGBPerCent[2]);
            }
        }

        /// Global hotkeys hook
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();


                switch (id)
                {
                    /// Main action: switch color on/off
                    case 1:
                        changeNumLockState();
                        break;

                    /// Exit program
                    case 2:
                        changeNumLockState();
                        LogitechGSDK.LogiLedShutdown();
                        Application.Exit();
                        break;

                    /// Show form
                    case 3:
                        changeNumLockState();
                        this.Show();
                        this.WindowState = FormWindowState.Normal;
                        break;
                }

            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /// Minimize on start
            if (this.WindowState == FormWindowState.Minimized) this.Hide();
            else this.Show();

            /// Init autostart settings checkbox text
            if (ConfigurationManager.AppSettings["delay"] == null)
            {
                checkBox1.Text = "Start with Windows (with 10s delay for GHUB start first)";
            }
            else
            {
                checkBox1.Text = "Start with Windows (with " + (Convert.ToInt32(ConfigurationManager.AppSettings["delay"]) / 1000) + "s delay for GHUB start first)";
            }

            /// State autostart checkbox on load
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rk.GetValue("LogiNumLockLEDInd") != null)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

            /// Set color of buttons on load
            buttonNumLockOn.ForeColor = Color.FromArgb(Convert.ToInt32(NumLockOnRGB[0]), Convert.ToInt32(NumLockOnRGB[1]), Convert.ToInt32(NumLockOnRGB[2]));
            buttonNumLockOff.ForeColor = Color.FromArgb(Convert.ToInt32(NumLockOffRGB[0]), Convert.ToInt32(NumLockOffRGB[1]), Convert.ToInt32(NumLockOffRGB[2]));

            /// LogiGSDK init
            LogitechGSDK.LogiLedInitWithName("Logitech NumLock LED Indicator");
            LogitechGSDK.LogiLedSetTargetDevice(LogitechGSDK.LOGI_DEVICETYPE_ALL);

            /// Init NumLock state
            //NumLockState = (GetKeyState(0x90) & 1) > 0;
            if (NumLockState)
            {
                // NumLock on
                LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.NUM_LOCK, NumLockOnRGBPerCent[0], NumLockOnRGBPerCent[1], NumLockOnRGBPerCent[2]);
            }
            else
            {
                // NumLock off
                LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(keyboardNames.NUM_LOCK, NumLockOffRGBPerCent[0], NumLockOffRGBPerCent[1], NumLockOffRGBPerCent[2]);
            }
        }


        /// Form hider
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) this.Hide();
            else this.Show();
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        /// Saving and applying parameters
        public void getSplicedNumLockColorCode(Color NumLockColorCode, bool NumLockStateArg)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                if (NumLockStateArg)
                {
                    config.AppSettings.Settings["NumLockOnR"].Value = (NumLockColorCode.R).ToString(); // saving in config
                    NumLockOnRGBPerCent[0] = NumLockColorCode.R * 100 / 255;                           // saving to current session in '100%' type
                    NumLockOnRGB[0] = NumLockColorCode.R;                                              // saving to current session in '255' type

                    config.AppSettings.Settings["NumLockOnG"].Value = (NumLockColorCode.G).ToString();
                    NumLockOnRGBPerCent[1] = NumLockColorCode.G * 100 / 255;
                    NumLockOnRGB[1] = NumLockColorCode.G;

                    config.AppSettings.Settings["NumLockOnB"].Value = (NumLockColorCode.B).ToString();
                    NumLockOnRGBPerCent[2] = NumLockColorCode.B * 100 / 255;
                    NumLockOnRGB[2] = NumLockColorCode.B;
                }
                else
                {
                    config.AppSettings.Settings["NumLockOffR"].Value = (NumLockColorCode.R).ToString();
                    NumLockOffRGBPerCent[0] = NumLockColorCode.R * 100 / 255;
                    NumLockOffRGB[0] = NumLockColorCode.R;

                    config.AppSettings.Settings["NumLockOffG"].Value = (NumLockColorCode.G).ToString();
                    NumLockOffRGBPerCent[1] = NumLockColorCode.G * 100 / 255;
                    NumLockOffRGB[1] = NumLockColorCode.G;

                    config.AppSettings.Settings["NumLockOffB"].Value = (NumLockColorCode.B).ToString();
                    NumLockOffRGBPerCent[2] = NumLockColorCode.B * 100 / 255;
                    NumLockOffRGB[2] = NumLockColorCode.B;
                }
                config.Save(ConfigurationSaveMode.Minimal);
            }
            /// Exception if app.config file not found. Allow program work in current session, but global saving not available
            catch (NullReferenceException e)
            {
                MessageBox.Show("Error: \"Logitech NumLock LED Indicator.exe.config\" not found or content invalid. Settings can't be saved. Changes applied only for this session.\n\n(" + e.Message + ": " + e.GetType().ToString() + ")", "app.config not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (NumLockStateArg)
                {
                    NumLockOnRGBPerCent[0] = NumLockColorCode.R * 100 / 255;
                    NumLockOnRGB[0] = NumLockColorCode.R;
                    NumLockOnRGBPerCent[1] = NumLockColorCode.G * 100 / 255;
                    NumLockOnRGB[1] = NumLockColorCode.G;
                    NumLockOnRGBPerCent[2] = NumLockColorCode.B * 100 / 255;
                    NumLockOnRGB[2] = NumLockColorCode.B;
                }
                else
                {
                    NumLockOffRGBPerCent[0] = NumLockColorCode.R * 100 / 255;
                    NumLockOffRGB[0] = NumLockColorCode.R;
                    NumLockOffRGBPerCent[1] = NumLockColorCode.G * 100 / 255;
                    NumLockOffRGB[1] = NumLockColorCode.G;
                    NumLockOffRGBPerCent[2] = NumLockColorCode.B * 100 / 255;
                    NumLockOffRGB[2] = NumLockColorCode.B;
                }
            }
        }

        /// Color settings dialog
        private void button1_Click(object sender, EventArgs e)
        {
            NumLockOnLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            NumLockOffLabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);

            ColorDialog NumLockOn = new ColorDialog();
            NumLockOn.Color = Color.FromArgb(Convert.ToInt32(NumLockOnRGB[0]), Convert.ToInt32(NumLockOnRGB[1]), Convert.ToInt32(NumLockOnRGB[2]));

            if (NumLockOn.ShowDialog() == DialogResult.OK)
            {
                NumLockOnLabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
                NumLockOffLabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
                buttonNumLockOn.ForeColor = NumLockOn.Color;
                getSplicedNumLockColorCode(buttonNumLockOn.ForeColor, true);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            NumLockOnLabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            NumLockOffLabel.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);

            ColorDialog NumLockOff = new ColorDialog();
            NumLockOff.Color = Color.FromArgb(Convert.ToInt32(NumLockOffRGB[0]), Convert.ToInt32(NumLockOffRGB[1]), Convert.ToInt32(NumLockOffRGB[2]));

            if (NumLockOff.ShowDialog() == DialogResult.OK)
            {
                NumLockOnLabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
                NumLockOffLabel.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
                buttonNumLockOff.ForeColor = NumLockOff.Color;
                getSplicedNumLockColorCode(buttonNumLockOff.ForeColor, false);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /// Add entry to registry about autostart
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (checkBox1.Checked)
            {
                rk.SetValue("LogiNumLockLEDInd", "\"" + Application.ExecutablePath + "\"");
            }
            else
            {
                rk.DeleteValue("LogiNumLockLEDInd", false);
            }
        }
        /// Hide from Task Manager; Shown in cmd -> tasklist
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var cp = base.CreateParams;
        //        cp.ExStyle |= 0x80; // Turn on WS_EX_TOOLWINDOW (0x80)
        //        return cp;
        //    }
        //}
    }
}

// ;

/*====================================================WORK WITH VALUES===================================================*/
//Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath); // find config file
//config.AppSettings.Settings.Add("keyOne", "valueOne");                                        // add new value
//ConfigurationManager.AppSettings["keyOne"];                                                   // get value
//config.AppSettings.Settings["keyOne"].Value = valueOne;                                       // update value
//config.Save(ConfigurationSaveMode.Minimal);                                                   // save file with values
/*=======================================================================================================================*/
