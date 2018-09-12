sqllite3
// inital setup
create table toys (id integer, price real, description text, quantity integer);
//adding 10 items to table
insert into toys values (1, 3.99, 'GI Joe', 10);
insert into toys values (2, 15.99, 'Barbie', 15);
insert into toys values (3, 5.99, 'Ball', 21);
insert into toys values (4, 7.99, 'Lego', 17);
insert into toys values (5, 9,99, 'JumpRope', 6);
insert into toys values (6, 4.99, 'Silly Putty', 19);
insert into toys values (7, 8.99, 'Hackey Sack', 14);
insert into toys values (8, 21.99, 'Skateboard', 7);
insert into toys values (9, 5,99, 'Crayons', 29);
insert into toys values (10, 4.99, 'Chalk', 10);
select * from toys;
.mode column
.headers on
//deleting items
delete from toys where id = 3;
//adding back ball
insert into toys values (3, 5.99, 'Ball', 21);
//query
select * from toys;
// create isle table
create table isles (aisle integer, name text);
//inserting aisles (values)
insert into aisles values (1, 'Babies');
insert into aisles values (2, 'Boys');
insert into aisles values (3, 'Girls');
insert into aisles values (4, 'Games');
//adding aisle key
ALTER TABLE toys
ADD aisle VARCHAR;
//puting toys in aisles
update toys set aisle = 2 where id = 1;
update toys set aisle = 3 where id = 2;
update toys set aisle = 4 where id = 3;
update toys set aisle = 4 where id = 4;
update toys set aisle = 4 where id = 5;
update toys set aisle = 4 where id = 6;
update toys set aisle = 4 where id = 7;
update toys set aisle = 4 where id = 8;
update toys set aisle = 4 where id = 9;
update toys set aisle = 4 where id = 10;
//query of description, aisle, quantity
select description, quantity, aisle from toys;

