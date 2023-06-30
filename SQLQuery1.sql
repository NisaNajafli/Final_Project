--create database Exam2506
--use Exam2506
----4)15.05.1986 tarixindən sonra anadan olan işçilərin(isciler)
----adını(isad) , şöbənin nömrəsini(sobnom) təyin edən SQL operatorunu
----yaz => dogum tarixi(date)

--create table Soba(
--      soba_nom int identity(1,1) primary key,
--	  soba_ad nvarchar(40),
--	  orta_maas money
--)
--create table Isci(
--      is_nom int identity(1,1) primary key,
--	  is_ad nvarchar(30),
--	  is_soyad nvarchar(40),
--	  is_maas money,
--	  is_date date,
--	  soba_nom int references Soba(soba_nom)
--)

--insert into Soba
--values
--    ('soba_1',145),
--	('soba_2',245),
--	('soba_3',345),
--	('soba_4',455),
--	('soba_5',555)
--insert into Isci
--values
--      ('Elgiz','Mammedov', 1500,'1986-05-20',1),
--	  ('Ali','Ibrahimov', 2500, '1984-05-15',3),
--	  ('Esger','Namazov', 3500,'1990-05-23',2),
--	  ('Zahid','Mammadov', 4500,'1986-09-19',5),
--	  ('Memmed','Aliyev', 5500,'1985-05-15',4)
--select is_ad,soba_nom from Isci 
--where is_date>'1986-05-15'


----3)Leyla cədvəlindən detalın nömrəsi(detn) 2-dən böyük 
----olan sətirləri seçən SQL komandalar ardıcıllığını yaz
--create table Leyla(
--       Id int Identity(1,1) primary key,
--	   detal_name nvarchar(30),
--	   detal_nom int
--)
--insert into Leyla
--Values
--     ('detal_1',2),
--	 ('detal_2',6),
--	 ('detal_3',10),
--	 ('detal_4',12),
--	 ('detal_5',1)
--select * from Leyla 
--Where detal_nom>2


----5)P(pnum,pname, psatus)- İstehsalcı cədvəlində statusu maksimum 
----statusdan az olan istehsalçıların siyahısını təyin  edən SQL operatorunu yaz
--create table P(
--        p_num int Identity(1,1) primary key,
--		p_name nvarchar(255),
--		p_status int
--)
--insert into P
--Values
--      ('p_1',100),
--	  ('p_2',150),
--	  ('p_3',400),
--	  ('p_4',200),
--	  ('p_5',250)
--Select * From P
--Where p_status<(Select Max(p_status) From P)


----6)IŞÇİ(nom,name,emek_haqqı,sobanom,proekt_nom)  cədvəli verilib Əmək haqqı
----200-dən çox olan işçinin adını və proekt nömrəsini təyin edən SQL operatorunu yaz

--create table Soba(
--      soba_nom int identity(1,1) primary key,
--	  soba_ad nvarchar(40),
--	  orta_maas money
--)
--create table Proyekt(
--      p_nom int identity(1,1) primary key,
--	  p_ad nvarchar(30)
--)
--create table Isci(
--      nom int identity(1,1) primary key,
--	  is_name nvarchar(30),
--	  emek_haqqi money,
--	  soba_nom int references Soba(soba_nom),
--	  p_nom int references Proyekt(p_nom)
--)

--insert into Soba
--values
--    ('soba_1',145),
--	('soba_2',245),
--	('soba_3',345),
--	('soba_4',455),
--	('soba_5',555)
--insert into Proyekt
--Values
--     ('proyekt_1'),
--	 ('proyekt_2')
--insert into Isci
--values
--      ('Elgiz', 1500,1,1),
--	  ('Ali',2500,3,2),
--	  ('Esger', 3500,2,2),
--	  ('Zahid', 4500,5,1),
--	  ('Memmed', 5500,4,1)
--Select Isci.is_name, Isci.p_nom from Isci
--where emek_haqqi>200


--7)People cədvəlinə P cədvəlindən istehsalçının nömrəsi 
--2-dən böyük olan istehsalçılar əlavə edən SQL operatorunu yaz
create table People(
     id int primary key identity(1,1),
	 people_num int,
	 people_name nvarchar(30)
)
insert into People(people_num,people_name) 
select p_num,p_name from P
where p_num>2
