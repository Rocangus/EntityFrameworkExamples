namespace EntityFrameworkExamples.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int StudentId { get; set; }

        //Navigationproperty not in database
        public Student Student { get; set; }
    }
}