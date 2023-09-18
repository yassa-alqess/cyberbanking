import { SaveRequest, SaveResponse, ServiceOptions, RetrieveRequest, RetrieveResponse, ListRequest, ListResponse, serviceRequest } from "@serenity-is/corelib/q";
import { AccountsRow } from "./AccountsRow";
import { DeactivateListRequest } from "./Accounts.DeactivateListRequest";

export namespace AccountsService {
    export const baseUrl = 'EBanking/Accounts';

    export declare function Create(request: SaveRequest<AccountsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<AccountsRow>) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<AccountsRow>) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function DeactivateList(request: DeactivateListRequest, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;

    export const Methods = {
        Create: "EBanking/Accounts/Create",
        Retrieve: "EBanking/Accounts/Retrieve",
        List: "EBanking/Accounts/List",
        DeactivateList: "EBanking/Accounts/DeactivateList"
    } as const;

    [
        'Create', 
        'Retrieve', 
        'List', 
        'DeactivateList'
    ].forEach(x => {
        (<any>AccountsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}