import { Decorators } from "@serenity-is/corelib";

export enum TransactionType {
    Deposit = 0,
    Withdrawal = 1,
    Transfer = 2
}
Decorators.registerEnumType(TransactionType, 'cyberbanking.EBanking.Transactions.TransactionType', 'EBanking.TransactionType');