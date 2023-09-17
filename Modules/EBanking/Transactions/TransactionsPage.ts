import { initFullHeightGridPage } from '@serenity-is/corelib/q';
import { TransactionsGrid } from './TransactionsGrid';

export default function pageInit() {
    initFullHeightGridPage(new TransactionsGrid($('#GridDiv')).element);
}