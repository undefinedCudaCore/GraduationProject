namespace GraduationProject.Domain.Models
{
    public class UserResidence
    {
        public Guid UserResidenceId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public int UserInformationId { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}
