/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     05/19/2016 20:31:15                          */
/*==============================================================*/
select 'DROP TABLE '||TNAME||' CASCADE CONSTRAINT PURGE;' FROM TAB;

alter table DBARANG
   drop constraint FK_DBARANG_CHECK_BARANG;

alter table DBELI
   drop constraint FK_DBELI_ADD_HBELI;

alter table DBELI
   drop constraint FK_DBELI_ADD2_BARANG;

alter table DJUAL
   drop constraint FK_DATA_PEN_HAVE_BARANG;

alter table DJUAL
   drop constraint FK_DATA_PEN_HAVE_PENJUALA;

alter table DSO
   drop constraint FK_DATA_SO_HAVE_BARANG;

alter table DSO
   drop constraint FK_DATA_SO_HAVE_STOK_OPN;

alter table HBELI
   drop constraint FK_HBELI_DO_SUPPLIER;

alter table HJUAL
   drop constraint FK_HJUAL_HAVE_PELANGGA;

alter table HJUAL
   drop constraint FK_JUAL_HAVE_USER_GMM;

alter table HSO
   drop constraint FK_HSO_MAKE_USER_GMM;

alter table USER_GMM
   drop constraint FK_USER_GMM_HAS_GUDANG;

drop table BARANG cascade constraints;

drop index CHECK_FK;

drop table DBARANG cascade constraints;

drop index ADD2_FK;

drop index ADD_FK;

drop table DBELI cascade constraints;

drop index ADD2_FK2;

drop table DJUAL cascade constraints;

drop table DSO cascade constraints;

drop table GUDANG cascade constraints;

drop index DO_FK;

drop table HBELI cascade constraints;

drop table HJUAL cascade constraints;

drop table HSO cascade constraints;

drop table PELANGGAN cascade constraints;

drop table SUPPLIER cascade constraints;

drop table USER_GMM cascade constraints;

/*==============================================================*/
/* Table: BARANG                                                */
/*==============================================================*/
create table BARANG 
(
   KODE_BARANG          VARCHAR2(10)         not null,
   NAMA                VARCHAR2(70),
   ALIAS                VARCHAR2(70),
   KATEGORI             VARCHAR2(40),
   JENIS_MOBIL          VARCHAR2(25),
   LOKASI               VARCHAR2(10),
   QTY                  NUMBER(4) NOT NULL,
   SATUAN               VARCHAR2(10),
   HARGA_JUAL           NUMBER(20),
   HARGA_BELI           NUMBER(20),
   ISD					CHAR CONSTRAINT CEKDELBRG CHECK(ISD IN(1,0)),
   constraint PK_BARANG primary key (KODE_BARANG),
   constraint check_QTYBRG check(QTY>=0)
);


/*==============================================================*/
/* Table: DBARANG                                               */
/*==============================================================*/
create table DBARANG 
(
   KODE_BARANG          VARCHAR2(10),
   PART_NO              VARCHAR2(80),
   PIC                  BLOB
);

/*==============================================================*/
/* Index: CHECK_FK                                              */
/*==============================================================*/
create index CHECK_FK on DBARANG (
   KODE_BARANG ASC
);

/*==============================================================*/
/* Table: DBELI                                                 */
/*==============================================================*/
create table DBELI 
(
   KODE_NOTA_PEMBELIAN  VARCHAR2(15)         not null,
   KODE_BARANG          VARCHAR2(10)         not null,
   QTY                  NUMBER(10) NOT NULL,
   HARGA_BELI           NUMBER(20),
   SUBTOTAL             NUMBER(10),
   constraint PK_DBELI primary key (KODE_NOTA_PEMBELIAN, KODE_BARANG),
   constraint check_QTY_DBELI check(QTY>=1)
);

/*==============================================================*/
/* Index: ADD_FK                                                */
/*==============================================================*/
create index ADD_FK on DBELI (
   KODE_NOTA_PEMBELIAN ASC
);

/*==============================================================*/
/* Index: ADD2_FK                                               */
/*==============================================================*/
create index ADD2_FK on DBELI (
   KODE_BARANG ASC
);

