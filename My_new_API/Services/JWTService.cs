namespace My_new_API.Services
{
    public class JWTService
    {
        public JWTService() { }
        public string GenerateToken(string username, string role)
        {
            return $"TokenForUser:{username},Role:{role}";
        }
    }
}
