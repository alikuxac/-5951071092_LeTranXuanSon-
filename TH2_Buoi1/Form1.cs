using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace TH2_Buoi1
{
    public partial class Form1 : Form
    {
        const string APPID = "";
        string CityID = "1566083";
        public Form1()
        {
            InitializeComponent();
            getWeather(CityID);
            // getForcast(CityID);
        }

        void getWeather(string city)
        {
            using (WebClient web = new WebClient())
            {
                //&units=metric&cnt=6
                String url = string.Format("https://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}&units=metric&cnt=6", city, APPID);

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<Weather.root>(json);

                Weather.root outPut = result;

                lbl_textCity.Text = String.Format("{0}", outPut.name);
                lbl_Country.Text = String.Format("{0}", outPut.sys.country);
                lbl_DoCe.Text = String.Format("{0} \u00B0" + "C", outPut.main.temp);
            }
        }
        //void getForcast(string city)
        //{
        //    int day = 5;
        //    string url = String.Format("https://api.openweathermap.org/data/2.5/forcasts/daily?id={0}&units=metric&cnt={1}&appid={2}", city, day, APPID);
        //    using (WebClient web = new WebClient())
        //    {


        //        var json = web.DownloadString(url);

        //        var Object = JsonConvert.DeserializeObject<WeatherForCasts>(json);
        //        WeatherForCasts forcasts = Object;

        //        lbl_Con.Text = string.Format("{0}", forcasts.list[0].weather[0].main);
        //        lbl_Des.Text = string.Format("{0}", forcasts.list[0].weather[0].descriptions);
        //        lbl_Des2.Text = string.Format("{0} \u00B0" + "C", forcasts.list[0].temp);
        //        lbl_speed.Text = string.Format("{0}", forcasts.list[0].speed);

        //    }
        //}
    }
}
