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
		public static string GeneratePasswordHash(string input,string saltPre, string saltPost)
		{
			var uEncode = new UnicodeEncoding();
			byte[] bytClearString = uEncode.GetBytes(saltPre + input + saltPost);

			using (var sha = new SHA512Managed())
			{
				byte[] hash = sha.ComputeHash(bytClearString);
				return Convert.ToBase64String(hash);
			}
		}
        public static string GenerateUnsafeHash(string input)
        {
            var saltPre = "1273";
            var saltPost = "rkflstr";
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
