import { Decorators, EntityGrid, LookupEditor, QuickSearchField } from '@serenity-is/corelib';
import { AccountsRow, AccountsService, PermissionKeys, TransactionsColumns, TransactionsRow, TransactionsService, TransactionType } from '@/ServerTypes/EBanking';
import { TransactionsDialog } from './TransactionsDialog';
import { Authorization, indexOf, text, first, tryFirst, toId, ListRequest, } from '@serenity-is/corelib/q';
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
            filters.splice(indexOf(filters, x => x.field == TransactionsRow.Fields.SenderAccountId), 1);

        /*
        * Hide receiver filter if transaction type is not transfer
        const receiverFilter = first(filters, x => x.field == TransactionsRow.Fields.ReceiverAccountId);
        const transactionTypeFilter = first(filters, x => x.field == TransactionsRow.Fields.TransactionType);
        this.changeSelect2(e => {
            const type = parseInt(e.val);
            console.log(e);
            if (type != TransactionType.Transfer) {
                console.log("adding receiver filter");
                filters.splice(indexOf(filters, x => x.field == TransactionsRow.Fields.ReceiverAccountId), 1);
            }
            else {
                filters.splice(indexOf(filters, x => x.field == TransactionsRow.Fields.ReceiverAccountId), 1);
                filters.push(receiverFilter);
            }

        })
        */



         //delete admin as he is not allowed to transfer money neither has accounts,
        //also here i'm removing the current user, giving that he can't transfer for some other arbitary account owned by him.
        //it may be a feature to be added later.
        const adminId = tryFirst(UserRow.getLookup()?.items, x => x.Username === "admin")?.UserId;
        const currentUserId = tryFirst(UserRow.getLookup().items, x => x.Username === Authorization.username)?.UserId;
        if (adminId)
            UserRow.getLookup()?.items.splice(indexOf(UserRow.getLookup()?.items, x => x.UserId === adminId), 1);
        if (currentUserId !== adminId)
            UserRow.getLookup()?.items.splice(indexOf(UserRow.getLookup()?.items, x => x.UserId === currentUserId), 1);


        //not working yet
        const receiverFilter = first(filters, x => x.field == TransactionsRow.Fields.ReceiverAccountId);
        receiverFilter.handler = h => {
            const request = (h.request as ListRequest);
            const values = (h.widget as LookupEditor).values;
            values[0] = AccountsRow.getLookup()?.items.filter(x => x.CustomerId === parseInt(values[0])).map(x => x.AccountId).toString();
    
            h.handled = false;
        };
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
            //delete add button for admin
            //buttons.splice(indexOf(buttons, x => x.title == "add"), 1);
            buttons.splice(0, 1);
        }
        return buttons;
    }
    protected getColumns() {
        const cols = super.getColumns();
        const senderCol = first(cols, x => x.field == TransactionsRow.Fields.SenderAccountId);
        //const senderTypeCol = first(cols, x => x.field == TransactionsRow.Fields.SenderAccountType);
        if (!Authorization.hasPermission(PermissionKeys.Security)) {
            senderCol.visible = false;
            //senderTypeCol.visible = false;
        }
        return cols;
    }
}