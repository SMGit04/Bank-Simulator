namespace Bank_Simulator.Services.Interfaces.Encryption
{
    public interface IRsaHelper
    {
        string Encrypt(string text);
        string Decrypt(string encrypted);
    }
}
