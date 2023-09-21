import { ServiceRequest } from "@serenity-is/corelib/q";

export interface ListByIdRequest extends ServiceRequest {
    Id?: number;
}