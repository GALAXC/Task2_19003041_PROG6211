using System;
using System.IO;
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

        private void loginQuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            StreamReader loginOutput = new StreamReader("../../LoginDetails.txt");
            Boolean usernameFound = false;
            for (int i = 0; i < Weather.TotalLines("../../LoginDetails.txt") / 3; i++)
            {
                String tempUsername = loginOutput.ReadLine();
                if (tempUsername == loginUsernameBox.Text)
                {
                    usernameFound = true;
                    String tempPassword = loginOutput.ReadLine();
                    if (tempPassword == loginPasswordBox.Text)
                    {
                        switch (loginOutput.ReadLine())
                        {
                            case "1":
                                isUserAdmin = true;
                                break;

                            default:
                                isUserAdmin = false;
                                break;
                        }
                        loggedInUser = tempUsername;
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
                loginOutput.ReadLine();
                loginOutput.ReadLine();
            }
            if (usernameFound == false)
            {
                MessageBox.Show("The username you have entered cannot be found.");
            }
        }
    }
}