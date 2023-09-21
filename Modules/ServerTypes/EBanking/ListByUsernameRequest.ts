import { ServiceRequest } from "@serenity-is/corelib/q";

export interface ListByUsernameRequest extends ServiceRequest {
    Username?: string;
}