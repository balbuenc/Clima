using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clima.Models.ViewModels
{
    public class Country
    {
        public int CountryId { get; set; }
        public List<City> Cities { get; set; }
        public int SelectedCityId { get; set; }
        public string SelectedCityName
        {
            get
            {
                if (this.Cities != null && this.SelectedCityId > 0)
                {
                    return Cities.Where(n => n.Id == this.SelectedCityId).Select(s => s.CityName).FirstOrDefault();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }

    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
    }
}