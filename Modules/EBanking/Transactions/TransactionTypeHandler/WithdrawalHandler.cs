namespace cyberbanking.EBanking.Transactions
{
    public class WithdrawalHandler : ITransactionTypeHandler
    {
        public void HandleTransactionType( AccountsRow sender, AccountsRow receiver, decimal? amount)
        {
            sender.Balance -= amount;
        }

    }
}
