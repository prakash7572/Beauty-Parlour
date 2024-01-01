namespace Beauty.Admin.Models
{
    public class News
    {
        public int ID { get; set; }
        public string? SubTitle { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        //public DateTime? CreateDate { get; set; }
        public bool? MakeupType { get; set; }
    }
}
