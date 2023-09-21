import { SaveRequest, SaveResponse, ServiceOptions, RetrieveRequest, RetrieveResponse, ListRequest, ListResponse, ServiceRequest, serviceRequest } from "@serenity-is/corelib/q";
import { AccountsRow } from "./AccountsRow";
import { BulkListRequest } from "./Accounts.BulkListRequest";
import { ListByUsernameRequest } from "./ListByUsernameRequest";
import { ListByUsernameResponse } from "./ListByUsernameResponse";
import { ListByIdRequest } from "./ListByIdRequest";
import { ListByIdResponse } from "./ListByIdResponse";

export namespace AccountsService {
    export const baseUrl = 'EBanking/Accounts';

    export declare function Create(request: SaveRequest<AccountsRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<AccountsRow>) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function List(request: ListRequest, onSuccess?: (response: ListResponse<AccountsRow>) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function DeactivateList(request: BulkListRequest, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function ActivateList(request: BulkListRequest, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function ListAll(request: ServiceRequest, onSuccess?: (response: AccountsRow[]) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function ListByUsername(request: ListByUsernameRequest, onSuccess?: (response: ListByUsernameResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function ListById(request: ListByIdRequest, onSuccess?: (response: ListByIdResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;

    export const Methods = {
        Create: "EBanking/Accounts/Create",
        Retrieve: "EBanking/Accounts/Retrieve",
        List: "EBanking/Accounts/List",
        DeactivateList: "EBanking/Accounts/DeactivateList",
        ActivateList: "EBanking/Accounts/ActivateList",
        ListAll: "EBanking/Accounts/ListAll",
        ListByUsername: "EBanking/Accounts/ListByUsername",
        ListById: "EBanking/Accounts/ListById"
    } as const;

    [
        'Create', 
        'Retrieve', 
        'List', 
        'DeactivateList', 
        'ActivateList', 
        'ListAll', 
        'ListByUsername', 
        'ListById'
    ].forEach(x => {
        (<any>AccountsService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}