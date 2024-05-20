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
    public partial class ManageRentalRecords : Form
    {
        private readonly CarRentalEntities _db;
        public ManageRentalRecords()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddEditRentalRecord"))
            {
                var addRentalRecord = new AddEditRentalRecord(this);
                addRentalRecord.MdiParent = this.MdiParent;
                addRentalRecord.Show();
            }
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // get Id of selected row
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

                //query database for record
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

                if (!Utils.FormIsOpen("AddEditRentalRecord"))
                {
                    var addEditRentalRecord = new AddEditRentalRecord(record, this);
                    addEditRentalRecord.MdiParent = this.MdiParent;
                    addEditRentalRecord.Show();
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                // get Id of selected row
                var id = (int)gvRecordList.SelectedRows[0].Cells["Id"].Value;

                //query database for record
                var record = _db.CarRentalRecords.FirstOrDefault(q => q.id == id);

                DialogResult dr = MessageBox.Show("Are You Sure You Want To Delete This Record?",
                    "Delete", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    //delete vehicle from table
                    _db.CarRentalRecords.Remove(record);
                    _db.SaveChanges();

                    PopulateGrid();
                }
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ManageRentalRecords_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            var Customer = _db.CarRentalRecords.ToList();
            cbTimKiem.DataSource = Customer;
            cbTimKiem.ValueMember = "id";
            cbTimKiem.DisplayMember = "CustomerName";
        }

        public void PopulateGrid()
        {
            var records = _db.CarRentalRecords.Select(q => new
            {
                Customer = q.CustomerName,
                DateOut = q.DateRented,
                DateIn = q.DateReturned,
                Id = q.id,
                q.Cost,
                Car = q.TypeOfCar.Make + " " + q.TypeOfCar.Model,
                address = q.Address,
                PhoneNumber = q.Phone,
                EmailAddress = q.Email
            }).ToList();

            gvRecordList.DataSource = records;
            gvRecordList.Columns["DateIn"].HeaderText = "Date In";
            gvRecordList.Columns["DateOut"].HeaderText = "Date Out";
            gvRecordList.Columns["EmailAddress"].HeaderText = "Email";
            gvRecordList.Columns["PhoneNumber"].HeaderText = "Phone Number";
            //Hide the column for ID. Changed from the hard coded column value to the name, 
            // to make it more dynamic. 
            gvRecordList.Columns["Id"].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //search
        private void button1_Click(object sender, EventArgs e)
        {
            if (cbTimKiem.SelectedItem != null)
            {
                var selectedCustomer = cbTimKiem.Text ; 
                var result = _db.CarRentalRecords.Where(r => r.CustomerName == selectedCustomer).ToList();

                if (result.Any())
                {
                    foreach (var record in result)
                    {
                        MessageBox.Show($"Customer Name: {record.CustomerName}\nPhone: {record.Phone}\nEmail: {record.Email}\n");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để tìm kiếm.");
            }
        }
    }
}
