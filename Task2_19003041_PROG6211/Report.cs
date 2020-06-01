using System;
using System.Collections;
using System.Windows.Forms;

namespace Task2_19003041_PROG6211
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private static Boolean firstTimeLoad = true;

        private void Report_Load(object sender, EventArgs e)
        {
            populateCityComboBox();
            citiesSelected.Add("Cape Town");
            citiesSelected.Add("Johannesburg");
            loginStrip.Text = "Logged in as: " + Login.loggedInUser;
            if (firstTimeLoad == true)
            {
                label6.Text = "Welcome, " + Login.loggedInUser + ".";
                label6.Location = new System.Drawing.Point((557 - (label6.Size.Width / 2)), 37);
                firstTimeLoad = false;
            }
            if (Login.isUserAdmin == false)
            {
                printReportButton.Visible = false;
                userTypeLoginStrip.Text = "User Type: Regular";
                editStrip.Visible = false;
                searchButton.Location = new System.Drawing.Point(65, 319);
            }
        }

        private ArrayList citiesSelected = new ArrayList();

        //
        //Code for Report section
        //

        //Populate the report city selection combo box
        private void populateCityComboBox()
        {
            cityComboBox.Items.Clear();
            for (int i = 0; i < (Weather.getCityNameCount()); i++)
            {
                if (cityComboBox.Items.Contains(Weather.getCityName(i)))
                {
                }
                else
                {
                    cityComboBox.Items.Add(Weather.getCityName(i));
                }
            }
        }

        //Update selected cities
        private void cityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (citiesSelected.Contains(cityComboBox.SelectedItem))
            {
                citiesSelected.Remove(cityComboBox.SelectedItem);
            }
            else
            {
                citiesSelected.Add(cityComboBox.SelectedItem);
            }
            cityReportBox.Clear();
            for (int j = 0; j < citiesSelected.Count; j++)
            {
                if (j == 0)
                {
                    cityReportBox.Text += citiesSelected[j];
                }
                else
                {
                    cityReportBox.Text += ", " + citiesSelected[j];
                }
            }
            if (cityReportBox.Text == "")
            {
                cityReportBox.Text = "None";
            }
        }

        //Button to clear cities selected
        private void clearCitiesSelected_Click(object sender, EventArgs e)
        {
            citiesSelected.Clear();
            cityReportBox.Text = "None";
        }

        //Update start date selected
        private void startDateBox_ValueChanged(object sender, EventArgs e)
        {
            datesSelected.Text = startDateBox.Value.ToString("yyyy/MM/dd") + " - " + endDateBox.Value.ToString("yyyy/MM/dd");
        }

        //Update end date selected
        private void endDateBox_ValueChanged(object sender, EventArgs e)
        {
            datesSelected.Text = startDateBox.Value.ToString("yyyy/MM/dd") + " - " + endDateBox.Value.ToString("yyyy/MM/dd");
        }

        //Initiate process to retrieve report results
        private void searchButton_Click(object sender, EventArgs e)
        {
            cityComboBox.Text = "Select City...";
            populateReportTable();
        }

        //Retrieve and compare the results for the weather report
        private void populateReportTable()
        {
            int lowMinTemp = 0;
            int highMinTemp = 0;
            int lowMaxTemp = 0;
            int highMaxTemp = 0;
            int lowPrecip = 0;
            int highPrecip = 0;
            int lowHumid = 0;
            int highHumid = 0;
            int lowSpeed = 0;
            int highSpeed = 0;
            reportTable.Rows.Clear();
            if (citiesSelected.Count != 0)
            {
                for (int i = 0; i < citiesSelected.Count; i++)
                {
                    for (int j = 0; j < Weather.getCityNameCount(); j++)
                    {
                        if (Weather.getCityName(j) == Convert.ToString(citiesSelected[i]))
                        {
                            if (Weather.getWeatherDate(j) >= startDateBox.Value && Weather.getWeatherDate(j) <= endDateBox.Value)
                            {
                                if (reportTable.Rows.Count == 0)
                                {
                                    //Initiate values in the lowest and highest section
                                    lowMinTemp = Convert.ToInt32(Weather.getMinTemp(j));
                                    highMinTemp = Convert.ToInt32(Weather.getMinTemp(j));
                                    lowMaxTemp = Convert.ToInt32(Weather.getMaxTemp(j));
                                    highMaxTemp = Convert.ToInt32(Weather.getMaxTemp(j));
                                    lowPrecip = Convert.ToInt32(Weather.getPrecipitation(j));
                                    highPrecip = Convert.ToInt32(Weather.getPrecipitation(j));
                                    lowHumid = Convert.ToInt32(Weather.getHumidity(j));
                                    highHumid = Convert.ToInt32(Weather.getHumidity(j));
                                    lowSpeed = Convert.ToInt32(Weather.getWindSpeed(j));
                                    highSpeed = Convert.ToInt32(Weather.getWindSpeed(j));
                                }
                                else
                                {
                                    //Update values if lowest and highest section not empty
                                    if (Convert.ToInt32(Weather.getMinTemp(j)) < lowMinTemp)
                                    {
                                        lowMinTemp = Convert.ToInt32(Weather.getMinTemp(j));
                                    }

                                    if (Convert.ToInt32(Weather.getMinTemp(j)) > highMinTemp)
                                    {
                                        highMinTemp = Convert.ToInt32(Weather.getMinTemp(j));
                                    }

                                    if (Convert.ToInt32(Weather.getMaxTemp(j)) < lowMaxTemp)
                                    {
                                        lowMaxTemp = Convert.ToInt32(Weather.getMaxTemp(j));
                                    }

                                    if (Convert.ToInt32(Weather.getMaxTemp(j)) > highMaxTemp)
                                    {
                                        highMaxTemp = Convert.ToInt32(Weather.getMaxTemp(j));
                                    }

                                    if (Convert.ToInt32(Weather.getPrecipitation(j)) < lowPrecip)
                                    {
                                        lowPrecip = Convert.ToInt32(Weather.getPrecipitation(j));
                                    }

                                    if (Convert.ToInt32(Weather.getPrecipitation(j)) > highPrecip)
                                    {
                                        highPrecip = Convert.ToInt32(Weather.getPrecipitation(j));
                                    }

                                    if (Convert.ToInt32(Weather.getHumidity(j)) < lowHumid)
                                    {
                                        lowHumid = Convert.ToInt32(Weather.getHumidity(j));
                                    }

                                    if (Convert.ToInt32(Weather.getHumidity(j)) > highHumid)
                                    {
                                        highHumid = Convert.ToInt32(Weather.getHumidity(j));
                                    }

                                    if (Convert.ToInt32(Weather.getWindSpeed(j)) < lowSpeed)
                                    {
                                        lowSpeed = Convert.ToInt32(Weather.getWindSpeed(j));
                                    }

                                    if (Convert.ToInt32(Weather.getWindSpeed(j)) > highSpeed)
                                    {
                                        highSpeed = Convert.ToInt32(Weather.getWindSpeed(j));
                                    }
                                }
                                //Populate the table with the report
                                reportTable.Rows.Add(Weather.getCityName(j), Weather.getWeatherDate(j).ToShortDateString(), Weather.getMinTemp(j), Weather.getMaxTemp(j), Weather.getPrecipitation(j), Weather.getHumidity(j), Weather.getWindSpeed(j));

                                lowestMinTemp.Text = Convert.ToString(lowMinTemp) + " °C";
                                highestMinTemp.Text = Convert.ToString(highMinTemp) + " °C";

                                lowestMaxTemp.Text = Convert.ToString(lowMaxTemp) + " °C";
                                highestMaxTemp.Text = Convert.ToString(highMaxTemp) + " °C";

                                lowestPrecip.Text = Convert.ToString(lowPrecip) + " %";
                                highestPrecip.Text = Convert.ToString(highPrecip) + " %";

                                lowestHumid.Text = Convert.ToString(lowHumid) + " %";
                                highestHumid.Text = Convert.ToString(highHumid) + " %";

                                lowestWind.Text = Convert.ToString(lowSpeed) + " km/h";
                                highestWind.Text = Convert.ToString(highSpeed) + " km/h";
                            }
                        }
                    }
                }
                //Reset report and display error
                if (reportTable.Rows.Count == 0)
                {
                    lowestMinTemp.Text = "";
                    highestMinTemp.Text = "";
                    lowestMaxTemp.Text = "";
                    highestMaxTemp.Text = "";
                    lowestPrecip.Text = "";
                    highestPrecip.Text = "";
                    lowestHumid.Text = "";
                    highestHumid.Text = "";
                    lowestWind.Text = "";
                    highestWind.Text = "";
                    MessageBox.Show("No Results Found.");
                }
            }
            else
            {
                MessageBox.Show("You have not selected any cities. \nTo obtain results, please select one or more cities.");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void captureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Capture newCapture = new Capture();
            newCapture.ShowDialog();
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            firstTimeLoad = true;
            this.Hide();
            Login newLogin = new Login();
            newLogin.ShowDialog();
            this.Close();
        }
    }
}