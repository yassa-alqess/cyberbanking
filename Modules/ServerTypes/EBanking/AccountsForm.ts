import { BooleanEditor, DecimalEditor, EnumEditor, DateEditor, LookupEditor, PrefixedContext } from "@serenity-is/corelib";
import { AccountType } from "./Accounts.AccountType";
import { initFormType } from "@serenity-is/corelib/q";

export interface AccountsForm {
    IsActive: BooleanEditor;
    Balance: DecimalEditor;
    AccountType: EnumEditor;
    OpenDate: DateEditor;
    CustomerId: LookupEditor;
}

export class AccountsForm extends PrefixedContext {
    static formKey = 'EBanking.Accounts';
    private static init: boolean;

    constructor(prefix: string) {
        super(prefix);

        if (!AccountsForm.init)  {
            AccountsForm.init = true;

            var w0 = BooleanEditor;
            var w1 = DecimalEditor;
            var w2 = EnumEditor;
            var w3 = DateEditor;
            var w4 = LookupEditor;

            initFormType(AccountsForm, [
                'IsActive', w0,
                'Balance', w1,
                'AccountType', w2,
                'OpenDate', w3,
                'CustomerId', w4
            ]);
        }
    }
}

[AccountType]; // referenced types