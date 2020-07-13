using System;
using System.IO;
using System.Security.Cryptography;

namespace SelfCertification
{
    class Program
    {
        static void Main(string[] args)
        {
            RSA rsa = RSA.Create();

            Console.Write("Enter the path of your private key: ");
            var key = Console.ReadLine();
            rsa.ImportRSAPrivateKey(File.ReadAllBytes(key), out _);

            Console.Write("Enter the path of your file: ");
            var fileName = Console.ReadLine();

            Console.WriteLine();

            using FileStream fileStream = new FileStream(fileName, FileMode.Open);
            var hash = MD5.Create().ComputeHash(fileStream);
            Console.WriteLine("Hash produced. (through md5)");

            var sign = rsa.SignHash(hash, HashAlgorithmName.MD5, RSASignaturePadding.Pkcs1);
            Console.WriteLine("Signature produced.");

            File.WriteAllBytes("signature", sign);
            Console.WriteLine("Signature saved at './signature'.");

            Console.WriteLine();

            Console.WriteLine("Here are the base64 value of the signature: ");
            Console.WriteLine(Convert.ToBase64String(sign));

            Console.WriteLine();

            Console.Write("Press enter to exit: ");
            Console.ReadLine();
        }
    }
}