namespace Friends_web_api_v1.Models
{
    public class UserDbo
    {
        public string NickName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string? VkLink { get; set; }
        public string? TgLink { get; set; }
        public string? Discription { get; set; }
    }
}
