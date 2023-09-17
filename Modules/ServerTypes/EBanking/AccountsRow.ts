import { AccountType } from "./Accounts.AccountType";
import { fieldsProxy } from "@serenity-is/corelib/q";

export interface AccountsRow {
    AccountId?: number;
    Balance?: number;
    AccountType?: AccountType;
    OpenDate?: string;
    CustomerId?: number;
    CustomerUsername?: string;
    IsActive?: boolean;
}

export abstract class AccountsRow {
    static readonly idProperty = 'AccountId';
    static readonly localTextPrefix = 'EBanking.Accounts';
    static readonly deletePermission = 'EBanking:Accounts';
    static readonly insertPermission = 'EBanking:Accounts';
    static readonly readPermission = 'EBanking:Accounts';
    static readonly updatePermission = 'EBanking:Accounts';

    static readonly Fields = fieldsProxy<AccountsRow>();
}