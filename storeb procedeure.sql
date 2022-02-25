
alter proc sp_Employee
@action varchar(20),
@id int =0,
@name varchar(100)=null,
@email varchar(100)=null,
@mobile varchar(100)=null,
@gender varchar(10)=null,
@dept_id int =0
as 
begin
if(@action='CREATE')
begin
insert into Emplyoees(name,email,mobile,gender,department_id)values
(@name,@email,@mobile,@gender,@dept_id)
select 1 as result
end
else if (@action='DELETE')
  begin
  delete from Emplyoees where id=@id
  select 1 as result
  end
  else if(@action='SELECT')
begin
select*from Emplyoees
end
 else if(@action='SELECT_JOIN')
begin
select e.Id,e.name,e.email,e.mobile,
e.gender,d.name from Emplyoees e
inner join
Departments d
on e.id=d.id
end
else if(@action='UPDATE')
begin
update Emplyoees set name=@name,email=@email,mobile=@mobile,gender=@gender,
department_id=@dept_id where id=@id
select 1 as result
end
end