﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
//blap

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        public int curF = 1;
        public string[,] sounds = new string[13,11];
        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            this.KeyPress +=
    new KeyPressEventHandler(Form1_KeyPress);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            updateLabels(); 
            _applicationForm = this;
            _hookID = SetHook(_proc);

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
        }
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if ((Keys)vkCode == Keys.Escape)
                {
                    _applicationForm.wplayer.controls.stop();
                }
                if ((Keys)vkCode == Keys.F1)
                {
                    _applicationForm.curF = 1;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F2)
                {
                    _applicationForm.curF = 2;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F3)
                {
                    _applicationForm.curF = 3;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F4)
                {
                    _applicationForm.curF = 4;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F5)
                {
                    _applicationForm.curF = 5;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F6)
                {
                    _applicationForm.curF = 6;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F7)
                {
                    _applicationForm.curF = 7;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F8)
                {
                    _applicationForm.curF = 8;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F9)
                {
                    _applicationForm.curF = 9;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F10)
                {
                    _applicationForm.curF = 10;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F11)
                {
                    _applicationForm.curF = 11;
                    _applicationForm.updateLabels();
                }
                if ((Keys)vkCode == Keys.F12)
                {
                    _applicationForm.curF = 12;
                    _applicationForm.updateLabels();
                }

                try
                {
                    int keyint = 0;
                                    if ((Keys)vkCode == Keys.D0) {
                                        keyint=0;
                                    }
                                                        if ((Keys)vkCode == Keys.D1) {
                                        keyint=1;
                                    }
                                                        if ((Keys)vkCode == Keys.D2) {
                                        keyint=2;
                                    }
                                                        if ((Keys)vkCode == Keys.D3) {
                                        keyint=3;
                                    }
                                                        if ((Keys)vkCode == Keys.D4) {
                                        keyint=4;
                                    }
                                                        if ((Keys)vkCode == Keys.D5) {
                                        keyint=5;
                                    }
                                                        if ((Keys)vkCode == Keys.D6) {
                                        keyint=6;
                                    }
                                                        if ((Keys)vkCode == Keys.D7) {
                                        keyint=7;
                                    }
                                                        if ((Keys)vkCode == Keys.D8) {
                                        keyint=8;
                                    }
                                                        if ((Keys)vkCode == Keys.D9) {
                                        keyint=9;
                                    }
                    if (keyint >= 0 && keyint <= 9)
                    {
                        if (_applicationForm.sounds[_applicationForm.curF, keyint] != null)
                        {
                            _applicationForm.wplayer.URL = _applicationForm.sounds[_applicationForm.curF, keyint];
                            _applicationForm.wplayer.controls.play();
                        }
                    }

                }
                catch
                {
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static Form1 _applicationForm;
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }
        void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
                try
                {
                    int keyint = Int32.Parse(e.KeyChar.ToString());
                    if (keyint >= 0 && keyint<=9)
                    {
                        if (sounds[curF, keyint] != null)
                        {
                            wplayer.URL = sounds[curF, keyint];
                            wplayer.controls.play();
                        }
                    }

                }
                catch
                {
                }

            

        }
        public void updateLabels()
        {
            sl1.Text = sounds[curF, 1]; 
            sl2.Text = sounds[curF, 2];
            sl3.Text = sounds[curF, 3];
            sl4.Text = sounds[curF, 4];
            sl5.Text = sounds[curF, 5];
            sl6.Text = sounds[curF, 6];
            sl7.Text = sounds[curF, 7];
            sl8.Text = sounds[curF, 8];
            sl9.Text = sounds[curF, 9];
            sl0.Text = sounds[curF, 0];
            if (curF == 1)
            {
                f1b.BackColor = Color.Red;
            }            else { 
                f1b.BackColor = Color.Gray ;
            }
            if (curF == 2)
            {
                f2b.BackColor = Color.Red;
            }            else { 
                f2b.BackColor = Color.Gray ;
            }
            if (curF == 3)
            {
                f3b.BackColor = Color.Red;
            }            else { 
                f3b.BackColor = Color.Gray ;
            }
            if (curF == 4)
            {
                f4b.BackColor = Color.Red;
            }            else { 
                f4b.BackColor = Color.Gray ;
            }
            if (curF == 5)
            {
                f5b.BackColor = Color.Red;
            }            else { 
                f5b.BackColor = Color.Gray ;
            }
            if (curF == 6)
            {
                f6b.BackColor = Color.Red;
            }            else { 
                f6b.BackColor = Color.Gray ;
            }
            if (curF == 7)
            {
                f7b.BackColor = Color.Red;
            }            else { 
                f7b.BackColor = Color.Gray ;
            }
            if (curF == 8)
            {
                f8b.BackColor = Color.Red;
            }            else { 
                f8b.BackColor = Color.Gray ;
            }
            if (curF == 9)
            {
                f9b.BackColor = Color.Red;
            }            else { 
                f9b.BackColor = Color.Gray ;
            }
            if (curF == 10)
            {
                f10b.BackColor = Color.Red;
            }            else { 
                f10b.BackColor = Color.Gray ;
            }
            if (curF == 11)
            {
                f11b.BackColor = Color.Red;
            }            else { 
                f11b.BackColor = Color.Gray ;
            }
            if (curF == 12)
            {
                f12b.BackColor = Color.Red;
            }
            else {
                f12b.BackColor = Color.Gray;
            }
        }
        public void getSave(string fileIn)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileIn);
            int zingy = 1;
            int incy = 0;
            foreach (string line in lines)
            {
                switch (line)
                {
                    case "F1":
                        zingy = 1;
                        incy = 0;
                        break;
                    case "F2":
                        zingy = 2;
                        incy = 0;
                        break;
                    case "F3":
                        zingy = 3;
                        incy = 0;
                        break;
                    case "F4":
                        zingy = 4;
                        incy = 0;
                        break;
                    case "F5":
                        zingy = 5;
                        incy = 0;
                        break;
                    case "F6":
                        zingy = 6;
                        incy = 0;
                        break;
                    case "F7":
                        zingy = 7;
                        incy = 0;
                        break;
                    case "F8":
                        zingy = 8;
                        incy = 0;
                        break;
                    case "F9":
                        zingy = 9;
                        incy = 0;
                        break;
                    case "F10":
                        zingy = 10;
                        incy = 0;
                        break;
                    case "F11":
                        zingy = 11;
                        incy = 0;
                        break;
                    case "F12":
                        zingy = 12;
                        incy = 0;
                        break;
                    case "null":
                        incy++;
                        break;

                    default:
                        sounds[zingy,incy] = line;
                        incy=incy+1;
                        if (incy > 9)
                        {
                            incy = 0;
                        }
                        break;

                }
            }
            updateLabels();
        }
        public void writeSave()
        {
            string saveJunk = "";
            for (int i = 1; i <= 12; i++)
            {
                saveJunk = saveJunk + "F" + i + Environment.NewLine;
                for (int j = 0; j < 10; j++)
                {
                    try
                    {
                        if (sounds[i, j] != null && sounds[i,j].Length>4)
                        {
                            saveJunk = saveJunk + sounds[i, j] + Environment.NewLine;
                        }
                        else
                        {
                            saveJunk = saveJunk + "null" + Environment.NewLine;
                        }
                    }
                    catch
                    {

                    }
                }

            }

            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Text File|*.txt";

            // Determine if the user selected a file name from the saveFileDialog. 
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                System.IO.File.WriteAllText(saveFile1.FileName.ToString(), saveJunk.ToString());
            }
        }
        public void soundStuff(int numGo)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                sounds[curF, numGo] = file;
                updateLabels();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            soundStuff(1);
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wplayer.URL = sounds[curF, 1];
            wplayer.controls.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            curF = 1; 
            updateLabels();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            soundStuff(2);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            soundStuff(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            soundStuff(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            soundStuff(5);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            soundStuff(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            soundStuff(7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            soundStuff(8);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            soundStuff(9);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            soundStuff(0);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            writeSave();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
                        DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                        if (result == DialogResult.OK) // Test result.
                        {
                            getSave(openFileDialog1.FileName.ToString());
                                                    }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void f2b_Click(object sender, EventArgs e)
        {
            curF = 2; updateLabels();
        }

        private void f3b_Click(object sender, EventArgs e)
        {
            curF = 3; updateLabels();
        }

        private void f4b_Click(object sender, EventArgs e)
        {
            curF = 4; updateLabels();
        }

        private void f5b_Click(object sender, EventArgs e)
        {
            curF = 5; updateLabels();
        }

        private void f6b_Click(object sender, EventArgs e)
        {
            curF = 6; updateLabels();
        }

        private void f7b_Click(object sender, EventArgs e)
        {
            curF = 7; updateLabels();
        }

        private void f8b_Click(object sender, EventArgs e)
        {
            curF = 8; updateLabels();
        }

        private void f9b_Click(object sender, EventArgs e)
        {
            curF = 9; updateLabels();
        }

        private void f10b_Click(object sender, EventArgs e)
        {
            curF = 10; updateLabels();
        }

        private void f11b_Click(object sender, EventArgs e)
        {
            curF = 11; updateLabels();
        }

        private void f12b_Click(object sender, EventArgs e)
        {
            curF = 12; updateLabels();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                int newvol = volbar.Value;
                wplayer.settings.volume = newvol;
            }
            catch
            {

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Should be able to play anything Windows Media Player can play."+Environment.NewLine+"Play with number keys. Escape will stop current sound."+Environment.NewLine+"v1.0 by judge reinhold of the Men Drinkin' Coffee."+Environment.NewLine+"www.mendrinkincoffee.com");
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


    }
}
