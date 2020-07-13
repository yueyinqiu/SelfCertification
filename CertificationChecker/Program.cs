using System;
using System.IO;
using System.Security.Cryptography;

namespace CertificationChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            RSA rsa = RSA.Create();

            Console.Write("Enter the path of the public key: ");
            var key = Console.ReadLine();
            rsa.ImportRSAPublicKey(File.ReadAllBytes(key), out _);

            Console.Write("Enter the path of the file: ");
            var fileName = Console.ReadLine();

            Console.Write("Enter the path of the signature: ");
            var signName = Console.ReadLine();

            Console.WriteLine();

            using FileStream fileStream = new FileStream(fileName, FileMode.Open);
            var hash = MD5.Create().ComputeHash(fileStream);
            Console.WriteLine("Hash produced. (through md5)");

            var result = rsa.VerifyHash(hash, File.ReadAllBytes(signName),
                HashAlgorithmName.MD5, RSASignaturePadding.Pkcs1);
            Console.WriteLine("Signature checked.");

            Console.WriteLine();

            if (result)
                Console.WriteLine("Certification passed.");
            else
                Console.WriteLine("Certification failed.");

            Console.WriteLine();

            Console.Write("Press enter to exit: ");
            Console.ReadLine();
        }
    }
}
