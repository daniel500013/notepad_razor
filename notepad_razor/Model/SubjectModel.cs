namespace notepad_razor.Model
{
    public class SubjectModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Subject { get; set; }
        public int UserId { get; set; }
        public virtual UserModel? Users { get; set; }
    }
}
