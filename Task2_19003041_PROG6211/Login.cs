﻿using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Task2_19003041_PROG6211
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static String loggedInUser = "";
        public static Boolean isUserAdmin = false;
        private Boolean passwordButtonStatus = true;

        private void Login_Load(object sender, EventArgs e)
        {
            loginWelcomeLabel.Location = new System.Drawing.Point((this.Size.Width / 2) - (loginWelcomeLabel.Size.Width / 2), 9);
        }

        private void loginQuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string[] login = System.IO.File.ReadAllLines("../../LoginDetails.txt");
            if (login.Contains(loginUsernameBox.Text))
            {
                for (int i = 0; i < login.Length; i++)
                {
                    if (loginUsernameBox.Text == login[i])
                    {
                        if (login[i + 1] == loginPasswordBox.Text)
                        {
                            String tempPassword = login[i + 1];
                            loggedInUser = loginUsernameBox.Text;
                            if (login[i + 2] == "1")
                            {
                                isUserAdmin = true;
                            }
                            else
                            {
                                isUserAdmin = false;
                            }
                            this.Hide();
                            Report newReport = new Report();
                            newReport.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("The password you have entered for this username is incorrect.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("The username you have entered cannot be found.");
            }
        }

        private void showHidePasswordButton_Click(object sender, EventArgs e)
        {
            //Password button status = True if the password is hidden
            if (passwordButtonStatus == true)
            {
                passwordButtonStatus = false;
                loginPasswordBox.UseSystemPasswordChar = false;
                showHidePasswordButton.BackgroundImage = Task2_19003041_PROG6211.Properties.Resources.HidePassword;
            }
            else
            {
                passwordButtonStatus = true;
                loginPasswordBox.UseSystemPasswordChar = true;
                showHidePasswordButton.BackgroundImage = Task2_19003041_PROG6211.Properties.Resources.ShowPassword;
            }
        }
    }
}