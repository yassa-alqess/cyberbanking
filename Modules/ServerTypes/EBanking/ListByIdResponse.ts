import { ServiceResponse } from "@serenity-is/corelib/q";
import { AccountsRow } from "./AccountsRow";

export interface ListByIdResponse extends ServiceResponse {
    Entities?: AccountsRow[];
}