using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace passagens_backend
{
    public class Settings
    {
        public static string Secret = "nfjdsk4_Lkll!!@d-8a!s32H4-";

        public static string GenerateHash(string senha)
        {
            byte[] salt = Encoding.ASCII.GetBytes("9JF320932");

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 32
            ));

            return hashed;
        }
    }
}
