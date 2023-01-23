using System;

namespace TechPlacement.Model
{
    public class StudentModel
    {
        public int SId { get; set; }
        public int ClId { get; set; }
        public string EnrollNo { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
    }
}
