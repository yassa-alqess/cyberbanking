import { Decorators, EditorUtils, EntityDialog } from '@serenity-is/corelib';
import { TransactionsForm, TransactionsRow, TransactionsService, TransactionType } from '@/ServerTypes/EBanking';
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

    protected afterLoadEntity() {
        super.afterLoadEntity();
        this.form.TransactionType.changeSelect2(e => {
            const type = toId(this.form.TransactionType.value);
            this.form.ReceiverAccountId.getGridField().toggle(type === TransactionType.Transfer);
        })

        // deleting the admin is handled at the Grid, I removed those itmes from the lookup itself
        const currentUserId = tryFirst(UserRow.getLookup().items, x => x.Username === Authorization.username)?.UserId.toString();
        const adminId = tryFirst(UserRow.getLookup().items, x => x.Username === "admin")?.UserId.toString();
        if (currentUserId !== adminId)
            this.form.ReceiverAccountId.items.splice(indexOf(this.form.ReceiverAccountId.items, x => x.id === currentUserId), 1);
    
    }
    
    protected updateInterface() {
        super.updateInterface();
        if (this.isEditMode()) {
            EditorUtils.setReadOnly(this.form.ReceiverAccountId, true);
            EditorUtils.setReadOnly(this.form.TransactionType, true);
            EditorUtils.setReadOnly(this.form.Amount, true);
            EditorUtils.setReadOnly(this.form.Description, true);
            this.deleteButton.hide();
            this.applyChangesButton.hide();
            this.saveAndCloseButton.hide();
        }
    }
}