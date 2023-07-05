namespace VamiroShop.User;

public interface IUsersManager
{
    User CurrentUser { get; }
    void AddUser(string name, string password);
    bool AuthorizeUser(string name, string password);
    bool CheckUserByName(string name);
}