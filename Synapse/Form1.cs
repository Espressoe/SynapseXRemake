using CefSharp;
using CefSharp.WinForms;
using Guna.UI2.WinForms;
using Synapse.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synapse
{
    public partial class Form1 : Form
    {
        private Point _offset1;
        private Point _offset2;
        private Point _offset3;

        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        private Interanl_UI _overlayForm;
        private IntPtr _targetWindowHandle;
        private const string CheckboxConfigKey = "IsCheckboxChecked";
        private const string UnlockConfigKey = "IsFPSUnlocked";
        private const string topmostconfigkey = "IsTopMost";
        public ChromiumWebBrowser browser { get; set; }
        public Form1()
        {
            InitializeComponent();
            InitBrowser();
            this.Text = GenerateRandomString();
            this.Name = GenerateRandomString();
            #region
            start();
            #endregion
        }

        private void InitBrowser()
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize((CefSettingsBase)cefSettings);
            this.browser = new ChromiumWebBrowser(string.Format("file:///{0}ace/AceEditor.html", AppDomain.CurrentDomain.BaseDirectory));
            this.browser.BrowserSettings.WindowlessFrameRate = 150;
            editor.Controls.Add(this.browser);
        }
        private string GenerateRandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] stringChars = new char[10];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool isCheckboxChecked = Convert.ToBoolean(ConfigurationManager.AppSettings[CheckboxConfigKey]);
            guna2CheckBox6.Checked = isCheckboxChecked;
            bool isfpsunlocked = Convert.ToBoolean(ConfigurationManager.AppSettings[UnlockConfigKey]);
            guna2CheckBox1.Checked = isfpsunlocked;
            bool istopmost = Convert.ToBoolean(ConfigurationManager.AppSettings[topmostconfigkey]);
            guna2CheckBox7.Checked = istopmost;
            timer1.Start();
            flowLayoutPanel1.Controls.Add(new Script("IY.lua"));
            flowLayoutPanel1.Controls.Add(new Script("Arsenal Hitbox.lua"));
            flowLayoutPanel1.Controls.Add(new Script("Aimbot.lua"));
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("1184984133257146470", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("1184984133257146470", ref this.handlers, true, null);
            this.presence.state = GenerateRandomString();
            this.presence.largeImageKey = "synapselogo";
            DiscordRpc.UpdatePresence(ref this.presence);
            flowLayoutPanel1.Controls.Add(new Script("Test Script.lua"));
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if(guna2Button9.Checked == true)
            {
                guna2Button9.Text = "R";
            }
            else
            {
                guna2Button9.Text = "M";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2Button9.Checked == true)
            {
                guna2Button9.Text = "R";
                panel2.Dock = DockStyle.Fill;
            }
            else
            {
                guna2Button9.Text = "M";
                panel2.Dock = DockStyle.None;
            }
            if (guna2CheckBox7.Checked == true)
            {
                TopMost = true;

            }
            else
            {
                TopMost = false;
            }
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("1184984133257146470", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("1184984133257146470", ref this.handlers, true, null);
            this.presence.state = GenerateRandomString();
            this.presence.largeImageKey = "synapselogo";
            DiscordRpc.UpdatePresence(ref this.presence);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _offset1 = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panel2.Left = e.X + panel2.Left - _offset1.X;
                panel2.Top = e.Y + panel2.Top - _offset1.Y;
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            _offset2 = new Point(e.X, e.Y);
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                scripthub.Left = e.X + scripthub.Left - _offset2.X;
                scripthub.Top = e.Y + scripthub.Top - _offset2.Y;
            }
        }

        private async void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2Button6.Text = "Starting...";
            await Task.Delay(900);
            guna2Button6.Text = "Script Hub";
            scripthub.Visible = true;
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            scripthub.Visible = false;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            options.Visible = true;
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            options.Visible = false;
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            _offset3 = new Point(e.X, e.Y);
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                options.Left = e.X + options.Left - _offset3.X;
                options.Top = e.Y + options.Top - _offset3.Y;
            }
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Synapse.Properties.Resources.Dark_Dex;
            richTextBox1.Text = "A Version of the popular Dex explorer with patches specifically for Synapse X.";
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Synapse.Properties.Resources.remote_spy;
            richTextBox1.Text = "Allows you to view RemoteEvents and Remotefunctions That have been called.";
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Synapse.Properties.Resources.ESP;
            richTextBox1.Text = "ESP Made by ice3w0lf using the Drawing API.";
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Synapse.Properties.Resources.script_dumper;
            richTextBox1.Text = "Dumps all LocalScripts and ModuleScripts.";
        }

        private void guna2CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[topmostconfigkey].Value = guna2CheckBox7.Checked.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        private async void guna2Button7_Click(object sender, EventArgs e)
        {
            int processId = GetProcessIdByName("RobloxPlayerBeta");
            if (processId != -1)
            {
                label1.Location = new System.Drawing.Point(304, 6);
                label1.Text = "Synapse X - v2.201.2b " + "(injecting...)";
                await Task.Delay(1000);
                label1.Location = new System.Drawing.Point(288, 6);
                label1.Text = "Synapse X - v2.201.2b " + "(checking Whitelist...)";
                await Task.Delay(1500);
                label1.Location = new System.Drawing.Point(309, 6);
                label1.Text = "Synapse X - v2.201.2b " + "(scanning...)";
                await Task.Delay(900);
                label1.Location = new System.Drawing.Point(328, 6);
                label1.Text = "Synapse X - v2.201.2b " + "(ready!)";
                await Task.Delay(1000);
                label1.Location = new System.Drawing.Point(351, 6);
                label1.Text = "Synapse X - v2.201.2b";
                _targetWindowHandle = FindWindow(null, "Roblox");
                /*
                 * 
                 * 
                 *
                        REPLACE ALL THE CODE UNDER `private async void guna2Button7_Click(object sender, EventArgs e)`
                        TO YOUR INJECT CODE ALL THIS CODE DOES IS LOOK COOL AND ACCURATE
                 *
                 *
                 *
                 *
                 *
                 *
                 *
                 *
                 */
                if (guna2CheckBox6.Checked == true)
                {
                    if (_targetWindowHandle != IntPtr.Zero)
                    {
                        _overlayForm = new Interanl_UI(_targetWindowHandle);
                        _overlayForm.Show();
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                label1.Text = label1.Text = "Synapse X - v2.201.2b " + "(roblox process not found!)";
                await Task.Delay(1000);
                label1.Text = "Synapse X - v2.201.2b";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Exewcute Go here!
        }
        static int GetProcessIdByName(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                return processes[0].Id;
            }
            return -1;
        }
        #region 
        private void start()
        {
            MessageBox.Show("Credits\r\nUI - Espresso", "Start");
            MessageBox.Show("This Message can be Removed Via going through the code and Finding the Function.", "btw");
        }
        #endregion
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[CheckboxConfigKey].Value = guna2CheckBox6.Checked.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[UnlockConfigKey].Value = guna2CheckBox1.Checked.ToString();
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Clear Code Go here
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Save File Go here
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Open File Go Here
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            // Execute File Code Go Here (Open File + execute)
        }
    }
}
