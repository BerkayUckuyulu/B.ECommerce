using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password,out byte[] passwordHash, out byte[] passwordSalt)//biz bir password vereceğiz dışarıya iki değer çıkacak.(ref out)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //algoritmanın değişmeyen anahtarıdır.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//passwordun bytenı aldık.
            }
        }
        public static bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt) //sonradan sisteme girmek isteyen kullanıcın şifresini tekrar girmesiyle olşan hashin ilk oluşturulan hashle eşlenip eşlenmediğini kontrol eder.
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }

                }
                return true;
            }
        }
    }
}
