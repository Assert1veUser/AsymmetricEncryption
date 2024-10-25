using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Генерация пары ключей
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Сохранение публичного ключа в файл
            string publicKey = rsa.ToXmlString(false);
            File.WriteAllText("publicKey.xml", publicKey);

            // Сохранение приватного ключа в файл
            string privateKey = rsa.ToXmlString(true);
            File.WriteAllText("privateKey.xml", privateKey);

            Console.WriteLine("Ключи успешно сгенерированы и сохранены.");
        }

        // Шифрование сообщения
        string originalMessage = "Привет мир!";
        byte[] encryptedMessage = EncryptMessage(originalMessage, "publicKey.xml");

        Console.WriteLine("Зашифрованное сообщение:");
        Console.WriteLine(Convert.ToBase64String(encryptedMessage));

        // Дешифрование сообщения
        string decryptedMessage = DecryptMessage(encryptedMessage, "privateKey.xml");

        Console.WriteLine("Расшифрованное сообщение:");
        Console.WriteLine(decryptedMessage);
    }

    static byte[] EncryptMessage(string message, string publicKeyPath)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Загрузка публичного ключа
            string publicKey = File.ReadAllText(publicKeyPath);
            rsa.FromXmlString(publicKey);

            // Шифрование сообщения
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] encryptedMessage = rsa.Encrypt(messageBytes, false);

            return encryptedMessage;
        }
    }

    static string DecryptMessage(byte[] encryptedMessage, string privateKeyPath)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Загрузка приватного ключа
            string privateKey = File.ReadAllText(privateKeyPath);
            rsa.FromXmlString(privateKey);

            // Дешифрование сообщения
            byte[] decryptedMessage = rsa.Decrypt(encryptedMessage, false);
            string message = Encoding.UTF8.GetString(decryptedMessage);

            return message;
        }
    }
}