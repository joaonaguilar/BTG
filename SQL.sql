CREATE TABLE tblHierarquia (ID integer primary key, FirstName varchar(50), LastName varchar(50), ReportsTo varchar(50), Position varchar(50), Age INT);

INSERT INTO tblHierarquia values(1, 'Daniel', 'Smith', 'Bob Boss', 'Engineer', 25);
INSERT INTO tblHierarquia values(2, 'Mike', 'White', 'Bob Boss', 'Contractor', 22);
INSERT INTO tblHierarquia values(3, 'Jenny', 'Richards', NULL, 'CEO', 45);
INSERT INTO tblHierarquia values(4, 'Robert', 'Black', 'Daniel Smith', 'Sales', 22);
INSERT INTO tblHierarquia values(5, 'Noah', 'Fritz', 'Jenny Richards', 'Assistant', 30);
INSERT INTO tblHierarquia values(6, 'David', 'S', 'Jenny Richards', 'Director', 32);
INSERT INTO tblHierarquia values(7, 'Ashley', 'Wells', 'David S', 'Assistant', 25);
INSERT INTO tblHierarquia values(8, 'Ashley', 'Johnson', NULL, 'Intern', 25);

QUESTÃO 2
select reportsto, count(1) 'numeroMembro', ROUND(AVG(age)) 'mediaIdade'
from tblHierarquia a 
where a.reportsto is not null
group by reportsto;

QUESTÃO 3
a) select b.placa, a.nome
form Cliente a inner join Veiculo b 
on a.cpf = b.Cliente_cpf;

a) select c.ender, b.dtEntrada, b.dtSaida
from Veiculo a inner join Estaciona b
on a.placa = b.Veiculo_placa
inner join Patio c
on c.num = b.Patio_num
where a.placa = 'BTG-2022';