create or replace package human_resources
as
 type t_cursor is ref cursor;
 procedure get_employee(cur_employees out t_cursor);
end human_resources;

create or replace package body human_resources
as
 procedure get_employee(cur_employees out t_cursor)
 is
 begin
  open cur_employees for select EMPNO, ENAME, JOB from emp;
 end get_employee;
end human_resources;