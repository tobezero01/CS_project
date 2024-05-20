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
    public partial class ManageUsers : Form
    {
        private readonly CarRentalEntities _db;
        private userApp _user;
        public string _roleName;
        public ManageUsers()
        {
            InitializeComponent();
            _db = new CarRentalEntities();
        }
        public ManageUsers(userApp user)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _user = user;
            _roleName = user.UserRoles.FirstOrDefault().Role.shortname;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!Utils.FormIsOpen("AddUser"))
            {
                var addUser = new AddUser(this);
                addUser.MdiParent = this.MdiParent;
                addUser.Show();
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // get Id of selected row
                var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value;

                //query database for record
                var user = _db.userApps.FirstOrDefault(q => q.id == id);
                
                var hashed_password = Utils.DefaultHashedPassword();
                user.passwords = hashed_password;
                _db.SaveChanges();
                
                MessageBox.Show($"{user.username}'s Password has been reset!");
                PopulateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeactivateUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (_roleName != "admin")
                {
                    // get Id of selected row
                    var id = (int)gvUserList.SelectedRows[0].Cells["id"].Value;

                    //query database for record
                    var user = _db.userApps.FirstOrDefault(q => q.id == id);

                    user.isActive = user.isActive == true ? false : true;
                    _db.SaveChanges();

                    MessageBox.Show($"{user.username}'s active status has changed!");
                    PopulateGrid();
                }
                else
                {
                    btnDeactivateUser.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        public void PopulateGrid()
        {
           
            var users = _db.userApps
                .Select(q => new
                {
                   q.id,
                   q.username,
                   q.UserRoles.FirstOrDefault().Role.rolename,
                   q.lastName,
                   q.phoneNumber, 
                   q.email,
                   q.isActive
                })
                .ToList();
            gvUserList.DataSource = users;
            gvUserList.Columns["username"].HeaderText = "Username";
            gvUserList.Columns["rolename"].HeaderText = "Role Name";
            gvUserList.Columns["lastName"].HeaderText = "Last Name";
            gvUserList.Columns["phoneNumber"].HeaderText = "Phone Number";
            gvUserList.Columns["email"].HeaderText = "Email Address";
            gvUserList.Columns["isActive"].HeaderText = "Active";

            
            gvUserList.Columns["id"].Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
