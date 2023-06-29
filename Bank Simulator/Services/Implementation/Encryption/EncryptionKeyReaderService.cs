using Bank_Simulator.Services.Interfaces.Encryption;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;

namespace Bank_Simulator.Services.Implementation.Encryption
{
    public class EncryptionKeyReaderService : IEncryptionKeyReaderService
    {

        public RSACryptoServiceProvider GetPrivateKeyFromFile(string privateKeyPem)
        {
            using (TextReader privateKeyTextReader = new StringReader(File.ReadAllText(privateKeyPem)))
            {
                AsymmetricCipherKeyPair readKeyPair = (AsymmetricCipherKeyPair)new PemReader(privateKeyTextReader).ReadObject();

                RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)readKeyPair.Private);
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
                csp.ImportParameters(rsaParams);
                return csp;
            }
        }

        public RSACryptoServiceProvider GetPublicKeyFromFile(string publicKeyPem)
        {
            using (TextReader publicKeyTextReader = new StringReader(File.ReadAllText(publicKeyPem)))
            {
                RsaKeyParameters publicKeyParam = (RsaKeyParameters)new PemReader(publicKeyTextReader).ReadObject();

                RSAParameters rsaParams = DotNetUtilities.ToRSAParameters(publicKeyParam);

                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
                csp.ImportParameters(rsaParams);
                return csp;
            }
        }
    }
}
