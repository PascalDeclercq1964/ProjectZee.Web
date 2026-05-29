namespace ProjectZee.Web
{
    public class UserState
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsLoggedIn => !string.IsNullOrEmpty(Username);

        // Optioneel: Een methode om de boel te resetten bij uitloggen
        public void Clear()
        {
            Username = string.Empty;
            Email = string.Empty;
        }
    }
}
