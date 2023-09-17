namespace cyberbanking.EBanking.Transactions
{
    public class TransferHandler : ITransactionTypeHandler
    {
        public void HandleTransactionType(AccountsRow sender, AccountsRow receiver, decimal? amount)
        {
            sender.Balance -= amount;
            receiver.Balance += amount;
        }

    }
}
