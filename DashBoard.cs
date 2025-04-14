using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DairyFarmSystem
{
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            Finance();
            Logistic();
            GetMax();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Finances Ob = new Finances();
            Ob.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {

            MilkSales Ob = new MilkSales();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Breedings Ob = new Breedings();
            Ob.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            CowHealth Ob = new CowHealth();
            Ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MilkProduction Ob = new MilkProduction();
            Ob.Show();
            this.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Cows Ob = new Cows();
            Ob.Show();
            this.Hide();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yhris\Documents\DairyFarmSystem10.mdf;Integrated Security=True;Connect Timeout=30");
        private void Finance()
        {
            //We calculate the Finance related Analytics
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(IncAmt) from Incometbl", Con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(ExpAmount) from ExpenditureTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int inc, exp;
                double bal;
            //inc = Convert.ToInt32(dt.Rows[0][0].ToString());
            if(Int32.TryParse(dt.Rows[0][0].ToString(), out inc))
            {
                //Conversion successfull
            }
            else
            {
                //handle the error
            }

            IncLbl.Text ="Rs"+dt.Rows[0][0].ToString();
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            //exp = Convert.ToInt32(dt1.Rows[0][0].ToString());
            if (Int32.TryParse(dt1.Rows[0][0].ToString(), out exp))
            {
                //Conversion successfull
            }
            else
            {
                //handle the error
            }

            bal = inc - exp;
            ExpLbl.Text = "Rs"+dt1.Rows[0][0].ToString();
            BalLbl.Text = "Rs" + bal;
            Con.Close();

        }
        private void Logistic()
        {
            //We calculate the Logistics related Analytics
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from Cowtbl", Con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(TotalMilk) from MilkTbl", Con);
            SqlDataAdapter sda2 = new SqlDataAdapter("select Count(*) from EmployeeTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Cownumlbl.Text = dt.Rows[0][0].ToString();
           DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            MilkLbl.Text =dt1.Rows[0][0].ToString()+ "Liters";
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Empnumlbl.Text = dt2.Rows[0][0].ToString();
            Con.Close();

        }
        private void GetMax()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncAmt) from Incometbl ", Con);
            SqlDataAdapter sda1 = new SqlDataAdapter("select Max(ExpAmount) from ExpenditureTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            HighAmtlbl.Text = "Rs" + dt.Rows[0][0].ToString();
            //HighDateLbl.Text =dt.Rows[0][1].ToString();
            HighExplbl.Text = "Rs" + dt1.Rows[0][0].ToString();

        }
        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Login Ob = new Login();
            Ob.Show();
            this.Hide();
        }

        private void guna2GradientPanel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
