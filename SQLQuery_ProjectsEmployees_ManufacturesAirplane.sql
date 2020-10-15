
use [WpfApp_ADO_NET_CodeFirst.Model_ManufacturerAirplane]
GO

select * from Airplanes
select * from Manufacturers

select a.Id,a.Model,a.Price,a.Speed,m.BrandTitle from Airplanes a, Manufacturers m
where a.Speed<600 and a.VendorId=m.VendorId

select DISTINCT m.BrandTitle from Airplanes a, Manufacturers m
where a.VendorId=m.VendorId and (select COUNT(a.Id) cnt from Airplanes a where a.VendorId=m.VendorId group by a.VendorId)>3

select m.BrandTitle from Manufacturers m
where Len(m.BrandTitle)<7
GO

create function GetAirplaineWithSpeedLess(@st int)
returns table
as
return 
select a.Id,a.Model,a.Price,a.Speed,m.BrandTitle from Airplanes a, Manufacturers m
where a.Speed<@st and a.VendorId=m.VendorId
GO

create function GetManufacturerWithAirplaneMore(@st int)
returns table
as
return 
select DISTINCT m.BrandTitle from Airplanes a, Manufacturers m
where a.VendorId=m.VendorId and (select COUNT(a.Id) cnt from Airplanes a where a.VendorId=m.VendorId group by a.VendorId)>@st
GO

create function GetManufacturerNameWithLengthLess(@st int)
returns table
as
return 
select m.BrandTitle from Manufacturers m
where Len(m.BrandTitle)<@st
GO


Use [WpfApp_ADO_NET_CodeFirst.Model_ProjectsEmployees]

select * from Projects
select * from Employees
select * from ProjectEmployees

SELECT p.Id,p.Title
FROM Projects p 
WHERE p.Id in (
    SELECT pe.ProjectId
    FROM ProjectEmployees pe GROUP BY pe.ProjectId
    HAVING count(pe.ProjectId)=
		(
    SELECT MAX(g.cnt)
    FROM (SELECT COUNT(ppe.ProjectId) cnt 
	FROM ProjectEmployees ppe 
	GROUP BY ppe.ProjectId) g
	)
	)

select e.FirstName,e.LastName from Employees e
where e.Age<35

select e.FirstName,e.LastName from Employees e
where Len(e.LastName)>=5

create function GetProjectWithMaxEmployees()
returns table
as
return 
SELECT p.Id,p.Title
FROM Projects p 
WHERE p.Id IN (
    SELECT pe.ProjectId
    FROM ProjectEmployees pe GROUP BY pe.ProjectId
    HAVING count(pe.ProjectId)=
		(
    SELECT MAX(g.cnt)
    FROM (SELECT COUNT(ppe.ProjectId) cnt 
	FROM ProjectEmployees ppe 
	GROUP BY ppe.ProjectId) g
	)
	)
GO

create function GetEmployeerWithAgeLess(@st int)
returns table
as
return 
select e.FirstName,e.LastName from Employees e
where e.Age<@st
GO

create function GetEmployeerWithLastNameLengthMoreOrEqual(@st int)
returns table
as
return 
select e.FirstName,e.LastName from Employees e
where Len(e.LastName)>=@st
GO


SELECT * 
INTO [dbo].[ProjectEmployees1]
FROM  [dbo].[ProjectEmployees]


--SQLDataReader
GO
select a.Id,a.Model,a.Price,a.Speed,a.VendorId,m.BrandTitle from Airplanes a, Manufacturers m
where a.VendorId=m.VendorId
Go

select Airplanes.Id,Airplanes.Model,Airplanes.Price,Airplanes.Speed,Airplanes.VendorId,Manufacturers.BrandTitle
from Airplanes, Manufacturers
where Airplanes.VendorId = Manufacturers.VendorId




select p.*,p.Description from Projects p, Employees e, ProjectEmployees pe
where e.id=pe.EmployeeId and pe.ProjectId=p.id

select p.* from ProjectEmployees pe, Projects p
where pe.EmployeeId=2 and p.Id=pe.ProjectId


select e.* from ProjectEmployees pe, Employees e
where pe.ProjectId=2 and e.Id=pe.EmployeeId


--SQLDataAdapter

select * from Manufacturers
select a.*, m.BrandTitle Vendor from Airplanes a, Manufacturers m where a.VendorId = m.VendorId

select * from Manufacturers


select p.*,(select e.* from ProjectEmployees pe, Employees e
where pe.EmployeeId=e.Id and pe.ProjectId = p.Id
) AS Employees from Projects p


select p.*,a.* from Projects p
Join
(select e.*, pe.ProjectId from ProjectEmployees pe, Employees e
where pe.EmployeeId=e.Id) a on a.ProjectId = p.Id


delete Employees where Id=1

delete Projects where Id=1

select * from Projects
select * from ProjectEmployees
select * from Employees





