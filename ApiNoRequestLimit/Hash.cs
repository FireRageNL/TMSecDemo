using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIDemo
{
    public class Hash
    {
        public static string GenerateHash(string input)
        {
            var saltPre = getSalt();
            var saltPost = getSalt();
            var uEncode = new UnicodeEncoding();
            byte[] bytClearString = uEncode.GetBytes(saltPre + input + saltPost);

            using (var sha = new SHA512Managed())
            {
                byte[] hash = sha.ComputeHash(bytClearString);
                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string username, string password)
        {

            Dictionary<string, string> passwordDictionary = new Dictionary<string, string>();
            passwordDictionary.Add("test", "rNxzWTm6G6m50rz3goDdVsQWYFTvrwcFSwpEN4MtHcf2hhy6DDzpnPqSRxXSsYDjSVmh6zbWog4v+mstWl//oQ==");
            passwordDictionary.Add("testing", "dYJFTscefS5dOhEwULTYrJ/VLoTiNEF5A7HEe6jL2A3J6ggAcOwQvINdqEuyukmfxHqVQ+fwpb7AtcGVdZHToA==");

            if (passwordDictionary.ContainsKey(username))
            {
                return GenerateUnsafeHash(password) == passwordDictionary[username];
            }
            return false;
        }

        public static string GenerateUnsafeHash(string input)
        {
            var saltPre = "aaaaaa";
            var saltPost = "aaaaaaaaaaaa";
            var uEncode = new UnicodeEncoding();
            byte[] bytClearString = uEncode.GetBytes(saltPre + input + saltPost);

            using (var sha = new SHA512Managed())
            {
                byte[] hash = sha.ComputeHash(bytClearString);
                return Convert.ToBase64String(hash);
            }

        }

        public static string getSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }
    }
}
