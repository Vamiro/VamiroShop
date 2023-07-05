using System.Net;
using Newtonsoft.Json;

namespace VamiroShop.User;

public class UsersManager : IUsersManager
{
    private string UserDir = "../../../Users.json";
    private List<User>? _users = new List<User>();
    private bool IsNullOrEmpty => _users?.Any() != true;
    public User CurrentUser { get; private set; }
    

    public UsersManager()
    {
        CurrentUser = new User("", "", 0, 0);;
        if (!File.Exists(UserDir))
        {
            File.Create(UserDir);
        }
        LoadFromJson();
    }

    public void AddUser(string name, string password)
    {
        _users.Add(new User(name, password));
        SaveToJson();
        CurrentUser = _users.Last();
    }

    public bool AuthorizeUser(string name, string password)
    {
        foreach (var user in _users)
        {
            if (user.Name == name && user.Password == password)
            {
                CurrentUser = user;
                return true;
            }
        }

        return false;
    }
    
    public bool CheckUserByName(string name)
    {
        // if (_isNullOrEmpty)
        // {
        //     return false;
        // }
        foreach (var user in _users)
        {
            if (user.Name == name)
            {
                return true;
            }
        }

        return false;
    }
    
    private void LoadFromJson()
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.NullValueHandling = NullValueHandling.Ignore;
        using StreamReader rd = new StreamReader("../../../Users.json");
        using (JsonReader reader = new JsonTextReader(rd))
        {
            _users = serializer.Deserialize<List<User>>(reader);
        }
        if (IsNullOrEmpty)
        {
            _users = new List<User>();
        }
    }
    
    private void SaveToJson()
    {
        JsonSerializer serializer = new JsonSerializer();
        serializer.NullValueHandling = NullValueHandling.Ignore;
        using StreamWriter sw = new StreamWriter("../../../Users.json");
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            serializer.Serialize(writer, _users);
        }
    }
}