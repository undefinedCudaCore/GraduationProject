namespace GraduationProject.Domain.Models
{
    public class Residence
    {
        public Residence(Guid residenceId, string city, string street, string houseNumber, string apartmentNumber, Guid informationId, Information information)
        {
            ResidenceId = residenceId;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
            InformationId = informationId;
            Information = information;
        }

        public Residence()
        {

        }

        public Guid ResidenceId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public Guid InformationId { get; set; }
        public Information Information { get; set; }
    }
}
