CREATE DATABASE experteam;

USE experteam;

/*==============================================================*/
/* Table: guide                                                 */
/*==============================================================*/
create table guide (
   id_guide             int identity(1,1)    not null,
   number_guide         varchar(10)          null,
   shipping_date        datetime default getdate() null,
   country_origin       varchar(100)         null,
   sender_name          varchar(100)         null,
   sender_address       varchar(100)         null,
   sender_phone         varchar(50)          null,
   sender_email         varchar(50)          null,
   destination_country  varchar(100)         null,
   recipient_name       varchar(100)         null,
   recipient_address    varchar(100)         null,
   recipient_phone      varchar(50)          null,
   recipient_email      varchar(50)          null,
   total                decimal(18,2)        null,
   constraint pk_guide primary key (id_guide)
)
go

/*==============================================================*/
/* Table: invoice                                               */
/*==============================================================*/
create table invoice (
   id_invoice           int identity(1,1)    not null,
   establishment        varchar(3)           not null,
   emission_point       varchar(3)           not null,
   sequential           int                  null,
   date_issue           datetime default getdate() null,
   subtotal             decimal(18,2)        null,
   tax                  decimal(18,2)        null,
   total                decimal(18,2)        null,
   constraint pk_invoice primary key (id_invoice)
)
go

/*==============================================================*/
/* Table: invoice_guide                                         */
/*==============================================================*/
create table invoice_guide (
   id_guide             int                  not null,
   id_invoice           int                  not null,
   constraint pk_invoice_guide primary key (id_guide, id_invoice)
)
go

/*==============================================================*/
/* Index: invoice_guide_fk                                      */
/*==============================================================*/




create nonclustered index invoice_guide_fk on invoice_guide (id_guide asc)
go

/*==============================================================*/
/* Index: invoice_guide2_fk                                     */
/*==============================================================*/




create nonclustered index invoice_guide2_fk on invoice_guide (id_invoice asc)
go

/*==============================================================*/
/* Table: invoice_payment                                       */
/*==============================================================*/
create table invoice_payment (
   id_invoice           int                  not null,
   id_payment           int                  not null,
   constraint pk_invoice_payment primary key (id_invoice, id_payment)
)
go

/*==============================================================*/
/* Index: invoice_payment_fk                                    */
/*==============================================================*/




create nonclustered index invoice_payment_fk on invoice_payment (id_invoice asc)
go

/*==============================================================*/
/* Index: invoice_payment2_fk                                   */
/*==============================================================*/




create nonclustered index invoice_payment2_fk on invoice_payment (id_payment asc)
go

/*==============================================================*/
/* Table: payment                                               */
/*==============================================================*/
create table payment (
   id_payment           int identity(1,1)    not null,
   payment_type         varchar(100)         null,
   value                decimal(18,2)        null,
   constraint pk_payment primary key (id_payment)
)
go

alter table invoice_guide
   add constraint fk_invoice__invoice_g_guide foreign key (id_guide)
      references guide (id_guide)
go

alter table invoice_guide
   add constraint fk_invoice__invoice_g_invoice foreign key (id_invoice)
      references invoice (id_invoice)
go

alter table invoice_payment
   add constraint fk_invoice__invoice_p_invoice foreign key (id_invoice)
      references invoice (id_invoice)
go

alter table invoice_payment
   add constraint fk_invoice__invoice_p_payment foreign key (id_payment)
      references payment (id_payment)
go
