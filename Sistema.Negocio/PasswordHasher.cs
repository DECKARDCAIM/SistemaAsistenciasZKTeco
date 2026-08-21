using System;
using System.Security.Cryptography;
using System.Text;

namespace Sistema.Negocio
{
    public static class PasswordHasher
    {
        private const int DefaultIterations = 36000;
        private const int KeySize = 32; // 256 bits

        /// <summary>
        /// Verifica una contraseña en texto plano contra un hash almacenado (formato Django PBKDF2 o texto plano de respaldo).
        /// </summary>
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash))
            {
                return false;
            }

            // Si el hash almacenado está en texto plano directamente
            if (password == storedHash)
            {
                return true;
            }

            // Formato Django: pbkdf2_sha256$iterations$salt$hash
            string[] parts = storedHash.Split('$');
            if (parts.Length == 4 && parts[0] == "pbkdf2_sha256")
            {
                if (!int.TryParse(parts[1], out int iterations))
                {
                    iterations = DefaultIterations;
                }

                string salt = parts[2];
                string expectedHash = parts[3];

                byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
                using (var rfc = new Rfc2898DeriveBytes(password, saltBytes, iterations, HashAlgorithmName.SHA256))
                {
                    byte[] hashBytes = rfc.GetBytes(KeySize);
                    string computedHash = Convert.ToBase64String(hashBytes);
                    return SlowEquals(computedHash, expectedHash);
                }
            }

            return false;
        }

        /// <summary>
        /// Genera un hash PBKDF2 compatible con Django y BioTime.
        /// </summary>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }

            string salt = GenerateSalt(12);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            int iterations = DefaultIterations;

            using (var rfc = new Rfc2898DeriveBytes(password, saltBytes, iterations, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = rfc.GetBytes(KeySize);
                string hashBase64 = Convert.ToBase64String(hashBytes);
                return $"pbkdf2_sha256${iterations}${salt}${hashBase64}";
            }
        }

        private static string GenerateSalt(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var bytes = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            var sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[bytes[i] % chars.Length]);
            }
            return sb.ToString();
        }

        private static bool SlowEquals(string a, string b)
        {
            if (a == null || b == null) return false;
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }
    }
}
