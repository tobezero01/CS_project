using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "notive", MessageBoxButtons.YesNo) == DialogResult.Yes) { this.Close(); }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            rdoFullDay.Checked = false;
            rdoHalfDay.Checked = false;
            txtYachtPrice.Text = "";
            cbDrinks.Text = string.Empty;
            cbAmount.Text = string.Empty;
        }

        private void rdoFullDay_CheckedChanged(object sender, EventArgs e)
        {
            txtYachtPrice.Text = "200";
        }

        private void rdoHalfDay_CheckedChanged(object sender, EventArgs e)
        {
            txtYachtPrice.Text = "100";
        }

        private void AcountingPrice()
        {
            double price = 0.0;
            if (cbAmount.SelectedIndex != -1 && cbDrinks.SelectedIndex != -1)
            {
                if (cbDrinks.Text == "Coca cola") { price = 0.5; }
                if (cbDrinks.Text =="Pepsy" ) { price = 0.8; }
                if (cbDrinks.Text == "Seven up") { price = 1; }
                txtDrinksPrice.Text = (price*Convert.ToDouble(cbAmount.SelectedItem)).ToString();
            }
   
        }
        private void cbDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcountingPrice();
        }

        private void cbAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            AcountingPrice();
        }

        private void txtDrinksPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
