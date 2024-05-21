namespace ZomatoApp.Areas.LOC_City.Models
{
    public class LOC_CityModel
    {

        public int CityID { get; set; }

        public string CityName { get; set; }

        public int StateID { get; set; }

        public string StateName { get; set; }

        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }

    public class LOC_CityDropDownModel
    {
        public int CityID { get; set;}

        public string CityName { get; set; }
    }

}
