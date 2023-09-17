import { Decorators, EntityGrid } from '@serenity-is/corelib';
import { AccountsColumns, AccountsRow, AccountsService, PermissionKeys } from '@/ServerTypes/EBanking';
import { AccountsDialog } from './AccountsDialog';
import { Authorization, indexOf, first, tryFirst } from '@serenity-is/corelib/q';
import { UserRow } from '../../Administration';

@Decorators.registerClass('cyberbanking.EBanking.AccountsGrid')
export class AccountsGrid extends EntityGrid<AccountsRow, any> {
    protected getColumnsKey() { return AccountsColumns.columnsKey; }
    protected getDialogType() { return AccountsDialog; }
    protected getRowDefinition() { return AccountsRow; }
    protected getService() { return AccountsService.baseUrl; }

    constructor(container: JQuery) {
        super(container);
    }
    protected getButtons() {
        let buttons = super.getButtons();
        if (Authorization.hasPermission(PermissionKeys.Security)) {
            //delete add button for admin
            //buttons.splice(indexOf(buttons, x => x.title == "add"), 1);
            buttons.splice(0, 1);
        }
        return buttons;
    }
    protected getColumns() {
        const cols = super.getColumns();
        const CustomerUsernameCol = first(cols, x => x.field == AccountsRow.Fields.CustomerUsername)
        if (Authorization.hasPermission(PermissionKeys.Security))
            CustomerUsernameCol.visible = true;
        return cols;
    }   
    protected getQuickFilters() {
        let filters = super.getQuickFilters();
        if (!Authorization.hasPermission(PermissionKeys.Security))
            filters.splice(indexOf(filters, x => x.field == AccountsRow.Fields.CustomerUsername), 1);

        //delete admin as he is not allowed to transfer money, 
        const adminId = tryFirst(UserRow.getLookup()?.items, x => x.Username === "admin")?.UserId.toString();
        if(adminId)
            UserRow.getLookup()?.items.splice(indexOf(UserRow.getLookup().items, x => x.UserId.toString() === adminId), 1);

        return filters;
    }
}