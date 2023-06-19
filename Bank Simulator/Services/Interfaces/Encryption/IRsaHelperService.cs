namespace Bank_Simulator.Services.Interfaces.Encryption
{
    public interface IRsaHelperService
    {
        string Encrypt(string text);
        string Decrypt(string encrypted);
    }
}
