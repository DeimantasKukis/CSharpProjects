using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DentalClinic
{
    public partial class Appointment : Form
    {
        public Appointment()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();
        private void fillPatient()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PatName from PatientTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PatName", typeof(string));
            dt.Load(rdr);
            PatientCb.ValueMember = "PatName";
            PatientCb.DataSource = dt;
            Con.Close();
        }
        private void fillTreatment()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select TreatName from TreatmentTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TreatName", typeof(string));
            dt.Load(rdr);
            TreatmentCb.ValueMember = "TreatName";
            TreatmentCb.DataSource = dt;
            Con.Close();
        }
        private void Appointment_Load(object sender, EventArgs e)
        {
            fillPatient();
            fillTreatment();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
