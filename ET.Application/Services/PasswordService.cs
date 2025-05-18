using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ET.Application.Interfaces;

namespace ET.Application.Services
{
    public class PasswordService : IPasswordService
       
    {

        public const int SaltSize = 16;
        public const int KeySize = 32;
        private const int Iterations = 10000;
        private const char SegmentDelimiter = ':';

        public string HashPassword(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                Iterations,
                HashAlgorithmName.SHA256);

            var key = algorithm.GetBytes(KeySize);
            var salt = algorithm.Salt;

            // Store iteration count, salt and key all in one string
            return $"{Iterations}{SegmentDelimiter}{Convert.ToBase64String(salt)}{SegmentDelimiter}{Convert.ToBase64String(key)}";
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var segments = hashedPassword.Split(SegmentDelimiter);
            if (segments.Length != 3)
                return false;

            var iterations = int.Parse(segments[0]);
            var salt = Convert.FromBase64String(segments[1]);
            var key = Convert.FromBase64String(segments[2]);

            using var algorithm = new Rfc2898DeriveBytes(
                providedPassword,
                salt,
                iterations,
                HashAlgorithmName.SHA256);

            var keyToCheck = algorithm.GetBytes(KeySize);
            return CryptographicOperations.FixedTimeEquals(key, keyToCheck);
        }
    }
}
