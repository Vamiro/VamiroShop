namespace VamiroShop.User;

public class User
{
    public readonly string Name;
    public readonly string Password;
    public readonly int Age; // FOR SOME PRODUCTS THAT GOT AGE RESTRICTION
    public readonly int Level; // 0 - GUEST, 1 - DEFAULTE, 2 - MANAGER, 3 - ADMIN
    
    public User(string name, string password, int age = 0, int level = 1)
    {
        Name = name;
        Password = password;
        Age = age;
        Level = level;
    }
}