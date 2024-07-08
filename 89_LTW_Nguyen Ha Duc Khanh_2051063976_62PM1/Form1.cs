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
    public partial class Form1 : Form
    {
        int index;
        DataTable sinhvien = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }
        private void reset()
        {
            tbmasv.Text = "";
            tbten.Text = "";
            dtpngaysinh.Text = "";
            rbnam.Checked = false;
            rbnu.Checked = false;
            cbnoisinh.SelectedItem = null;
        }
        
        private void btthem_Click(object sender, EventArgs e)
        {
            if (tbmasv.Text != "")
            {
                if (tbten.Text != "")
                {
                    if (cbnoisinh.Text != "")
                    {            
                            string[] data =
                            {
                            tbmasv.Text,
                            tbten.Text,
                            dtpngaysinh.Text,
                            rbnam.Checked ? "Nam" : "Nữ",
                            cbnoisinh.Text
                            };
                        sinhvien.Rows.Add(data);
                        reset();                      
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa chọn nơi sinh cho sinh viên");
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập tên cho sinh viên");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên");
            }               
            string sv;
            sv = JsonConvert.SerializeObject(sinhvien);
            System.IO.File.WriteAllText(@"sinhvien.json", sv);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader reader;
            reader = new System.IO.StreamReader(@"sinhvien.json");
            string sv = reader.ReadToEnd();
            reader.Close();
            sinhvien = JsonConvert.DeserializeObject<DataTable>(sv);
            dgvDSSV.DataSource = sinhvien;
            if (dgvDSSV.Rows.Count == 0)
            {
                sinhvien.Columns.Add("Mã SV");
                sinhvien.Columns.Add("Tên");
                sinhvien.Columns.Add("Ngày sinh");
                sinhvien.Columns.Add("Giới tính");
                sinhvien.Columns.Add("Nơi sinh");
            }
        }
        private void dgvDSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dgvDSSV.CurrentCell.RowIndex;
            tbmasv.Text = dgvDSSV.Rows[index].Cells[0].Value.ToString();
            tbten.Text = dgvDSSV.Rows[index].Cells[1].Value.ToString();
            dtpngaysinh.Value = Convert.ToDateTime(dgvDSSV.Rows[index].Cells[2].Value);
            if (dgvDSSV.Rows[index].Cells[3].Value.ToString() == "Nam")
                rbnam.Checked = true;
            else
                rbnu.Checked = true;
            cbnoisinh.Text = dgvDSSV.Rows[index].Cells[4].Value.ToString();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            dgvDSSV.Rows.RemoveAt(index);
            reset();
            string sv;
            sv = JsonConvert.SerializeObject(sinhvien);
            System.IO.File.WriteAllText(@"sinhvien.json", sv);
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            dgvDSSV.Rows[index].Cells[0].Value = tbmasv.Text;
            dgvDSSV.Rows[index].Cells[1].Value = tbten.Text;
            dgvDSSV.Rows[index].Cells[2].Value = dtpngaysinh.Text;
            dgvDSSV.Rows[index].Cells[3].Value = rbnam.Checked ? "Nam" : "Nữ";
            dgvDSSV.Rows[index].Cells[4].Value = cbnoisinh.Text;
            reset();
            string sv;
            sv = JsonConvert.SerializeObject(sinhvien);
            System.IO.File.WriteAllText(@"sinhvien.json", sv);
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
        }
    }
}
