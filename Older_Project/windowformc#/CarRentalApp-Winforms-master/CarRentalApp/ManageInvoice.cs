using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace CarRentalApp
{
    public partial class ManageInvoice : Form
    {
        private readonly CarRentalEntities _db;
        public ManageInvoice()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }
        private void ManageInvoice_Load(object sender, EventArgs e)
        {
            var users = _db.userApps.ToList();
            cbUserName.DataSource = users;
            cbUserName.ValueMember = "id";
            cbUserName.DisplayMember = "username";

            var records = _db.CarRentalRecords.ToList();
            cbRecordName.DataSource = records;
            cbRecordName.ValueMember = "id";
            cbRecordName.DisplayMember = "CustomerName";

            gvInvoice.Columns.Add("RecordName", "Record Name");
            gvInvoice.Columns.Add("UserName", "Employee Name");
            gvInvoice.Columns.Add("UserId", "User ID");
            gvInvoice.Columns.Add("RecordId", "Record ID");
            gvInvoice.Columns.Add("LastName", "Last Name");
            gvInvoice.Columns.Add("DayRented", "Day Rented");
            
            gvInvoice.Columns.Add("TotalAmount", "Total Amount");
        }

        private void cbUserid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUserName.SelectedValue != null)
            {
                int selectedUserId;
                if (int.TryParse(cbUserName.SelectedValue.ToString(), out selectedUserId))
                {
                    var user = _db.userApps.FirstOrDefault(x => x.id == selectedUserId);

                    if (user != null)
                    {
                        tbLastName.Text = user.lastName;
                        tbUserId.Text = user.id.ToString();
                    }
                }
            }
        }

        private void cbRecordId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRecordName.SelectedValue != null)
            {
                int selectedRecordId;
                if (int.TryParse(cbRecordName.SelectedValue.ToString(), out selectedRecordId))
                {
                    var record = _db.CarRentalRecords.FirstOrDefault(x => x.id == selectedRecordId);

                    if (record != null)
                    {
                        // fill cost/day
                        tbCost.Text = record.Cost.ToString();
                        // fill id record
                        tbIdRecord.Text = record.id.ToString();
                        // fill day rented
                        DateTime dateOut = (DateTime)record.DateRented;
                        DateTime dateIn = (DateTime)record.DateReturned;

                        if (dateIn.Month == dateOut.Month && dateIn.Year == dateOut.Year)
                        {
                            int days = (dateIn.Day - dateOut.Day);
                            tbDay.Text = days.ToString();
                        }
                        else
                        {
                            int daysInMonth1 = DateTime.DaysInMonth(dateOut.Year, dateOut.Month) - dateOut.Day;
                            int daysInMonth2 = dateIn.Day;

                            // Tính tổng số ngày
                            int totalDays = daysInMonth1 + daysInMonth2;
                            for (int i = dateOut.Month + 1; i < dateIn.Month; i++)
                            {
                                totalDays += DateTime.DaysInMonth(dateIn.Year, i);
                            }
                            tbDay.Text = totalDays.ToString();
                        }

                        tbTotal.Text = (Convert.ToInt32(tbCost.Text) * Convert.ToInt32(tbDay.Text)).ToString();
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var recordName = cbRecordName.Text;
            var userName = cbUserName.Text;
            var userId = Convert.ToInt32(tbUserId.Text);
            var recordId = Convert.ToInt32(tbIdRecord.Text);
            var lastName = tbLastName.Text;
            var dayRented = tbDay.Text;
            var totalAmount = Convert.ToInt32(tbTotal.Text);

            var invoice = new Invoice
            {
                UserAppId = userId,
                CarRentalRecord = recordId,
                TotalAmount = totalAmount
            };

            _db.Invoices.Add(invoice);
            _db.SaveChanges();

            DataGridViewRow row = new DataGridViewRow();

            // Add cells to the row in the specified order
            row.CreateCells(gvInvoice, recordName, userName, userId, recordId, lastName, dayRented, totalAmount);

            // Add the row to the DataGridView
            gvInvoice.Rows.Add(row);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
                Excel.Range headerRange = exSheet.Cells[1, 1]; // Đưa con trỏ vào ô A1

                // Add headers to the Excel file
                exSheet.Cells[1, 1] = "Record Name";
                exSheet.Cells[1, 2] = "Employee Name";
                exSheet.Cells[1, 3] = "User ID";
                exSheet.Cells[1, 4] = "Record ID";
                exSheet.Cells[1, 5] = "Total Amount";
                exSheet.Cells[1, 6] = "Day Rented";
                exSheet.Cells[1, 7] = "Last Name";

                // Add data to the Excel file from DataGridView
                for (int i = 0; i < gvInvoice.Rows.Count; i++)
                {
                    for (int j = 0; j < gvInvoice.Columns.Count; j++)
                    {
                        if (gvInvoice.Rows[i].Cells[j].Value != null)
                        {
                            exSheet.Cells[i + 2, j + 1] = gvInvoice.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            exSheet.Cells[i + 2, j + 1] = "";
                        }
                    }
                }

                exBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal);
                exBook.Close(true, Type.Missing, Type.Missing);
                exApp.Quit();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
