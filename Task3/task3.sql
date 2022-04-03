use Test;

with Temp (Id, Dt, rn)
as (
	select Id, Dt, row_number() over (partition by Id order by Dt) as rn
	from Dates)
select
  t1.Id,
  t3.Dt Sd,
  t1.Dt Ed

from Temp t1
   inner join Temp t3 
   on 
     t3.Id = t1.Id
     and t3.Dt = 
    (
     select max(t2.Dt)
     from Temp t2
     where
       t2.Id = t1.Id
       and t2.Dt < t1.Dt
    );


