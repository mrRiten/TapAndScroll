namespace TapAndScroll.Core.Models
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiatesHours { get; set; }
    }
}
