import{b as s,c as g,d as e,e as i}from"../../../_chunks/chunk-734CUXGP.js";import{a as o,c as p,d as n,f as m,g as l}from"../../../_chunks/chunk-BX2ZHUFS.js";var u=p(l(),1);var a=p(m(),1);var r=class extends a.EntityDialog{constructor(){super(...arguments);this.form=new g(this.idPrefix)}getFormKey(){return g.formKey}getIdProperty(){return e.idProperty}getLocalTextPrefix(){return e.localTextPrefix}getNameProperty(){return e.nameProperty}getService(){return i.baseUrl}};o(r,"LanguageDialog"),r=n([a.Decorators.registerClass("cyberbanking.Administration.LanguageDialog")],r);var c=p(m(),1);var t=class extends c.EntityGrid{useAsync(){return!0}getColumnsKey(){return s.columnsKey}getDialogType(){return r}getIdProperty(){return e.idProperty}getLocalTextPrefix(){return e.localTextPrefix}getService(){return i.baseUrl}afterInit(){super.afterInit()}getDefaultSortBy(){return[e.Fields.LanguageName]}};o(t,"LanguageGrid"),t=n([c.Decorators.registerClass("cyberbanking.Administration.LanguageGrid")],t);$(function(){(0,u.initFullHeightGridPage)(new t($("#GridDiv")).element)});
//# sourceMappingURL=LanguagePage.js.map
