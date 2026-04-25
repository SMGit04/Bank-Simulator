using System.Security.Cryptography;

namespace Bank_Simulator.Services.Interfaces.Encryption
{
    public interface IEncryptionKeyReaderService
    {
        public RSACryptoServiceProvider GetPrivateKeyFromFile(string privateKeyPem);
        public RSACryptoServiceProvider GetPublicKeyFromFile(string publicKeyPem);
    }
}
