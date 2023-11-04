using System.Collections.Concurrent;

namespace Bank_Simulator.Services.Implementation.Transactions
{
    public class TransactionService
    {
        public ConcurrentDictionary<string, TaskCompletionSource<bool>> PendingAuths { get; } = new ConcurrentDictionary<string, TaskCompletionSource<bool>>();
    }
}
