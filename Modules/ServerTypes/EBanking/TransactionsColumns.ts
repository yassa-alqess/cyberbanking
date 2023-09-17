import { TransactionType } from "./Transactions.TransactionType";
import { TransactionListFormatter } from "@/EBanking/Transactions/TransactionListFormatter";

export class TransactionsColumns {
    static columnsKey = 'EBanking.Transactions';
}

[TransactionType, TransactionListFormatter]; // referenced types