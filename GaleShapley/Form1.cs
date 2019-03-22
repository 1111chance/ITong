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
        Marry marry;
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (marry == null)
            {
                btnBuild.PerformClick();
            }
            int number = marry.MaleDic.Count;
            marry.Start();

            tbMaleSF.Text = "男性：" + marry.MaleSatisfaction.ToString("0.00");
            tbFemaleSF.Text = "女性：" + marry.FemaleSatisfaction.ToString("0.00");

            dgvMale.Rows.Clear();
            dgvMale.Rows.Add(marry.MarriageCount);
            int index = 0;
            foreach (Male male in marry.MaleDic.Values)
            {
                if (!male.Marryed)
                {
                    continue;
                }
                Female female = marry.FemaleDic[male.PartnerID];
                DataGridViewRow rowMale = dgvMale.Rows[index];
                index++;
                rowMale.Cells["MaleID"].Value = male.ID;
                rowMale.Cells["MalePoint"].Value = male.Point.ToMyString();
                rowMale.Cells["MaleESPoint"].Value = male.MyEstimatePoint.ToMyString();
                rowMale.Cells["MaleSF"].Value = male.Satisfaction.ToMyString();

                rowMale.Cells["FemaleID"].Value = female.ID;
                rowMale.Cells["FemalePoint"].Value = female.Point.ToMyString();
                rowMale.Cells["FemaleESPoint"].Value = female.MyEstimatePoint.ToMyString();
                rowMale.Cells["FemaleSF"].Value = female.Satisfaction.ToMyString();
            }
            dgvPeople.Rows.Clear();
            dgvPeople.Rows.Add(marry.SingleCount);
            index = 0;
            foreach (Male male in marry.MaleDic.Values)
            {
                if (!male.Marryed)
                {
                    DataGridViewRow row = dgvPeople.Rows[index];
                    index++;
                    row.Cells["PeopleID"].Value = male.ID;
                    row.Cells["PeoplePoint"].Value = male.Point.ToMyString();
                    row.Cells["PeopleESPoint"].Value = male.MyEstimatePoint.ToMyString();
                    row.Cells["PeopleSex"].Value = "男";
                }
            }
            foreach (Female female in marry.FemaleDic.Values)
            {
                if (!female.Marryed)
                {
                    DataGridViewRow row = dgvPeople.Rows[index];
                    index++;
                    row.Cells["PeopleID"].Value = female.ID;
                    row.Cells["PeoplePoint"].Value = female.Point.ToMyString();
                    row.Cells["PeopleESPoint"].Value = female.MyEstimatePoint.ToMyString();
                    row.Cells["PeopleSex"].Value = "女";
                }
            }
        }

        private void numUDManCount_ValueChanged(object sender, EventArgs e)
        {
            if (numUDManCount.Value < 1)
            {
                numUDManCount.Value = 1;
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            int number;
            number = Convert.ToInt32(numUDManCount.Value);
            if (number < 1)
            {
                number = 1;
            }
            marry = new Marry(number, number);
        }
    }
}
