namespace My_new_API.Models
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string WalkImageUrl { get; set; }
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }

    }
}