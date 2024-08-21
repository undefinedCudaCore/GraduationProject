namespace GraduationProject.Domain.Models
{
    public class Residence
    {
        public Guid ResidenceId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public Guid InformationId { get; set; }
        public Information Information { get; set; }
    }
}
