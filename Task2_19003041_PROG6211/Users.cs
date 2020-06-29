using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2_19003041_PROG6211
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private string[] user;
        private ArrayList newUser;

        private void Users_Load(object sender, EventArgs e)
        {
            usersLabel.Location = new System.Drawing.Point((this.Size.Width / 2) - (usersLabel.Size.Width / 2), 39);
            loginStrip.Text = "Logged in as: " + Login.loggedInUser;
            updateUsersBox();
            userBox.SelectedIndex = 0;
        }

        private void updateUsersBox()
        {
            userBox.Items.Clear();
            user = System.IO.File.ReadAllLines("../../LoginDetails.txt");
            newUser = new ArrayList(user);
            for (int i = 0; i < (Weather.TotalLines(@"../../LoginDetails.txt") / 3); i++)
            {
                userBox.Items.Add(user[i * 3]);
            };
        }

        private void userBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            usernameBox.Text = user[userBox.SelectedIndex * 3];
            passwordBox.Text = user[userBox.SelectedIndex * 3 + 1];
            if (user[userBox.SelectedIndex * 3 + 2] == "1")
            {
                userTypeBox.SelectedItem = "Forecaster";
            }
            else if (user[userBox.SelectedIndex * 3 + 2] == "2")
            {
                userTypeBox.SelectedItem = "Regular";
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string oldName = user[userBox.SelectedIndex * 3];
            user[userBox.SelectedIndex * 3] = usernameBox.Text;
            user[userBox.SelectedIndex * 3 + 1] = passwordBox.Text;
            if (Convert.ToString(userTypeBox.SelectedItem) == "Forecaster")
            {
                user[userBox.SelectedIndex * 3 + 2] = "1";
            }
            else if (Convert.ToString(userTypeBox.SelectedItem) == "Regular")
            {
                user[userBox.SelectedIndex * 3 + 2] = "2";
            }
            System.IO.File.WriteAllLines("../../LoginDetails.txt", user);
            MessageBox.Show("User " + oldName + " successfully updated.");
            int tempIndex = userBox.SelectedIndex;
            updateUsersBox();
            userBox.SelectedIndex = tempIndex;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report.firstTimeLoad = true;
            this.Hide();
            Login newLogin = new Login();
            newLogin.ShowDialog();
            this.Close();
        }

        private void captureStrip_Click(object sender, EventArgs e)
        {
            this.Hide();
            Capture newCapture = new Capture();
            newCapture.ShowDialog();
            this.Close();
        }

        private void reportStrip_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report reportForm = new Report();
            Weather.populateArrayLists();
            reportForm.ShowDialog();
            this.Close();
        }

        private void updateStrip_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update newUpdate = new Update();
            newUpdate.ShowDialog();
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will delete the currently selected user.\n\nAre you sure?", "Delete User?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                newUser.RemoveAt(userBox.SelectedIndex * 3 + 2);
                newUser.RemoveAt(userBox.SelectedIndex * 3 + 1);
                newUser.RemoveAt(userBox.SelectedIndex * 3);
                user = (string[])newUser.ToArray(typeof(string));
                System.IO.File.WriteAllLines("../../LoginDetails.txt", user);
                int tempIndex = userBox.SelectedIndex;
                updateUsersBox();
                userBox.SelectedIndex = tempIndex - 1;
            }
            else
            {
            }
        }
    }
}