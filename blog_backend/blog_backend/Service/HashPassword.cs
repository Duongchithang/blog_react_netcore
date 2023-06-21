namespace blog_backend.Service
{
    public class HashPassword
    {
        public string HashedPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }
        public bool VertifyPassword(string password, string hashedPassword)
        {
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            if (isPasswordValid == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
