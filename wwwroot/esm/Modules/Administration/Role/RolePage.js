import{a as b}from"../../../_chunks/chunk-55YAEXBU.js";import{a as x}from"../../../_chunks/chunk-34HH4RG2.js";import{f as h,g as f,h as P,i as o,j as a}from"../../../_chunks/chunk-734CUXGP.js";import{a as s,c as n,d as p,f as g,g as R}from"../../../_chunks/chunk-BX2ZHUFS.js";var S=n(R(),1);var w=n(g(),1),e=n(R(),1);var l=class extends w.TemplatedDialog{constructor(t){super(t);this.permissions=new b(this.byId("Permissions"),{showRevoke:!1}),P.List({RoleID:this.options.roleID,Module:null,Submodule:null},D=>{this.permissions.value=D.Entities.map(m=>({PermissionKey:m}))}),this.permissions.implicitPermissions=(0,e.getRemoteData)("Administration.ImplicitPermissions")}getDialogOptions(){let t=super.getDialogOptions();return t.buttons=[{text:(0,e.localText)("Dialogs.OkButton"),click:D=>{P.Update({RoleID:this.options.roleID,Permissions:this.permissions.value.map(m=>m.PermissionKey),Module:null,Submodule:null},m=>{this.dialogClose(),window.setTimeout(()=>(0,e.notifySuccess)((0,e.localText)("Site.RolePermissionDialog.SaveSuccess")),0)})}},{text:(0,e.localText)("Dialogs.CancelButton"),click:()=>this.dialogClose()}],t.title=(0,e.format)((0,e.localText)("Site.RolePermissionDialog.DialogTitle"),this.options.title),t}getTemplate(){return'<div id="~_Permissions"></div>'}};s(l,"RolePermissionDialog");var c=n(g(),1);var I="edit-permissions",i=class extends c.EntityDialog{constructor(){super(...arguments);this.form=new f(this.idPrefix)}getFormKey(){return f.formKey}getIdProperty(){return o.idProperty}getLocalTextPrefix(){return o.localTextPrefix}getNameProperty(){return o.nameProperty}getService(){return a.baseUrl}getToolbarButtons(){let t=super.getToolbarButtons();return t.push({title:x.Site.RolePermissionDialog.EditButton,cssClass:I,icon:"fa-lock text-green",onClick:()=>{new l({roleID:this.entity.RoleId,title:this.entity.RoleName}).dialogOpen()}}),t}updateInterface(){super.updateInterface(),this.toolbar.findButton(I).toggleClass("disabled",this.isNewOrDeleted())}};s(i,"RoleDialog"),i=p([c.Decorators.registerClass("cyberbanking.Administration.RoleDialog")],i);var u=n(g(),1);var r=class extends u.EntityGrid{getColumnsKey(){return h.columnsKey}getDialogType(){return i}getIdProperty(){return o.idProperty}getLocalTextPrefix(){return o.localTextPrefix}getService(){return a.baseUrl}constructor(d){super(d)}getDefaultSortBy(){return[o.Fields.RoleName]}};s(r,"RoleGrid"),r=p([u.Decorators.registerClass("cyberbanking.Administration.RoleGrid")],r);$(function(){(0,S.initFullHeightGridPage)(new r($("#GridDiv")).element)});
//# sourceMappingURL=RolePage.js.map
