using System.Security.Cryptography;

namespace TasksApi.Models
{
    /// <summary>
    /// Hash string and verify if string match hash
    /// </summary>
    public class PwdHasher
    {
        private const int _saltSize = 8; 
        private const int _keySize = 16; 
        private const int _iterations = 50000;
        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;

        private const char segmentDelimiter = ':';
        /// <summary>
        /// Hash string and add random salt
        /// </summary>
        /// <param name="secret"></param>
        /// <returns></returns>
        public static string Hash(string secret)
        {
            var salt = RandomNumberGenerator.GetBytes(_saltSize);
            var key = Rfc2898DeriveBytes.Pbkdf2(
                secret,
                salt,
                _iterations,
                _algorithm,
                _keySize
            );
            return string.Join(
                segmentDelimiter,
                Convert.ToHexString(key),
                Convert.ToHexString(salt)
            );
        }
        /// <summary>
        /// Compare string and hash
        /// </summary>
        /// <param name="secret">Comapred string</param>
        /// <param name="hash"></param>
        /// <returns>true if match, false if not</returns>
        public static bool Verify(string secret, string hash)
        {
            var segments = hash.Split(segmentDelimiter);
            var key = Convert.FromHexString(segments[0]);
            var salt = Convert.FromHexString(segments[1]);
            var inputSecretKey = Rfc2898DeriveBytes.Pbkdf2(
                secret,
                salt,
                _iterations,
                _algorithm,
                _keySize
            );
            return key.SequenceEqual(inputSecretKey);
        }
    }
}
