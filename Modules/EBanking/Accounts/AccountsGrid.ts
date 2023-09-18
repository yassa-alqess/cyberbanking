import { Decorators, EntityGrid, GridRowSelectionMixin } from '@serenity-is/corelib';
import { AccountsColumns, AccountsRow, AccountsService, PermissionKeys } from '@/ServerTypes/EBanking';
import { AccountsDialog } from './AccountsDialog';
import { Authorization, indexOf, first, tryFirst, parseInteger, notifyError } from '@serenity-is/corelib/q';
import { UserRow } from '../../Administration';
import { BulkServiceAction } from '@serenity-is/extensions';

@Decorators.registerClass('cyberbanking.EBanking.AccountsGrid')
export class AccountsGrid extends EntityGrid<AccountsRow, any> {
    protected getColumnsKey() { return AccountsColumns.columnsKey; }
    protected getDialogType() { return AccountsDialog; }
    protected getRowDefinition() { return AccountsRow; }
    protected getService() { return AccountsService.baseUrl; }
    private rowSelection: GridRowSelectionMixin;

    constructor(container: JQuery) {
        super(container);
    }
    protected createToolbarExtensions() {
        super.createToolbarExtensions();
        if (Authorization.hasPermission(PermissionKeys.Security))
            this.rowSelection = new GridRowSelectionMixin(this);
    }
    protected getButtons() {
        let buttons = super.getButtons();
        if (Authorization.hasPermission(PermissionKeys.Security)) {
            //delete add button for admin
            //add deactivate btn for admin
            //buttons.splice(indexOf(buttons, x => x.title == "add"), 1);
            buttons.splice(0, 1);
            buttons.push({
                title: 'Deactivate Accounts',
                icon: 'fa fa-ban',
                visible: true,
                cssClass: 'delete-button',
                onClick: e => {
                    //   debugger;
                    let accountIds = this.rowSelection.getSelectedKeys();
                    if (accountIds.length > 0) {
                        var action = new DeleteBulkAction();
                        action.done = () => this.rowSelection.resetCheckedAndRefresh();
                        action.execute(accountIds);
                    } else notifyError('Please Select Rows to submit');
                }
            });

        }
        return buttons;
    }
    protected getColumns() {
        const cols = super.getColumns();
        const CustomerUsernameCol = first(cols, x => x.field == AccountsRow.Fields.CustomerUsername)
        if (Authorization.hasPermission(PermissionKeys.Security)) {
            cols.splice(0, 0, GridRowSelectionMixin.createSelectColumn(() => this.rowSelection));
            CustomerUsernameCol.visible = true;
        }
        return cols;
    }
    protected usePager() {
        return true; //use pagination
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

@Decorators.registerClass('cyberbanking.EBanking.DeleteBulkAction')
export class DeleteBulkAction extends BulkServiceAction {


    protected getParallelRequests() {
        return 10;
    }

    protected getBatchSize() {
        return 5;
    }

    protected sccss() {
        alert('sccss');
        debugger;
    }
    protected executeForBatch(batch) {

        AccountsService.DeactivateList(
            {
                AccountIds: batch.map(x => parseInteger(x))
            },
            response => {
                this.set_successCount(this.get_successCount() + batch.length)
            },
            {
                blockUI: false,
                onError: response => this.set_errorCount(this.get_errorCount() + batch.length),
                onCleanup: () => this.serviceCallCleanup(),
            });

    }
}