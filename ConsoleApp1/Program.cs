using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            Regex regexUsername = new Regex(@"^[a-zA-Z]{8}?");
            Regex regexPassword = new Regex(@"^[A-Z]{1}?[a-zA-Z]{7}?[!-/_]{1}");
            var username = Console.ReadLine();
            var password = Console.ReadLine();
            if (regexUsername.IsMatch(username) && regexPassword.IsMatch(password))
            {
                foreach (var item in users)
                {
                    if (item.Username != username)
                    {
                        users.Add(new User(username, password));
                    }
                    else
                    {
                        Console.WriteLine("This username is using");
                    }
                }
                Console.WriteLine("Successfull");
            }
            else
            {
                Console.WriteLine("Invalid username or password format");
            }
            string json = JsonConvert.SerializeObject(users);
            Console.WriteLine(json);

            using (StreamWriter streamWriter = new StreamWriter("test.json"))
            {
                streamWriter.WriteLine(json);
            }
        }
    }
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
