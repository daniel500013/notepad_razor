namespace notepad_razor.Model
{
    public class SubjectModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Subject { get; set; }
		[Required]
        public int? UserID { get; set; }
    }
}
