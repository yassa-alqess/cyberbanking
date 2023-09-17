import { Decorators, EditorUtils, EntityDialog } from '@serenity-is/corelib';
import { AccountsForm, AccountsRow, AccountsService } from '@/ServerTypes/EBanking';

@Decorators.registerClass('cyberbanking.EBanking.AccountsDialog')
export class AccountsDialog extends EntityDialog<AccountsRow, any> {
    protected getFormKey() { return AccountsForm.formKey; }
    protected getRowDefinition() { return AccountsRow; }
    protected getService() { return AccountsService.baseUrl; }

    protected form = new AccountsForm(this.idPrefix);

    //not working
    protected getToolbarButtons() {
        let buttons = super.getToolbarButtons();
        if (this.entity && this.entity.AccountId) {
            buttons.forEach(btn => {
                btn.visible = false;
            });
        }
        return buttons;
    }
    protected updateInterface() {
        super.updateInterface();
        if (this.isEditMode()) {
            EditorUtils.setReadOnly(this.form.Balance, true);
            EditorUtils.setReadOnly(this.form.AccountType, true);
            EditorUtils.setReadOnly(this.form.OpenDate, true);
            EditorUtils.setReadOnly(this.form.CustomerId, true);
            this.deleteButton.hide();
            this.applyChangesButton.hide();
            this.saveAndCloseButton.hide();
        }
    }

}