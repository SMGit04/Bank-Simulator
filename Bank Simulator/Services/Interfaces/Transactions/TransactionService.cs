using System.Collections.Concurrent;

namespace Bank_Simulator.Services.Interfaces.Transactions
{
    public class TransactionService
    {
        public ConcurrentDictionary<string, TaskCompletionSource<bool>> PendingAuths { get; } = new ConcurrentDictionary<string, TaskCompletionSource<bool>>();
    }
}
