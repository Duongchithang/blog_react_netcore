namespace blog_backend.IResository
{
    public interface IJsonWebToken
    {
        public string GenerateJsonWebToken();
        public bool VerifyToken(string token);
    }
}
