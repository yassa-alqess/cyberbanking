import{a as q}from"./chunk-734CUXGP.js";import{a as o,c as n,d as S,f as E,g as f}from"./chunk-BX2ZHUFS.js";var b=n(E(),1),y=(r=>(r[r.Savings=1]="Savings",r[r.Checking=2]="Checking",r[r.CreditCard=3]="CreditCard",r[r.Loan=4]="Loan",r))(y||{});b.Decorators.registerEnumType(y,"cyberbanking.EBanking.Accounts.AccountType","EBanking.AccountType");var R=class{};o(R,"AccountsColumns"),R.columnsKey="EBanking.Accounts";var I=n(f(),1);var u=class{};o(u,"AccountsRow"),u.idProperty="AccountId",u.localTextPrefix="EBanking.Accounts",u.deletePermission="EBanking:Accounts",u.insertPermission="EBanking:Accounts",u.readPermission="EBanking:Accounts",u.updatePermission="EBanking:Accounts",u.Fields=(0,I.fieldsProxy)();var T=n(f(),1),g;(t=>(t.baseUrl="EBanking/Accounts",t.Methods={Create:"EBanking/Accounts/Create",Retrieve:"EBanking/Accounts/Retrieve",List:"EBanking/Accounts/List",DeactivateList:"EBanking/Accounts/DeactivateList"},["Create","Retrieve","List","DeactivateList"].forEach(e=>{t[e]=function(r,d,a){return(0,T.serviceRequest)(t.baseUrl+"/"+e,r,d,a)}})))(g||(g={}));var C;(e=>(e.Security="Administration:Security",e.Accounts="EBanking:Accounts",e.Transactions="EBanking:Transactions"))(C||(C={}));var P=n(E(),1),k=(e=>(e[e.Deposit=1]="Deposit",e[e.Withdrawal=2]="Withdrawal",e[e.Transfer=3]="Transfer",e))(k||{});P.Decorators.registerEnumType(k,"cyberbanking.EBanking.Transactions.TransactionType","EBanking.TransactionType");var X=n(E(),1),U=n(f(),1);var i=n(E(),1);var O=n(f(),1);var l=class extends i.PrefixedContext{constructor(p){if(super(p),!l.init){l.init=!0;var t=i.BooleanEditor,e=i.DecimalEditor,r=i.EnumEditor,d=i.DateEditor,a=i.LookupEditor;(0,O.initFormType)(l,["IsActive",t,"Balance",e,"AccountType",r,"OpenDate",d,"CustomerId",a])}}},B=l;o(B,"AccountsForm"),B.formKey="EBanking.Accounts";var s=n(E(),1);var h=n(f(),1);var x=class extends s.PrefixedContext{constructor(p){if(super(p),!x.init){x.init=!0;var t=s.DecimalEditor,e=s.EnumEditor,r=s.DateEditor,d=s.TextAreaEditor,a=s.LookupEditor;(0,h.initFormType)(x,["Amount",t,"TransactionType",e,"TransactionDate",r,"Description",d,"SenderAccountId",a,"ReceiverAccountId",a])}}},D=x;o(D,"TransactionsForm"),D.formKey="EBanking.Transactions";var H=n(f(),1);var c=class{};o(c,"TransactionsRow"),c.idProperty="TransactionId",c.nameProperty="Description",c.localTextPrefix="EBanking.Transactions",c.deletePermission="EBanking:Transactions",c.insertPermission="EBanking:Transactions",c.readPermission="EBanking:Transactions",c.updatePermission="EBanking:Transactions",c.Fields=(0,H.fieldsProxy)();var Q=n(f(),1),J;(t=>(t.baseUrl="EBanking/Transactions",t.Methods={Create:"EBanking/Transactions/Create",Retrieve:"EBanking/Transactions/Retrieve",List:"EBanking/Transactions/List"},["Create","Retrieve","List"].forEach(e=>{t[e]=function(r,d,a){return(0,Q.serviceRequest)(t.baseUrl+"/"+e,r,d,a)}})))(J||(J={}));var v=class{constructor(){g.List({},p=>{this.accounts=p.Entities})}format(p){var A;let t=p.value;if(!t)return"";let r=this.accounts.find(F=>F.AccountId==t).CustomerId,a=((A=q.getLookup())==null?void 0:A.itemById)[r];return a?(0,U.htmlEncode)(a.Username):t.toString()}};o(v,"TransactionListFormatter"),v=S([X.Decorators.registerFormatter("cyberbanking.EBanking.TransactionListFormatter")],v);var L=class{};o(L,"TransactionsColumns"),L.columnsKey="EBanking.Transactions";export{R as a,B as b,u as c,g as d,C as e,L as f,D as g,c as h,J as i};
//# sourceMappingURL=chunk-R2DVGNLT.js.map
