import { ServiceRequest } from "@serenity-is/corelib/q";

export interface DeactivateListRequest extends ServiceRequest {
    AccountIds?: string[];
}