/*==============================================================*/
/* Table: DJUAL                                                 */
/*==============================================================*/
create table DJUAL 
(
   KODE_BARANG          VARCHAR2(10)         not null,
   NOTA_PENJUALAN       varchar2(15)         not null,
   QTY                  NUMBER(10) NOT NULL,
   SUBTOTAL             NUMBER(12),
   HARGA_JUAL           NUMBER(20),
   DISC           FLOAT,
   constraint PK_DJUAL primary key (KODE_BARANG, NOTA_PENJUALAN),
   constraint check_QTY_DJUAL check(QTY>=1)
);

/*==============================================================*/
/* Index: ADD2_FK2                                              */
/*==============================================================*/
create index ADD2_FK2 on DJUAL (
   KODE_BARANG ASC
);

/*==============================================================*/
/* Table: DSO                                                   */
/*==============================================================*/
create table DSO 
(
   KODE_SO              varchar2(10)         not null,
   KODE_BARANG          VARCHAR2(10)         not null,
   QTY NUMBER(10) NOT NULL,
   constraint PK_DSO primary key (KODE_SO, KODE_BARANG),
   constraint check_QTY_DSO check(QTY>=1)
);

/*==============================================================*/
/* Table: GUDANG                                                */
/*==============================================================*/
create table GUDANG 
(
   KODE_GUDANG          varchar2(10)         not null,
   NAMA                 varchar(30)          not null,
   ALAMAT               varchar2(70)         not null,
   KOTA                 varchar2(20),
   PHONE                varchar(40),
   CP                   varchar(25),
   KETERANGAN           varchar(100),
   ISD					CHAR CONSTRAINT CEKDELGDG CHECK(ISD IN(1,0)),
   constraint PK_GUDANG primary key (KODE_GUDANG)
);

/*==============================================================*/
/* Table: HBELI                                                 */
/*==============================================================*/
create table HBELI 
(
   ID_BELI              VARCHAR2(15)         not null,
   KODE_SUPPLIER        VARCHAR2(10)         not null,
   JENIS_PEMBAYARAN     number(2)            not null,
   TANGGAL_BUAT         DATE                 not null,
   TOTAL                number(12)           not null,
   TANGGAL_LUNAS        date,
   ISD					CHAR CONSTRAINT CEKDELHBELI  CHECK(ISD IN(1,0)),
   constraint PK_HBELI primary key (ID_BELI)
);

/*==============================================================*/
/* Index: DO_FK                                                 */
/*==============================================================*/
create index DO_FK on HBELI (
   KODE_SUPPLIER ASC
);

/*==============================================================*/
/* Table: HJUAL                                                 */
/*==============================================================*/
create table HJUAL 
(
   NOTA_PENJUALAN       varchar2(15)         not null,
   KODE_USER            VARCHAR2(10)         not null,
   KODE_GUDANG          varchar2(10)         not null,
   KODE_PELANGGAN       VARCHAR2(10)         not null,
   JENIS_PEMBAYARAN     number(2)            not null,
   TANGGAL_BUAT         DATE                 not null,
   TOTAL                number(12)           not null,
   TANGGAL_LUNAS        date,
   STATE                VARCHAR2(1),
   ISD					CHAR CONSTRAINT CEKDELHJUAL CHECK(ISD IN(1,0)),
   constraint PK_HJUAL primary key (NOTA_PENJUALAN)
);

/*==============================================================*/
/* Table: HSO                                                   */
/*==============================================================*/
create table HSO 
(
   KODE_USER            VARCHAR2(10)         not null,
   KODE_GUDANG          varchar2(10)         not null,
   KODE_SO              varchar2(10)         not null,
   KETERANGAN           varchar(100),
   TANNGAL              date                 not null,
   ISD					CHAR CONSTRAINT CEKDELHSO CHECK(ISD IN(1,0)),
   constraint PK_HSO primary key (KODE_SO)
);

