using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sound
{
    public partial class Form1 : Form
    {
        private SoundRecord recorder = new SoundRecord();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            recorder = new SoundRecord();
            recorder.SetFileName("2.mp3");
            recorder.RecStart();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            recorder.RecStop();
            recorder = null;
        }
    }
}
