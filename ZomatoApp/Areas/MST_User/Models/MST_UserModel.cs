namespace ZomatoApp.Areas.MST_User.Models
{
    public class MST_UserModel
    {

        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNo { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }

        public int CityID { get; set; }

        public string CityName { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public int StateID { get; set; }

        public string StateName { get; set; }



    }
}
