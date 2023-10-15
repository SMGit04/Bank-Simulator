using Bank_Simulator.Models;
using System.Collections.Concurrent;

namespace Bank_Simulator.Services.Implementation.Transactions
{
    public class MessageQueueService
    {

        private readonly ConcurrentQueue<TransactionRequestResultModel> queue = new();

        public void Enqueue(TransactionRequestResultModel transactionRequestItem)
        {
            queue.Enqueue(transactionRequestItem);
        }
        public bool TryDequeue(out  TransactionRequestResultModel transactionRequestResultModel)
        {
            return queue.TryDequeue(out transactionRequestResultModel);
        }
    }
}
