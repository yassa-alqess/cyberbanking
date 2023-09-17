import { initFullHeightGridPage } from '@serenity-is/corelib/q';
import { AccountsGrid } from './AccountsGrid';

export default function pageInit() {
    initFullHeightGridPage(new AccountsGrid($('#GridDiv')).element);
}