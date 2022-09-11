create database IFE
goto
USE IFE
create table CLIENT(nom_prenom varchar(50),CIN varchar(50) primary key,N_Telephone varchar(50),code_v varchar(50) foreign key references ville(code_v))
create table CONTRAT(code_c varchar(50) primary key,date_debut date,date_fin date,type_c varchar(50),signature_cl int,signature_M int,cin varchar(50) foreign key references CLIENT(cin))
create table detal_contrat(code_c varchar(50)foreign key references CONTRAT(code_c),code_p varchar(50)foreign key references PRODUIE(code_p),que int)
create table ville(code_v varchar(50) primary key,nom_ville varchar(50))
create table PRODUIE(code_p varchar(50)  primary key,marque varchar(50),modele varchar(50),garantie varchar(50),stock int,prix money)
create table FACTURE(code_P varchar(50) foreign key references PRODUIE(code_p) ,TOTAL_HT money,TOTAL_TVA money,TOTAL_TTC money)

select count(CIN) from CLIENT where CIN=

update CONTRAT set date_debut='" + textBox1.Text + "',date_fin='" + maskedTextBox2.Text + "',type_c='" + comboBox1.SelectedValue + "' where code_c='" + maskedTextBox1.Text + "'

--update CLIENT set nom_prenom='" + textBox1.Text + "',N_Telephone='" + textBox3.Text + "',code_v='" + comboBox1.SelectedValue + "',code_C='" + comboBox2.SelectedValue + "' where CIN='" + textBox2.Text + "'"
select CLIENT.CIN,CLIENT.nom_prenom,CLIENT.N_Telephone,ville.nom_ville from CLIENT ,ville where CLIENT.code_v=ville.code_v
--delete from CLIENT where CIN='" + textBox2.Text + "'"
delete from CONTRAT
drop table CONTRAT
--nsert into CLIENT values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "')

select * from CONTRAT


insert into CONTRAT values ('RRY3 ','2-3-2002','2-4-2021','SSD','','','E32637')

select count(code_p) from PRODUIE where code_p=

select * from PRODUIE
create table CONTRAT_engagement(CODE_C varchar(50) primary key, NOME_ENTREPRISE varchar(50), MONE_PRENOME varchar(50), CIN varchar(50), POSITION varchar(50), PIUSSANCE varchar(50) ,ADRESSE varchar(50) ,LES_JOURE varchar (50))