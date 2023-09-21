import { TransactionType } from "./Transactions.TransactionType";
import { AccountType } from "./Accounts.AccountType";
import { fieldsProxy } from "@serenity-is/corelib/q";

export interface TransactionsRow {
    TransactionId?: number;
    Amount?: number;
    TransactionType?: TransactionType;
    TransactionDate?: string;
    Description?: string;
    SenderAccountId?: number;
    ReceiverAccountId?: number;
    SenderAccountType?: AccountType;
    ReceiverAccountType?: AccountType;
}

export abstract class TransactionsRow {
    static readonly idProperty = 'TransactionId';
    static readonly nameProperty = 'Description';
    static readonly localTextPrefix = 'EBanking.Transactions';
    static readonly deletePermission = 'EBanking:Transactions';
    static readonly insertPermission = 'EBanking:Transactions';
    static readonly readPermission = 'EBanking:Transactions';
    static readonly updatePermission = 'EBanking:Transactions';

    static readonly Fields = fieldsProxy<TransactionsRow>();
}