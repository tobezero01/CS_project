﻿using System;
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
    public partial class MainWindow : Form
    {
        private Login _login;
        public string _roleName;
        public userApp _user;
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Login login, userApp user)
        {
            InitializeComponent();
            _login = login;
            _user = user;
            _roleName = user.UserRoles.FirstOrDefault().Role.shortname;
        }

        private void addRentalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddEditRentalRecord"))
            {
                var addRentalRecord = new AddEditRentalRecord();
                addRentalRecord.MdiParent = this;
                addRentalRecord.Show();
            }
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (!Utils.FormIsOpen("ManageVehicleListing"))
            {
                var vehicleListing = new ManageVehicleListing();
                vehicleListing.MdiParent = this;
                vehicleListing.Show();
            }           
        }

        private void viewArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("ManageRentalRecords"))
            {
                var manageRentalRecords = new ManageRentalRecords();
                manageRentalRecords.MdiParent = this;
                manageRentalRecords.Show();
            }   
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _login.Close();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("ManageUsers"))
            {
                var manageUsers = new ManageUsers(_user);
                manageUsers.MdiParent = this;
                manageUsers.Show();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if(_user.passwords == Utils.DefaultHashedPassword())
            {
                var resetPassword = new ResetPassword(_user);
                resetPassword.ShowDialog();
            }

            var username = _user.username;
            tsiLoginText.Text = $"Logged In As: {username}";
            if(_roleName != "admin")
            {
                manageUsersToolStripMenuItem.Visible = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit application?", "notive", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void viewInvoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("ManageInvoice"))
            {
                var manageInvoice = new ManageInvoice();
                manageInvoice.MdiParent = this;
                manageInvoice.Show();
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            var login = new Login();
            login.Show();
        }
    }
}
