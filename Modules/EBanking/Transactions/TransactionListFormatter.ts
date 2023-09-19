import { Decorators, Formatter } from "@serenity-is/corelib";
import { htmlEncode } from "@serenity-is/corelib/q";
import { FormatterContext } from "@serenity-is/sleekgrid";
import { AccountsRow } from "../../ServerTypes/EBanking/AccountsRow";
import { UserRow } from "../../ServerTypes/Administration/UserRow";
import { AccountsService } from "../../ServerTypes/EBanking";

@Decorators.registerFormatter("cyberbanking.EBanking.TransactionListFormatter")
export class TransactionListFormatter implements Formatter {
    private accounts: Array<AccountsRow>;
    constructor() {
        AccountsService.List({
        },
            response => {
                this.accounts = response.Entities;
            }
        )

    }
    format(ctx: FormatterContext) {
        //debugger;
        let id = ctx.value
        if (!id)
            return "";
        let account = this.accounts.find(a => a.AccountId == id);
        let customerId = account.CustomerId;
        let byId = UserRow.getLookup()?.itemById; 
        let g = byId[customerId];
        if (!g)
            return id.toString();
        return htmlEncode(g.Username);
    }
}