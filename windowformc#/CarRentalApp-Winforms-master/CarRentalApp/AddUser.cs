using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddUser : Form
    {
        private readonly CarRentalEntities _db;
        private ManageUsers _manageUsers;
        public AddUser(ManageUsers manageUsers)
        {
            InitializeComponent();
            _db = new CarRentalEntities();
            _manageUsers = manageUsers;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            var roles = _db.Roles.ToList();
            cbRoles.DataSource = roles;
            cbRoles.ValueMember = "id";
            cbRoles.DisplayMember = "rolename";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var username = tbUsername.Text;
                var roleId = (int)cbRoles.SelectedValue;
                var password = Utils.DefaultHashedPassword();
                var lastName = tbLastname.Text;
                var phoneNumber = tbPhone.Text;
                var email = tbEmail.Text;

                var user = new userApp
                {
                    username = username,
                    passwords = password,
                    lastName = lastName,
                    phoneNumber = phoneNumber,
                    email = email,
                    isActive = true
                };
                _db.userApps.Add(user);
                _db.SaveChanges();

                var userid = user.id;

                var userRole = new UserRole
                {
                    roleid = roleId,
                    userid = userid
                };

                _db.UserRoles.Add(userRole);
                _db.SaveChanges();

                MessageBox.Show("New User Added SUccessfully");
                _manageUsers.PopulateGrid();
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("An Error Has Occured");
            }
        }

        private void tbPhone_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^\d{4}-\d{3}-\d{3}$"; // Định dạng chuẩn
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(tbPhone.Text))
            {
            }
            else
            {
                if (Regex.IsMatch(tbPhone.Text, @"^\d{1,4}-\d{1,3}-\d{1,3}$"))
                {
                    MessageBox.Show("Vui lòng nhập đúng định dạng xxxx-xxx-xxx");
                }
                else
                {
                    tbPhone.Text = tbPhone.Text.Remove(tbPhone.Text.Length - 1);
                }
            }
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$"; // Định dạng chuẩn
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(tbEmail.Text))
            {

            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email có hậu tố @gmail.com");
            }
        }
    }
}
