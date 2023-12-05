using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Helpers
{
    public static class Encryption
    {
        public static string Encrypt(string value)
        {


            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: value,
                salt: Encoding.UTF8.GetBytes("soFic0s@ltpotay_2020_mg"),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));


            return hashed;
        }


    }
}
