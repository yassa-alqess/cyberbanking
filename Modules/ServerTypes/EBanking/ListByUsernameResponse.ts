import { ServiceResponse } from "@serenity-is/corelib/q";
import { AccountsRow } from "./AccountsRow";

export interface ListByUsernameResponse extends ServiceResponse {
    Entities?: AccountsRow[];
}