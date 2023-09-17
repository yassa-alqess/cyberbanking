import { Decorators } from "@serenity-is/corelib";

export enum AccountType {
    Savings = 1,
    Checking = 2,
    CreditCard = 3,
    Loan = 4
}
Decorators.registerEnumType(AccountType, 'cyberbanking.EBanking.Accounts.AccountType', 'EBanking.AccountType');