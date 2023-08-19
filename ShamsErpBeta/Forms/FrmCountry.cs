using System;
using ShamsErpBeta.Forms;
using ShamsErpBeta.Classes;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShamsErpBeta.Forms
{
    public partial class FrmCountry : Form
    {
        public FrmCountry()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        int cr, id;

        private void FrmCountry_Load(object sender, EventArgs e)
        {
            getFillData();
        }

        void getFillData()
        {
            var Sql = new SQLConClass();
            ds = Sql.SelectData("Select Id, ROW_NUMBER() OVER (ORDER BY (SELECT 1)) ت, [Name] from TblCountry Where Del = 0", 0, default);
            if (FunctionsClass.dsHasTables(ds))
            {
                dgvCountry.DataSource = ds.Tables[0];
                dgvCountry.Columns[0].Visible = false;
                dgvCountry.Columns[1].Width = 30;
                dgvCountry.Columns[2].HeaderText = "البلد";
            }
        }

        private void dgvCountry_Click(object sender, EventArgs e)
        {
            if (!FunctionsClass.checkDgvError(dgvCountry))
                return;

            cr = dgvCountry.CurrentRow.Index;
            id = (int)dgvCountry.Rows[cr].Cells[0].Value;
            txtName.Text = dgvCountry.Rows[cr].Cells[2].Value.ToString();
            txtName.Focus();
        }
    }
}
