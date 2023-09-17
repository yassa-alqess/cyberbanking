import { Decorators, EntityGrid, QuickSearchField } from '@serenity-is/corelib';
import { PermissionKeys, TransactionsColumns, TransactionsRow, TransactionsService } from '@/ServerTypes/EBanking';
import { TransactionsDialog } from './TransactionsDialog';
import { Authorization, indexOf, text, first, tryFirst, } from '@serenity-is/corelib/q';
import { UserRow } from '../../Administration';

@Decorators.registerClass('cyberbanking.EBanking.TransactionsGrid')
export class TransactionsGrid extends EntityGrid<TransactionsRow, any> {
    protected getColumnsKey() { return TransactionsColumns.columnsKey; }
    protected getDialogType() { return TransactionsDialog; }
    protected getRowDefinition() { return TransactionsRow; }
    protected getService() { return TransactionsService.baseUrl; }

    constructor(container: JQuery) {
        super(container);
    }
    protected getQuickFilters() {
        let filters = super.getQuickFilters();
        if (!Authorization.hasPermission(PermissionKeys.Security))
            filters.splice(indexOf(filters, x => x.field == TransactionsRow.Fields.ReceiverAccountId), 1);


        //delete admin as he is not allowed to transfer money
        const adminId = tryFirst(UserRow.getLookup().items, x => x.Username === "admin")?.UserId.toString();
        if(adminId)
            UserRow.getLookup().items.splice(indexOf(UserRow.getLookup().items, x => x.UserId.toString() === adminId), 1);

        return filters;
    }
    protected getQuickSearchFields(): QuickSearchField[] {
        const fld = TransactionsRow.Fields;
        const txt = (s) =>
            text(`Db.${TransactionsRow.localTextPrefix}.${s}`).toLowerCase();
        return [
            { name: "", title: "all" },
            { name: fld.Description, title: txt(fld.Description) },
            { name: fld.Amount, title: txt(fld.Amount) },
        ];
    }
    protected getButtons() {
        let buttons = super.getButtons();
        if (Authorization.hasPermission(PermissionKeys.Security)) {
            //delete add button
            //buttons.splice(indexOf(buttons, x => x.title == "add"), 1);
            // buttons.splice(0, 1);
        }
        return buttons;
    }
    protected getColumns() {
        const cols = super.getColumns();
        const senderCol = first(cols, x => x.field == TransactionsRow.Fields.SenderAccountId);
        if (Authorization.hasPermission(PermissionKeys.Security))
            senderCol.visible = true;
        return cols;
    }
}