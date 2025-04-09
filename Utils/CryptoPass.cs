using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Utils
{
    internal static class CryptoPass
    {
        private const int SaltSize = 16; // 128bits
        private const int KeySize = 32; // 256bits
        private const int Iterations = 100_000;

        public static byte[] Encrypt(string contraseña)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[SaltSize];
            rng.GetBytes(salt);

            using var pbkdf2 = new Rfc2898DeriveBytes(contraseña, salt, Iterations, HashAlgorithmName.SHA512);
            byte[] key = pbkdf2.GetBytes(KeySize);

            byte[] hashFinal = new byte[SaltSize + KeySize];
            Buffer.BlockCopy(salt, 0, hashFinal, 0, SaltSize);
            Buffer.BlockCopy(key, 0, hashFinal, SaltSize, KeySize);

            return hashFinal;
        }

        public static bool Verify(string contraseña, byte[] hashGuardado)
        {
            if (hashGuardado.Length != SaltSize + KeySize)
                return false;

            byte[] salt = new byte[SaltSize];
            byte[] keySaved = new byte[KeySize];

            Buffer.BlockCopy(hashGuardado,0,salt,0,SaltSize);
            Buffer.BlockCopy(hashGuardado,SaltSize,keySaved,0, KeySize);

            using var pbkdf2 = new Rfc2898DeriveBytes(contraseña, salt, Iterations, HashAlgorithmName.SHA512);
            byte[] keyVerified = pbkdf2.GetBytes(KeySize);

            return CryptographicOperations.FixedTimeEquals(keySaved, keyVerified);
        }
    }
}
