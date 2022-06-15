namespace notepad_razor.Model
{
    public class SubjectModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Subject { get; set; }

        public int? UserID { get; set; } 
        public virtual UserModel? UserModel { get; set; }
    }
}
