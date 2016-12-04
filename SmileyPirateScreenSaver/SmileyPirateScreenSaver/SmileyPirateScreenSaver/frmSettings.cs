using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SmileyPirateScreenSaver
{
    public partial class frmSettings : Form
    {


        //Setup our Registry object
        RegistryKey key = null;
        public static RegistryKey key_ = null;


        public frmSettings()
        {
            InitializeComponent();

            key = Registry.CurrentUser.OpenSubKey("Software\\HackersScreenSaver", true);
            key_ = key;

            if (key == null)
            {
                //Create or Regitry values.
                Registry.CurrentUser.CreateSubKey("Software\\HackersScreenSaver");
                key = Registry.CurrentUser.OpenSubKey("Software\\HackersScreenSaver", true);
                key_ = key;

                //Save our data.
                key.SetValue("amount", 50);
                key.SetValue("speed", 15);
                key.SetValue("ghost", false);
                key.SetValue("inflatedeflate", false);
            }




            LoadSettings();
        }
               


        private void SaveSettings()
	    {
            if (key != null)
            {
                key.SetValue("amount", (int)scrlAmount.Value);
                key.SetValue("speed", (int)scrlSpeed.Value);
                key.SetValue("ghost", chkGhost.Checked);
                key.SetValue("inflatedeflate", chkInflateDeflate.Checked);
            }
	    }



        private void LoadSettings()
        {
            if (key == null)
            {
                scrlAmount.Value = 50;
                scrlSpeed.Value = 15;
                chkGhost.Checked = false;
                chkInflateDeflate.Checked = false;
            }
            else
            {
                scrlAmount.Value  = (int)key.GetValue("amount", 50);
                scrlSpeed.Value  = (int)key.GetValue("speed", 15);
                
                bool a;
                Boolean.TryParse((((String)key_.GetValue("ghost", "False"))), out a);
                chkGhost.Checked = a;

                bool b;
                Boolean.TryParse((((String)key_.GetValue("inflatedeflate", "False"))), out b);
                chkInflateDeflate.Checked = b;
            }






        }



        private void scrlSpeed_ValueChanged(object sender, EventArgs e)
        {
            double val = Convert.ToInt32(scrlSpeed.Value);
            double Percent = val / 30;
            double EndVal = Percent * 100;
            lblSpeed.Text = EndVal.ToString("F2") + "%";
            Application.DoEvents();
        }

        private void scrlAmount_ValueChanged(object sender, EventArgs e)
        {
            double val = Convert.ToInt32(scrlAmount.Value);
            double Percent = val / 100;
            double EndVal = Percent * 100;
            lblAmount.Text = EndVal.ToString("F2") + "%";
            Application.DoEvents();
        }



        private void btnLaunch_Click(object sender, EventArgs e)
        {
            btnLaunch.Visible = false;
            btnCancel.Visible = false;
            picLaunch.Visible = true;

            SaveSettings();

            Pause(5);

            Application.Exit();

        }


        static void Pause(int seconds)
        {
            var stopwatch = Stopwatch.StartNew();
            TimeSpan Elapsed;
            Application.DoEvents();
            do
            {
                Elapsed = stopwatch.Elapsed;
                Application.DoEvents();
            } while (Elapsed.Seconds < seconds);
            Application.DoEvents();
            stopwatch.Stop();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }




    }
}
