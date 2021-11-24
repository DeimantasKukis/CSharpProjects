using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinic
{
    public partial class Treatment : Form
    {
        public Treatment()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into TreatmentTbl values('" + TretNameTb.Text + "','" + TreatCost.Text + "','" + TreatDesc.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Treatment Succesfully Added");
                //populate();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        void populate()
        {
            MyPatient Pat = new MyPatient();
            string query = "select * from TreatmentTbl";
            DataSet ds = Pat.ShowPatient(query);
            TreatmentDGV.DataSource = ds.Tables[0];
        }
        private void Treatment_Load(object sender, EventArgs e)
        {
            populate();
        }

    }
}
