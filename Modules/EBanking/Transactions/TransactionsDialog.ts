import { Decorators, EditorUtils, EntityDialog } from '@serenity-is/corelib';
import { AccountsRow, AccountsService, TransactionsForm, TransactionsRow, TransactionsService, TransactionType } from '@/ServerTypes/EBanking';
import { first, indexOf, toId, tryFirst } from '@serenity-is/corelib/q';
import { Authorization, notifyError } from '@serenity-is/corelib/q';
import { UserRow } from '../../ServerTypes/Administration/UserRow';
import { UserService } from '../../Administration';

@Decorators.registerClass('cyberbanking.EBanking.TransactionsDialog')
export class TransactionsDialog extends EntityDialog<TransactionsRow, any> {
    protected getFormKey() { return TransactionsForm.formKey; }
    protected getRowDefinition() { return TransactionsRow; }
    protected getService() { return TransactionsService.baseUrl; }

    protected form = new TransactionsForm(this.idPrefix);
    private senderAccounts: Array<AccountsRow>;
    private receiverAccounts: Array<AccountsRow>;
    private receiverUsername: string;

    protected beforeLoadEntity() {
        super.beforeLoadEntity(this.entity);


        // only get account types for dropdown that current user has and receiver user has
        AccountsService.List({}, response => {
            this.senderAccounts = response.Entities;
            let newItems = this.form.SenderAccountType.items.filter(x => this.senderAccounts.find(y => y.AccountType === parseInt(x.id)));
            this.form.SenderAccountType.items = newItems;
            //console.log("before", newItems);
        });

        AccountsService.ListByUsername({ Username: Authorization.username }, response => {
            this.receiverAccounts = response.Entities;
            let newItems = this.form.ReceiverAccountType.items.filter(x => this.receiverAccounts.find(y => y.AccountType === parseInt(x.id)));
            this.form.ReceiverAccountType.items = newItems;
            //console.log("before", newItems);
        });


    }
    protected afterLoadEntity() {
        super.afterLoadEntity();
        this.form.TransactionType.changeSelect2(e => {
            const type = toId(this.form.TransactionType.value);
            this.form.ReceiverAccountId.getGridField().toggle(type === TransactionType.Transfer);
            this.form.ReceiverAccountType.getGridField().toggle(type === TransactionType.Transfer);
        })
        this.form.ReceiverAccountId.changeSelect2(e => {
            const receiverAccountId = toId(this.form.ReceiverAccountId.value);
            let receiverAccountTypes;
            AccountsService.ListById({
                Id: receiverAccountId
            }, response => {
                this.receiverAccounts = response.Entities;
                //console.log(this.receiverAccounts);
                let newItems = this.form.ReceiverAccountType.items.filter(x => this.receiverAccounts.find(y => y.AccountType === parseInt(x.id)));
                console.log(newItems);
                this.form.ReceiverAccountType.items = newItems;
            });
       })

    
        //handled at both grid and dialog to preserve integrity of data.
        //but if deleted currentuser will be -1
        const currentUserId = tryFirst(UserRow.getLookup()?.items, x => x.Username === Authorization.username)?.UserId;
        const adminId = tryFirst(UserRow.getLookup()?.items, x => x.Username === "admin")?.UserId;
        if (currentUserId !== adminId && currentUserId != -1)
            this.form.ReceiverAccountId.items.splice(indexOf(this.form.ReceiverAccountId.items, x => x.id === currentUserId.toString()), 1);
        
           
    }

    protected updateInterface() {
        super.updateInterface();
        if (this.isEditMode()) {
            EditorUtils.setReadOnly(this.form.TransactionType, true);
            EditorUtils.setReadOnly(this.form.Amount, true);
            EditorUtils.setReadOnly(this.form.Description, true);
            EditorUtils.setReadOnly(this.form.SenderAccountId, true);
            EditorUtils.setReadOnly(this.form.SenderAccountType, true);
            EditorUtils.setReadOnly(this.form.ReceiverAccountId, true);
            EditorUtils.setReadOnly(this.form.ReceiverAccountType, true);
            this.deleteButton.hide();
            this.applyChangesButton.hide();
            this.saveAndCloseButton.hide();
        }
    }
}