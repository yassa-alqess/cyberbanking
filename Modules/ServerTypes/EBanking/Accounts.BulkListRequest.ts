import { ServiceRequest } from "@serenity-is/corelib/q";

export interface BulkListRequest extends ServiceRequest {
    AccountIds?: string[];
}