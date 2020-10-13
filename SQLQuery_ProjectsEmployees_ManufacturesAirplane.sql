
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
WHERE p.Id = (
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
WHERE p.Id = (
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
