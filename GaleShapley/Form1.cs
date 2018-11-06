using GaleShapley.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaleShapley
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Marry.ClearInstance();
            Marry.Number = 1000;
            Marry marry = Marry.GetInstance();
            marry.Start();
            dgvMale.Rows.Clear();
            dgvFemale.Rows.Clear();
            dgvMale.Rows.Add(Marry.Number);
            dgvFemale.Rows.Add(Marry.Number);
            for (int i = 0; i < Marry.Number; i++)
            {
                DataGridViewRow rowMale = dgvMale.Rows[i];
                rowMale.Cells["MaleID"].Value = marry.MaleDic[i].ID;
                rowMale.Cells["MaleSF"].Value = marry.MaleDic[i].Satisfaction;
                DataGridViewRow rowFemale = dgvFemale.Rows[i];
                rowFemale.Cells["FemaleID"].Value = marry.FemaleDic[i].ID;
                rowFemale.Cells["FemaleSF"].Value = marry.FemaleDic[i].Satisfaction;
            }
        }
    }
}
