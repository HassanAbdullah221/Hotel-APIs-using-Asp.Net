namespace TrainingProject.Data
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Rating { get; set; }
        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
