using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        private ManageVehicleListing _manageVehicleListing;
        private readonly CarRentalEntities _db;
        public AddEditVehicle(ManageVehicleListing manageVehicleListing = null)
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            this.Text = "Add New Vehicle";
            isEditMode = false;
            _manageVehicleListing = manageVehicleListing;
            _db = new CarRentalEntities();
        }

        public AddEditVehicle(TypeOfCar carToEdit, ManageVehicleListing manageVehicleListing = null) {
            InitializeComponent();
            lblTitle.Text = "Edit Vehicle";
            this.Text = "Edit Vehicle";
            _manageVehicleListing = manageVehicleListing;
            if (carToEdit == null)
            {
                MessageBox.Show("Please ensure that you selected a valid record to edit");
                Close();
            }
            else
            {
                isEditMode = true;
                _db = new CarRentalEntities();
                PopulateFields(carToEdit);
            }
            
        }

        private void PopulateFields(TypeOfCar car)
        {
            lblId.Text = car.Id.ToString();
            tbMake.Text = car.Make;
            tbModel.Text = car.Model;
            tbVIN.Text = car.VIN;
            tbYear.Text = car.YearTOC.ToString();
            tbLicenseNum.Text = car.LicensePlateNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //Added Validation for make and model
                if (string.IsNullOrWhiteSpace(tbMake.Text) ||
                        string.IsNullOrWhiteSpace(tbModel.Text))
                {
                    MessageBox.Show("Please ensure that you provide a make and a model");
                }
                else
                {
                    //if(isEditMode == true)
                    if (isEditMode)
                    {
                        //Edit Code here
                        var id = int.Parse(lblId.Text);
                        var car = _db.TypeOfCars.FirstOrDefault(q => q.Id == id);
                        car.Model = tbModel.Text;
                        car.Make = tbMake.Text;
                        car.VIN = tbVIN.Text;
                        car.YearTOC = int.Parse(tbYear.Text);
                        car.LicensePlateNumber = tbLicenseNum.Text;

                       
                    }
                    else
                    {
                        //Added validation for make and model of cars being added
                    
                        // Add Code Here
                        var newCar = new TypeOfCar
                        {
                            LicensePlateNumber = tbLicenseNum.Text,
                            Make = tbMake.Text,
                            Model = tbModel.Text,
                            VIN = tbVIN.Text,
                            YearTOC = int.Parse(tbYear.Text)
                        };

                        _db.TypeOfCars.Add(newCar);
                        
                    }
                    _db.SaveChanges();
                    _manageVehicleListing.PopulateGrid();
                    MessageBox.Show("Operation Completed. Refresh Grid To see Changes");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddEditVehicle_Load(object sender, EventArgs e)
        {

        }

        private void tbYear_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbYear.Text, out int year))
            {
                if (year > DateTime.Now.Year)
                {
                    // Xử lý trường hợp nhập năm lớn hơn năm hiện tại
                    MessageBox.Show("Vui lòng nhập số nhỏ hơn hoặc bằng năm hiện tại.");
                    // Xóa giá trị nhập sai
                    tbYear.Text = "";
                }
            }
            else
            {
                // Xử lý trường hợp nhập không phải là số
                MessageBox.Show("Vui lòng chỉ nhập số.");
                // Xóa giá trị nhập sai
                tbYear.Text = "";
            }
        }

        private void tbLicenseNum_TextChanged(object sender, EventArgs e)
        {
            string input = tbLicenseNum.Text;
            string result = string.Empty;

            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result += c;
                }
            }

            tbLicenseNum.Text = result;
            tbLicenseNum.Select(tbLicenseNum.Text.Length, 0);
        }
    }
}
