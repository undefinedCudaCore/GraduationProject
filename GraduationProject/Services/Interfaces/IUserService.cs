namespace GraduationProject.Services.Interfaces
{
    public interface IUserService
    {
        void Register(string username, string password, string role);
        bool Login(string username, string password);
    }
}
