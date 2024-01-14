using CefSharp.WinForms;
using CefSharp;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Synapse
{
    public partial class Interanl_UI : Form
    {
        private Point _offset1;
        private Point _offset2;
        private IntPtr _targetWindowHandle;
        public ChromiumWebBrowser browser { get; set; }
        public Interanl_UI(IntPtr targetWindowHandle)
        {
            InitializeComponent();
            _targetWindowHandle = targetWindowHandle;

            var targetWindowRect = GetWindowRect(_targetWindowHandle);
            Width = targetWindowRect.Width;
            Height = targetWindowRect.Height;
            Left = targetWindowRect.Left;
            Top = targetWindowRect.Top;
            webBrowser1.Url = new Uri(string.Format("file:///{0}Editor/AceEditor.html", AppDomain.CurrentDomain.BaseDirectory));
        }
        private static Rectangle GetWindowRect(IntPtr windowHandle)
        {
            NativeMethods.GetWindowRect(windowHandle, out var rect);
            return Rectangle.FromLTRB(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        }

        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private void Interanl_UI_Load(object sender, EventArgs e)
        {
            timer1.Start();
            GetWindowRect(_targetWindowHandle);
            flowLayoutPanel1.Controls.Add(new Scripthubscript("Script 1"));

            var targetWindowRect = GetWindowRect(_targetWindowHandle);
            Width = targetWindowRect.Width;
            Height = targetWindowRect.Height;
            Left = targetWindowRect.Left;
            Top = targetWindowRect.Top;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetWindowRect(_targetWindowHandle);


            var targetWindowRect = GetWindowRect(_targetWindowHandle);
            Width = targetWindowRect.Width;
            Height = targetWindowRect.Height;
            Left = targetWindowRect.Left;
            Top = targetWindowRect.Top;
        }

        private void guna2GradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            _offset1 = new Point(e.X, e.Y);
        }

        private void guna2GradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _offset1 = new Point(e.X, e.Y);

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                panel1.Left = e.X + panel1.Left - _offset1.X;
                panel1.Top = e.Y + panel1.Top - _offset1.Y;
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            _offset2 = new Point(e.X, e.Y);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                scripthub.Left = e.X + scripthub.Left - _offset2.X;
                scripthub.Top = e.Y + scripthub.Top - _offset2.Y;
            }
        }
    }
}
