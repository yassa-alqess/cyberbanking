import{a as S}from"./chunk-734CUXGP.js";import{a as o,c as i,d as L,f as E,g as f}from"./chunk-BX2ZHUFS.js";var q=i(E(),1),y=(t=>(t[t.Savings=1]="Savings",t[t.Checking=2]="Checking",t[t.CreditCard=3]="CreditCard",t[t.Loan=4]="Loan",t))(y||{});q.Decorators.registerEnumType(y,"cyberbanking.EBanking.Accounts.AccountType","EBanking.AccountType");var R=class{};o(R,"AccountsColumns"),R.columnsKey="EBanking.Accounts";var b=i(f(),1);var p=class{};o(p,"AccountsRow"),p.idProperty="AccountId",p.localTextPrefix="EBanking.Accounts",p.deletePermission="EBanking:Accounts",p.insertPermission="EBanking:Accounts",p.readPermission="EBanking:Accounts",p.updatePermission="EBanking:Accounts",p.Fields=(0,b.fieldsProxy)();var T=i(f(),1),A;(r=>(r.baseUrl="EBanking/Accounts",r.Methods={Create:"EBanking/Accounts/Create",Retrieve:"EBanking/Accounts/Retrieve",List:"EBanking/Accounts/List",DeactivateList:"EBanking/Accounts/DeactivateList"},["Create","Retrieve","List","DeactivateList"].forEach(e=>{r[e]=function(t,c,d){return(0,T.serviceRequest)(r.baseUrl+"/"+e,t,c,d)}})))(A||(A={}));var I;(e=>(e.Security="Administration:Security",e.Accounts="EBanking:Accounts",e.Transactions="EBanking:Transactions"))(I||(I={}));var C=i(E(),1),g=(e=>(e[e.Deposit=1]="Deposit",e[e.Withdrawal=2]="Withdrawal",e[e.Transfer=3]="Transfer",e))(g||{});C.Decorators.registerEnumType(g,"cyberbanking.EBanking.Transactions.TransactionType","EBanking.TransactionType");var P=i(E(),1),O=i(f(),1);var v=class{format(u){var c;let r=u.value;if(!r)return"";let t=((c=S.getLookup())==null?void 0:c.itemById)[r];return t?(0,O.htmlEncode)(t.Username):r.toString()}};o(v,"TransactionListFormatter"),v=L([P.Decorators.registerFormatter("cyberbanking.EBanking.TransactionListFormatter")],v);var k=class{};o(k,"TransactionsColumns"),k.columnsKey="EBanking.Transactions";var h=i(f(),1);var s=class{};o(s,"TransactionsRow"),s.idProperty="TransactionId",s.nameProperty="Description",s.localTextPrefix="EBanking.Transactions",s.deletePermission="EBanking:Transactions",s.insertPermission="EBanking:Transactions",s.readPermission="EBanking:Transactions",s.updatePermission="EBanking:Transactions",s.Fields=(0,h.fieldsProxy)();var J=i(f(),1),H;(r=>(r.baseUrl="EBanking/Transactions",r.Methods={Create:"EBanking/Transactions/Create",Retrieve:"EBanking/Transactions/Retrieve",List:"EBanking/Transactions/List"},["Create","Retrieve","List"].forEach(e=>{r[e]=function(t,c,d){return(0,J.serviceRequest)(r.baseUrl+"/"+e,t,c,d)}})))(H||(H={}));var n=i(E(),1);var Q=i(f(),1);var l=class extends n.PrefixedContext{constructor(u){if(super(u),!l.init){l.init=!0;var r=n.BooleanEditor,e=n.DecimalEditor,t=n.EnumEditor,c=n.DateEditor,d=n.LookupEditor;(0,Q.initFormType)(l,["IsActive",r,"Balance",e,"AccountType",t,"OpenDate",c,"CustomerId",d])}}},B=l;o(B,"AccountsForm"),B.formKey="EBanking.Accounts";var a=i(E(),1);var X=i(f(),1);var x=class extends a.PrefixedContext{constructor(u){if(super(u),!x.init){x.init=!0;var r=a.DecimalEditor,e=a.EnumEditor,t=a.DateEditor,c=a.TextAreaEditor,d=a.LookupEditor;(0,X.initFormType)(x,["Amount",r,"TransactionType",e,"TransactionDate",t,"Description",c,"SenderAccountId",d,"ReceiverAccountId",d])}}},D=x;o(D,"TransactionsForm"),D.formKey="EBanking.Transactions";export{R as a,B as b,p as c,A as d,I as e,k as f,D as g,s as h,H as i};
//# sourceMappingURL=chunk-FYV3EAAO.js.map
