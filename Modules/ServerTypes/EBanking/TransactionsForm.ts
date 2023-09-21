import { DecimalEditor, EnumEditor, DateEditor, TextAreaEditor, LookupEditor, PrefixedContext } from "@serenity-is/corelib";
import { TransactionType } from "./Transactions.TransactionType";
import { AccountType } from "./Accounts.AccountType";
import { initFormType } from "@serenity-is/corelib/q";

export interface TransactionsForm {
    Amount: DecimalEditor;
    TransactionType: EnumEditor;
    TransactionDate: DateEditor;
    Description: TextAreaEditor;
    SenderAccountId: LookupEditor;
    SenderAccountType: EnumEditor;
    ReceiverAccountId: LookupEditor;
    ReceiverAccountType: EnumEditor;
}

export class TransactionsForm extends PrefixedContext {
    static formKey = 'EBanking.Transactions';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!TransactionsForm.init)  {
            TransactionsForm.init = true;

            var w0 = DecimalEditor;
            var w1 = EnumEditor;
            var w2 = DateEditor;
            var w3 = TextAreaEditor;
            var w4 = LookupEditor;

            initFormType(TransactionsForm, [
                'Amount', w0,
                'TransactionType', w1,
                'TransactionDate', w2,
                'Description', w3,
                'SenderAccountId', w4,
                'SenderAccountType', w1,
                'ReceiverAccountId', w4,
                'ReceiverAccountType', w1
            ]);
        }
    }
}

[TransactionType, AccountType]; // referenced types