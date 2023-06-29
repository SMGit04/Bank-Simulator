namespace Bank_Simulator.Services.Interfaces.Encryption
{
    public interface IEncrptionService
    {
        string Encrypt(string text);
        string Decrypt(string encrypted);
    }
}
