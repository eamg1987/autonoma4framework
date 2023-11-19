using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;


namespace autonoma3Tiempo.Models
{
    public class WeatherData
    {
        public string copyright { get; set; }
        public string use { get; set; }
        public Information information { get; set; }
        public string web { get; set; }
        public string language { get; set; }
        public Locality locality { get; set; }
        public Day day1 { get; set; }
        public Day day2 { get; set; }
        public Dictionary<string, HourData> hour_hour { get; set; }
        // Puedes agregar más propiedades para los demás días o ajustar según sea necesario
    }

    public class Information
    {
        public string temperature { get; set; }
        public string wind { get; set; }
        public string humidity { get; set; }
        public string pressure { get; set; }
    }

    public class Locality
    {
        public string name { get; set; }
        public string url_weather_forecast_15_days { get; set; }
        public string url_hourly_forecast { get; set; }
        public string country { get; set; }
        public string url_country { get; set; }
    }

    public class Day
    {
        public string date { get; set; }
        public int temperature_max { get; set; }
        public int temperature_min { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public int humidity { get; set; }
        public int wind { get; set; }
        public string wind_direction { get; set; }
        public string icon_wind { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
        public string moon_phases_icon { get; set; }
    }
    public class HourData
    {
        public string date { get; set; }
        public string hour_data { get; set; }
        public int temperature { get; set; }
        public string text { get; set; }
        public int humidity { get; set; }
        public int pressure { get; set; }
        public string icon { get; set; }
        public int wind { get; set; }
        public string wind_direction { get; set; }
        public string icon_wind { get; set; }
    }

}
