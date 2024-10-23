using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopAquarium
{
    public partial class frmCredit : Form
    {
        public frmCredit()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/JJSnader",
                UseShellExecute = true // Needed to open URLs in the default browser in .NET Core/Framework
            });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/merissler",
                UseShellExecute = true // Needed to open URLs in the default browser in .NET Core/Framework
            });
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/druburkholder",
                UseShellExecute = true // Needed to open URLs in the default browser in .NET Core/Framework
            });
        }
    }
}
