using System;
using System.Collections;

namespace Task2_19003041_PROG6211
{
    public static class Weather
    {
        private static ArrayList cityNames = new ArrayList();
        private static ArrayList weatherDates = new ArrayList();
        private static ArrayList minTemps = new ArrayList();
        private static ArrayList maxTemps = new ArrayList();
        private static ArrayList precips = new ArrayList();
        private static ArrayList humidities = new ArrayList();
        private static ArrayList windSpeeds = new ArrayList();

        //Getters and Setters
        public static void addWeatherDate(object value)
        {
            weatherDates.Add(value);
        }

        public static DateTime getWeatherDate(int value)
        {
            return Convert.ToDateTime(weatherDates[value]);
        }

        public static void addMinTemp(object value)
        {
            minTemps.Add(value);
        }

        public static string getMinTemp(int value)
        {
            return Convert.ToString(minTemps[value]);
        }

        public static void addMaxTemp(object value)
        {
            maxTemps.Add(value);
        }

        public static string getMaxTemp(int value)
        {
            return Convert.ToString(maxTemps[value]);
        }

        public static void addPrecipitation(object value)
        {
            precips.Add(value);
        }

        public static string getPrecipitation(int value)
        {
            return Convert.ToString(precips[value]);
        }

        public static void addHumidity(object value)
        {
            humidities.Add(value);
        }

        public static string getHumidity(int value)
        {
            return Convert.ToString(humidities[value]);
        }

        public static void addWindSpeed(object value)
        {
            windSpeeds.Add(value);
        }

        public static string getWindSpeed(int value)
        {
            return Convert.ToString(windSpeeds[value]);
        }

        public static void addCityName(object value)
        {
            cityNames.Add(value);
        }

        public static string getCityName(int value)
        {
            return Convert.ToString(cityNames[value]);
        }

        public static int getCityNameCount()
        {
            return cityNames.Count;
        }

        //Test values for program
        public static void populateArrayLists()
        {
            cityNames.Add("Cape Town");
            cityNames.Add("Cape Town");
            cityNames.Add("Johannesburg");
            cityNames.Add("Johannesburg");
            cityNames.Add("Durban");

            weatherDates.Add("2020/03/06 19:38:30");
            weatherDates.Add("2020/05/19 19:38:30");
            weatherDates.Add("2020/01/07 19:38:30");
            weatherDates.Add("2020/09/21 19:38:30");
            weatherDates.Add("2020/04/15 19:38:30");

            minTemps.Add(76);
            minTemps.Add(59);
            minTemps.Add(28);
            minTemps.Add(17);
            minTemps.Add(21);

            maxTemps.Add(96);
            maxTemps.Add(79);
            maxTemps.Add(48);
            maxTemps.Add(37);
            maxTemps.Add(67);

            precips.Add(12);
            precips.Add(14);
            precips.Add(16);
            precips.Add(19);
            precips.Add(24);

            humidities.Add(50);
            humidities.Add(60);
            humidities.Add(70);
            humidities.Add(80);
            humidities.Add(40);

            windSpeeds.Add(25);
            windSpeeds.Add(35);
            windSpeeds.Add(45);
            windSpeeds.Add(55);
            windSpeeds.Add(40);
        }
    }
}