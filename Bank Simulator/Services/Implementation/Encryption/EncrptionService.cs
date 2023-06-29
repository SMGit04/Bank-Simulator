using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;
using Org.BouncyCastle.OpenSsl;
using System.Text;
using Bank_Simulator.Services.Interfaces.Encryption;

namespace Bank_Simulator.Services.Implementation.Encryption
{
    public class EncrptionService : IEncrptionService

    {
        private readonly IEncryptionKeyReaderService _encryptionKeyReaderService;
        public EncrptionService(IEncryptionKeyReaderService encryptionKeyReaderService)
        {
            _encryptionKeyReaderService = encryptionKeyReaderService;
        }

        public string Encrypt(string text)
        {
            var _publicKey = _encryptionKeyReaderService.GetPublicKeyFromFile(@".\keys\publicKey.pem");
            var encryptedBytes = _publicKey.Encrypt(Encoding.UTF8.GetBytes(text), false);
            return Convert.ToBase64String(encryptedBytes);
        }

        public string Decrypt(string encrypted)
        {
            var _privateKey = _encryptionKeyReaderService.GetPrivateKeyFromFile(@".\keys\privateKey.pem");
            var decryptedBytes = _privateKey.Decrypt(Convert.FromBase64String(encrypted), false);
            return Encoding.UTF8.GetString(decryptedBytes, 0, decryptedBytes.Length);
        }
    }


}
