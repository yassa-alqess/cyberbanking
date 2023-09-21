import { SaveRequest, SaveResponse, ServiceOptions, DeleteRequest, DeleteResponse, RetrieveRequest, RetrieveResponse, ListResponse, serviceRequest } from "@serenity-is/corelib/q";
import { UserRow } from "./UserRow";
import { UserListRequest } from "./UserListRequest";
import { GetUserByNameRequest } from "./GetUserByNameRequest";
import { GetUserByNameResponse } from "./GetUserByNameResponse";

export namespace UserService {
    export const baseUrl = 'Administration/User';

    export declare function Create(request: SaveRequest<UserRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function Update(request: SaveRequest<UserRow>, onSuccess?: (response: SaveResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function Delete(request: DeleteRequest, onSuccess?: (response: DeleteResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function Retrieve(request: RetrieveRequest, onSuccess?: (response: RetrieveResponse<UserRow>) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function List(request: UserListRequest, onSuccess?: (response: ListResponse<UserRow>) => void, opt?: ServiceOptions<any>): JQueryXHR;
    export declare function GetByUserName(request: GetUserByNameRequest, onSuccess?: (response: GetUserByNameResponse) => void, opt?: ServiceOptions<any>): JQueryXHR;

    export const Methods = {
        Create: "Administration/User/Create",
        Update: "Administration/User/Update",
        Delete: "Administration/User/Delete",
        Retrieve: "Administration/User/Retrieve",
        List: "Administration/User/List",
        GetByUserName: "Administration/User/GetByUserName"
    } as const;

    [
        'Create', 
        'Update', 
        'Delete', 
        'Retrieve', 
        'List', 
        'GetByUserName'
    ].forEach(x => {
        (<any>UserService)[x] = function (r, s, o) {
            return serviceRequest(baseUrl + '/' + x, r, s, o);
        };
    });
}