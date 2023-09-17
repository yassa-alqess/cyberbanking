import { Decorators } from "@serenity-is/corelib";

export enum TransactionType {
    Deposit = 1,
    Withdrawal = 2,
    Transfer = 3
}
Decorators.registerEnumType(TransactionType, 'cyberbanking.EBanking.Transactions.TransactionType', 'EBanking.TransactionType');