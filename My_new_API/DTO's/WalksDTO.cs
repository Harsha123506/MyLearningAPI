namespace My_new_API.DTO_s
{
    public class WalksDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string WalkImageUrl { get; set; }
        public DifficultyDTO Difficulty { get; set; }
        public RegionDTO Region { get; set; }
    }
}
