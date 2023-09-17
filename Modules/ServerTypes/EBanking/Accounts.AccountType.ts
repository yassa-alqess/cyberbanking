import { Decorators } from "@serenity-is/corelib";

export enum AccountType {
    Savings = 0,
    Checking = 1,
    CreditCard = 2,
    Loan = 3
}
Decorators.registerEnumType(AccountType, 'cyberbanking.EBanking.Accounts.AccountType', 'EBanking.AccountType');