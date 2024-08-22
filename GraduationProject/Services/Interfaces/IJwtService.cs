namespace GraduationProject.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string username);
    }
}
