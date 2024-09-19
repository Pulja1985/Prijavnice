create table vozaci(
sifra int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
oib char(11),
);
create table vozila(
sifra int not null primary key identity(1,1),
marka varchar(50) not null,
model varchar(50) not null,
snaga varchar(50) not null,
pogon varchar(50) not null,
vozaci_sifra int not null
);
create table utrke(
sifra int not null primary key identity(1,1),
datum datetime not null,
mjesto varchar(50) not null,
naziv varchar(50) not null 
);
create table vozila_utrke(
vozilo_sifra int not null,
utrke_sifra int not null
);
alter table vozila_utrke add foreign key(vozilo_sifra)references vozila(sifra);
alter table vozila add foreign key(vozaci_sifra)references vozaci(sifra);
alter table vozila_utrke add foreign key (utrke_sifra)references utrke(sifra);



insert into vozaci(ime,prezime,oib)values
('Hrvoje','Puljić-Ilić','24104444467'),
('Dominik','Puljić-Ilić','12345678901'),
('Matija','Puljić-Ilić','23456789012'),
('Slaven','Krainović','34567890123');

select * from vozaci;


insert into vozila(marka,model,snaga,pogon,vozaci_sifra)values
('Honda','Civic_ek4',160,'prednji',1),
('Honda','Civic_ej2',185,'prednji',2),
('Honda','Accord_cl8',155,'prednji',3),
('Honda','Civic_eg4',150,'prednji',4);

select * from vozila;


insert into utrke(datum,mjesto,naziv)values
('2024-06-01 09:00','Budapest','Honda day'),
('2024-05-15 09:00','Osijek','Osrs31'),
('2024-07-05 10:00','Santa pod','Honda day'),
('2024-06-01 09:00','Osijek','Osrs32');

select * from utrke;


insert into vozila_utrke(vozilo_sifra,utrke_sifra)values
(1,1),(2,1),(3,1),(4,1);

select * from vozila_utrke;