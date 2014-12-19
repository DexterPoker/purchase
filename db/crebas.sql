/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Created on:     2013-12-11 20:08:39                          */
/*==============================================================*/


alter table MTL_ON_HAND
   drop constraint FK_MTL_ON_H_REFERENCE_MTL_ITEM
go

alter table PO_HEADERS_ALL
   drop constraint FK_PO_HEADE_REFERENCE_PO_VENDE
go

alter table PO_LINES_ALL
   drop constraint FK_PO_LINES_REFERENCE_MTL_ITEM
go

alter table PO_LINES_ALL
   drop constraint FK_PO_LINES_REFERENCE_PO_HEADE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('HR_PERSON')
            and   type = 'U')
   drop table HR_PERSON
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MTL_ITEMS_ALL')
            and   type = 'U')
   drop table MTL_ITEMS_ALL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MTL_ON_HAND')
            and   type = 'U')
   drop table MTL_ON_HAND
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PO_HEADERS_ALL')
            and   type = 'U')
   drop table PO_HEADERS_ALL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PO_LINES_ALL')
            and   type = 'U')
   drop table PO_LINES_ALL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PO_VENDERS_ALL')
            and   type = 'U')
   drop table PO_VENDERS_ALL
go

/*==============================================================*/
/* Table: HR_PERSON                                             */
/*==============================================================*/
create table HR_PERSON (
   emp_num              int identity(1000,1)                  not null,
   hr_emp_num           int                  null,
   name                 varchar(100)         null,
   job                  varchar(100)         null,
   department           varchar(100)         null,
   password             varchar(20)          null,
   constraint PK_HR_PERSON primary key  (emp_num)
)
go

/*==============================================================*/
/* Table: MTL_ITEMS_ALL                                         */
/*==============================================================*/
create table MTL_ITEMS_ALL (
   item_num             int identity(1000,1)                  not null,
   item_description     varchar(200)         null,
   item_type            varchar(100)         null,
   constraint PK_MTL_ITEMS_ALL primary key  (item_num)
)
go

/*==============================================================*/
/* Table: MTL_ON_HAND                                           */
/*==============================================================*/
create table MTL_ON_HAND (
   sub_inventory        varchar(50)          not null,
   item_num             int                  null,
   qty                  int                  null,
   constraint PK_MTL_ON_HAND primary key  (sub_inventory)
)
go

/*==============================================================*/
/* Table: PO_HEADERS_ALL                                        */
/*==============================================================*/
create table PO_HEADERS_ALL (
   po_header_id         int identity(1000,1)                  not null,
   po_number            int                  null,
   po_type              varchar(20)          null,
   vender_code          int                  null,
   status               int                  null,
   constraint PK_PO_HEADERS_ALL primary key  (po_header_id)
)
go

/*==============================================================*/
/* Table: PO_LINES_ALL                                          */
/*==============================================================*/
create table PO_LINES_ALL (
   po_line_id           int identity(1000,1)                 not null,
   po_header_id         int                  null,
   item_num             int                  null,
   line_num             int                  null,
   quantity             int                  null,
   received_quantity    int                  null,
   price                float                null,
   constraint PK_PO_LINES_ALL primary key  (po_line_id)
)
go

/*==============================================================*/
/* Table: PO_VENDERS_ALL                                        */
/*==============================================================*/
create table PO_VENDERS_ALL (
   vender_code          int identity(1000,1)                 not null,
   vender_name          varchar(200)         null,
   address              varchar(200)         null,
   contact              varchar(200)         null,
   phone                varchar(50)          null,
   constraint PK_PO_VENDERS_ALL primary key  (vender_code)
)
go

alter table MTL_ON_HAND
   add constraint FK_MTL_ON_H_REFERENCE_MTL_ITEM foreign key (item_num)
      references MTL_ITEMS_ALL (item_num)
go

alter table PO_HEADERS_ALL
   add constraint FK_PO_HEADE_REFERENCE_PO_VENDE foreign key (vender_code)
      references PO_VENDERS_ALL (vender_code)
go

alter table PO_LINES_ALL
   add constraint FK_PO_LINES_REFERENCE_MTL_ITEM foreign key (item_num)
      references MTL_ITEMS_ALL (item_num)
go

alter table PO_LINES_ALL
   add constraint FK_PO_LINES_REFERENCE_PO_HEADE foreign key (po_header_id)
      references PO_HEADERS_ALL (po_header_id)
go

