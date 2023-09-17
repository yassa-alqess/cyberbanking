namespace cyberbanking.EBanking.Transactions
{
    public interface ITransactionTypeHandler
    {
        void HandleTransactionType(AccountsRow sender, AccountsRow receiver, decimal? amount);
    }
}
