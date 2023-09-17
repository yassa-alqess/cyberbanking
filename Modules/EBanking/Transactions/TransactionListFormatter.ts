import { Decorators, Formatter } from "@serenity-is/corelib";
import { htmlEncode } from "@serenity-is/corelib/q";
import { FormatterContext } from "@serenity-is/sleekgrid";
import { AccountsRow } from "../../ServerTypes/EBanking/AccountsRow";
import { UserRow } from "../../ServerTypes/Administration/UserRow";

@Decorators.registerFormatter("cyberbanking.EBanking.TransactionListFormatter")
export class TransactionListFormatter implements Formatter {
    format(ctx: FormatterContext) {
        let id = ctx.value
        if (!id)
            return "";

        let byId = UserRow.getLookup()?.itemById; //why depricated
        let g = byId[id];
        if (!g)
            return id.toString();
        return htmlEncode(g.Username);
    }
}