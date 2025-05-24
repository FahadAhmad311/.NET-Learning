using System.Text.Json;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public class User
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public string GenerateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                return Convert.ToBase64String(hashBytes);
            }
        }

        public void EncryptData()
        {
            if (!string.IsNullOrEmpty(Password))
                Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(Password));
        }
    }

    public static User? DeserializedUserData(string jsonData, bool isTrustedSource)
    {
        if (!isTrustedSource)
        {
            Console.WriteLine("Deserialization blocked: Untrusted Source");
            return null;
        }
        return JsonSerializer.Deserialize<User>(jsonData);
    }

    public static string SerializeUserData(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name)
            || string.IsNullOrWhiteSpace(user.Email)
            || string.IsNullOrWhiteSpace(user.Password))
        {
            Console.WriteLine("Invalid data: Serialization aborted");
            return string.Empty;
        }

        user.EncryptData();
        return JsonSerializer.Serialize(user);
    }

    public static void Main()
    {
        User user = new User
        {
            Name = "Fahad Ahmad",
            Email = "fahadahmedaz3@gmail.com",
            Password = "123kohat",
        };

        string generatehash = user.GenerateHash();
        string serializeData = SerializeUserData(user);

        Console.WriteLine("Hash: " + generatehash);
        Console.WriteLine("Serialized: " + serializeData);
    }
}
