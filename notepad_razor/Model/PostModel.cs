namespace notepad_razor.Model
{
    [Table("Post")]
    public class PostModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string? Subject { get; set; }
    }
}