/*==============================================================*/
/* Table: PELANGGAN                                             */
/*==============================================================*/
create table PELANGGAN 
(
   KODE_PELANGGAN       VARCHAR2(10)         not null,
   NAMA                 VARCHAR2(30)         not null,
   ALAMAT               vaRCHAR2(70),
   KOTA                 VARCHAR(25),
   PHONE                varchar(40),
   CP                   varchar2(25),
   KETERANGAN           varchar2(100),
   ISD					CHAR CONSTRAINT CEKDELPLG CHECK(ISD IN(1,0)),
   constraint PK_PELANGGAN primary key (KODE_PELANGGAN)
);

/*==============================================================*/
/* Table: SUPPLIER                                              */
/*==============================================================*/
create table SUPPLIER 
(
   ID_SUPLIER           VARCHAR2(10)         not null,
   NAMA                 VARCHAR2(30)         not null,
   ALAMAT               VARCHAR2(70)         not null,
   KOTA                 VARCHAR2(20)         not null,
   PHONE                varchar2(40),
   CP                   VARCHAR2(25),
   KETERANGAN           VARCHAR2(100),
   ISD					CHAR CONSTRAINT CEKDELSPL CHECK(ISD IN(1,0)),
   constraint PK_SUPPLIER primary key (ID_SUPLIER)
);

/*==============================================================*/
/* Table: USER_GMM                                              */
/*==============================================================*/
create table USER_GMM 
(
   KODE_USER            VARCHAR2(10)         not null,
   KODE_GUDANG          varchar2(10)         not null,
   USERNAME             VARCHAR2(30)         not null,
   ALAMAT               VARCHAR2(70),
   ROLE                 VARCHAR2(25)         not null,
   GAJI                 NUMBER(12),
   NAMA                 VARCHAR2(30)         not null,
   ISD					CHAR CONSTRAINT CEKDELUSER CHECK(ISD IN(1,0)),
   constraint PK_USER_GMM primary key (KODE_USER, KODE_GUDANG)
);

alter table DBARANG
   add constraint FK_DBARANG_CHECK_BARANG foreign key (KODE_BARANG)
      references BARANG (KODE_BARANG);

alter table DBELI
   add constraint FK_DBELI_ADD_HBELI foreign key (KODE_NOTA_PEMBELIAN)
      references HBELI (ID_BELI);

alter table DBELI
   add constraint FK_DBELI_ADD2_BARANG foreign key (KODE_BARANG)
      references BARANG (KODE_BARANG);

alter table DJUAL
   add constraint FK_DATA_PEN_HAVE_BARANG foreign key (KODE_BARANG)
      references BARANG (KODE_BARANG);

alter table DJUAL
   add constraint FK_DATA_PEN_HAVE_PENJUALA foreign key (NOTA_PENJUALAN)
      references HJUAL (NOTA_PENJUALAN);

alter table DSO
   add constraint FK_DATA_SO_HAVE_BARANG foreign key (KODE_BARANG)
      references BARANG (KODE_BARANG);

alter table DSO
   add constraint FK_DATA_SO_HAVE_STOK_OPN foreign key (KODE_SO)
      references HSO (KODE_SO);

alter table HBELI
   add constraint FK_HBELI_DO_SUPPLIER foreign key (KODE_SUPPLIER)
      references SUPPLIER (ID_SUPLIER);

alter table HJUAL
   add constraint FK_HJUAL_HAVE_PELANGGA foreign key (KODE_PELANGGAN)
      references PELANGGAN (KODE_PELANGGAN);

alter table HJUAL
   add constraint FK_JUAL_HAVE_USER_GMM foreign key (KODE_USER, KODE_GUDANG)
      references USER_GMM (KODE_USER, KODE_GUDANG);

alter table HSO
   add constraint FK_HSO_MAKE_USER_GMM foreign key (KODE_USER, KODE_GUDANG)
      references USER_GMM (KODE_USER, KODE_GUDANG);

alter table USER_GMM
   add constraint FK_USER_GMM_HAS_GUDANG foreign key (KODE_GUDANG)
      references GUDANG (KODE_GUDANG);

