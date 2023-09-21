import { AccountType } from "./Accounts.AccountType";
import { getLookup, getLookupAsync, fieldsProxy } from "@serenity-is/corelib/q";

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
    static readonly lookupKey = 'EBanking.Accounts';

    /** @deprecated use getLookupAsync instead */
    static getLookup() { return getLookup<AccountsRow>('EBanking.Accounts') }
    static async getLookupAsync() { return getLookupAsync<AccountsRow>('EBanking.Accounts') }

    static readonly deletePermission = 'EBanking:Accounts';
    static readonly insertPermission = 'EBanking:Accounts';
    static readonly readPermission = 'EBanking:Accounts';
    static readonly updatePermission = 'EBanking:Accounts';

    static readonly Fields = fieldsProxy<AccountsRow>();
}