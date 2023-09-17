import { SaveRequest, SaveResponse, ServiceOptions, RetrieveRequest, RetrieveResponse, ListRequest, ListResponse, serviceRequest } from "@serenity-is/corelib/q";
import { TransactionsRow } from "./TransactionsRow";

export namespace TransactionsService {
    export const baseUrl = 'EBanking/Transactions';

    export declare function Create(request: SaveRequest<TransactionsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<TransactionsRow>) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<TransactionsRow>) => void, opt?: ServiceOptions<any>): JQueryXHR;

    export const Methods = {
        Create: "EBanking/Transactions/Create",
        Retrieve: "EBanking/Transactions/Retrieve",
        List: "EBanking/Transactions/List"
    } as const;

    [
        'Create', 
        'Retrieve', 
        'List'
    ].forEach(x => {
        (<any>TransactionsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}