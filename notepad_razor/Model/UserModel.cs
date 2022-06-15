namespace notepad_razor.Model
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "nickname")]
        public string NickName { get; set; }
        [Required]
        [Display(Name = "password")]
        public string Password { get; set; }
        [Display(Name = "HashedPassword")]
        public string HashedPassword { get; set; } = string.Empty;
        [Required]
        [Display(Name = "email")]
        public string Email { get; set; }
        [Display(Name = "user_class")]
        [Range(1, 4)]
        public int UserClass { get; set; }
        [Display(Name = "permissions")]
        public string Permission { get; set; } = "User";
    }
}
