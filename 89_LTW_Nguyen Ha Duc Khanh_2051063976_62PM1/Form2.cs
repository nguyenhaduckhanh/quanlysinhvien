using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace _89_LTW_Nguyen_Ha_Duc_Khanh_2051063976_62PM1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       /* DataTable sinhvien = new DataTable();*/
        private void bttim_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            dgvtimkiem.Rows.Clear();
            if (comboBox1.Text == "Mã SV")
            {
                for (int i = 0; i < a.dgvDSSV.Rows.Count; i++)
                {
                    if (tbtim.Text == a.dgvDSSV[0, i].Value.ToString())
                    {
                        dgvtimkiem.Rows.Add(a.dgvDSSV[0, i].Value, a.dgvDSSV[1, i].Value, a.dgvDSSV[2, i].Value, a.dgvDSSV[3, i].Value, dgvtimkiem[4, i].Value);
                    }
                }
            }
            if (comboBox1.Text == "Nơi sinh")
            {
                for (int i = 0; i < a.dgvDSSV.Rows.Count; i++)
                {
                    if (tbtim.Text == a.dgvDSSV[4, i].Value.ToString())
                    {
                        dgvtimkiem.Rows.Add(a.dgvDSSV[0, i].Value, a.dgvDSSV[1, i].Value, a.dgvDSSV[2, i].Value, a.dgvDSSV[3, i].Value, dgvtimkiem[4, i].Value);
                    }
                }
            }
            if (comboBox1.Text == "Giới tính")
            {
                for (int i = 0; i < a.dgvDSSV.Rows.Count; i++)
                {
                    if (tbtim.Text == a.dgvDSSV[3, i].Value.ToString())
                    {
                        dgvtimkiem.Rows.Add(a.dgvDSSV[0, i].Value, a.dgvDSSV[1, i].Value, a.dgvDSSV[2, i].Value, a.dgvDSSV[3, i].Value, dgvtimkiem[4, i].Value);
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            /*System.IO.StreamReader reader;
            reader = new System.IO.StreamReader(@"sinhvien.json");
            string sv = reader.ReadLine();
            reader.Close();
            sinhvien = JsonConvert.DeserializeObject<DataTable>(sv);*/
        }
    }
}
