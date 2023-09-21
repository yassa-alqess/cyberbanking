import { ServiceRequest } from "@serenity-is/corelib/q";

export interface GetUserByNameRequest extends ServiceRequest {
    Username?: string;
}