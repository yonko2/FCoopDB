USE FCoopDB

-- 1 --
CREATE OR ALTER FUNCTION udf_GetRentedPlotsByPlotID(@pltID NVARCHAR(7))
RETURNS @tblGetRentedPlotsByPlotID TABLE
(
	PlotID NVARCHAR(7) ,
	Location NVARCHAR(20),
	Municipality NVARCHAR(20),
	Type INT,
	Area DECIMAL(10,1)
)
AS
BEGIN 
	INSERT INTO @tblGetRentedPlotsByPlotID
	(
		PlotID,Location,Municipality,Type,Area
	)
	SELECT * FROM Plots WHERE PlotID=@pltID
	IF NOT EXISTS(SELECT * FROM Plots WHERE @pltID=PlotID)
	BEGIN 
		INSERT INTO @tblGetRentedPlotsByPlotID(PlotID,Location,Municipality,Type,Area)
		VALUES (NULL,NULL,NULL,NULL,NULL)
		RETURN
		END
	RETURN
END
GO
SELECT * FROM dbo.udf_GetRentedPlotsByPlotID(N'В-12345')
SELECT * FROM dbo.udf_GetRentedPlotsByPlotID(N'В-1245')

GO

CREATE OR ALTER FUNCTION udf_GetRentedPlotsByLocation(@pltLoc NVARCHAR(20))
RETURNS @tblGetRentedPlotsByLocation TABLE
(
	PlotID NVARCHAR(7) ,
	Location NVARCHAR(20),
	Municipality NVARCHAR(20),
	Type INT,
	Area DECIMAL(10,1)
)
AS
BEGIN 
	INSERT INTO @tblGetRentedPlotsByLocation
	(
		PlotID,Location,Municipality,Type,Area
	)
	SELECT * FROM Plots WHERE [Location]=@pltLoc
	IF NOT EXISTS(SELECT * FROM Plots WHERE @pltLoc=[Location])
	BEGIN 
		INSERT INTO @tblGetRentedPlotsByLocation(PlotID,Location,Municipality,Type,Area)
		VALUES (NULL,NULL,NULL,NULL,NULL)
		RETURN
		END
	RETURN
END
GO
SELECT * FROM dbo.udf_GetRentedPlotsByLocation(N'Венчан')
SELECT * FROM dbo.udf_GetRentedPlotsByLocation(N'Венча')
GO

CREATE OR ALTER FUNCTION udf_GetRentedPlotsByType(@pltType INT)
RETURNS @tblGetRentedPlotsByType TABLE
(
	PlotID NVARCHAR(7) ,
	Location NVARCHAR(20),
	Municipality NVARCHAR(20),
	Type INT,
	Area DECIMAL(10,1)
)
AS
BEGIN 
	INSERT INTO @tblGetRentedPlotsByType
	(
		PlotID,Location,Municipality,Type,Area
	)
	SELECT * FROM Plots WHERE Type=@pltType
	IF NOT EXISTS(SELECT * FROM Plots WHERE @pltType=Type)
	BEGIN 
		INSERT INTO @tblGetRentedPlotsByType(PlotID,Location,Municipality,Type,Area)
		VALUES (NULL,NULL,NULL,NULL,NULL)
		RETURN
		END
	RETURN
END
GO
SELECT * FROM dbo.udf_GetRentedPlotsByType(2)
SELECT * FROM dbo.udf_GetRentedPlotsByType(4)
GO

CREATE OR ALTER FUNCTION udf_GetRentedPlotsByArea(@pltArea DECIMAL(10,1))
RETURNS @tblGetRentedPlotsByArea TABLE
(
	PlotID NVARCHAR(7) ,
	Location NVARCHAR(20),
	Municipality NVARCHAR(20),
	Type INT,
	Area DECIMAL(10,1)
)
AS
BEGIN 
	INSERT INTO @tblGetRentedPlotsByArea
	(
		PlotID,Location,Municipality,Type,Area
	)
	SELECT * FROM Plots WHERE Area=@pltArea
	IF NOT EXISTS(SELECT * FROM Plots WHERE @pltArea=Area)
	BEGIN 
		INSERT INTO @tblGetRentedPlotsByArea(PlotID,Location,Municipality,Type,Area)
		VALUES (NULL,NULL,NULL,NULL,NULL)
		RETURN
		END
	RETURN
END
GO
SELECT * FROM dbo.udf_GetRentedPlotsByArea(4)
SELECT * FROM dbo.udf_GetRentedPlotsByArea(4.2)
GO

-- 2 --
CREATE OR ALTER FUNCTION udf_GetPlantByPlotID(@pltID NVARCHAR(7))
RETURNS @tblGetPlantByPlotID TABLE
(
	Plant NVARCHAR(20)
)
AS
BEGIN 
	INSERT INTO @tblGetPlantByPlotID
	(
		Plant
	)
	SELECT DISTINCT Plant FROM Contracts AS c
	INNER JOIN Deals AS d ON d.ContractID=c.ContractID
	INNER JOIN Plots AS p ON d.PlotID=@pltID
	IF NOT EXISTS(SELECT PlotID FROM Plots WHERE @pltID=PlotID)
	BEGIN 
		INSERT INTO @tblGetPlantByPlotID(Plant)
		VALUES (NULL)
		RETURN
		END
	RETURN
END
GO
SELECT * FROM dbo.udf_GetPlantByPlotID(N'В-12345')
SELECT * FROM dbo.udf_GetPlantByPlotID(N'В-123425')
GO

-- 3 --
CREATE OR ALTER FUNCTION udf_GetRentByContractID(@contID NVARCHAR(8))
RETURNS MONEY
AS
BEGIN
	DECLARE @totalRent MONEY=0, @rentPerMonth MONEY=0, @term INT=0
	SET @rentPerMonth=(
	SELECT DISTINCT Rent FROM Rents AS r
	INNER JOIN Plots AS p ON r.Type=p.Type
	INNER JOIN Deals AS d ON d.PlotID=p.PlotID
	INNER JOIN Contracts AS c ON @contID=d.ContractID
	)

	SET @term=(SELECT Term From Contracts WHERE ContractID=@contID)

	SET @totalRent=@term*@rentPerMonth

	RETURN @totalRent
END
GO
SELECT dbo.udf_GetRentByContractID(N'Д-033-18') AS 'Total Rent'

--04
CREATE OR ALTER PROC usp_RentByYear(@year INT)
AS
BEGIN
	SELECT SUM(r.Rent) FROM Contracts AS c
	INNER JOIN Deals AS d ON c.ContractID = d.ContractID
	INNER JOIN Plots AS p ON d.PlotID = p.PlotID
	INNER JOIN Rents AS r ON p.Type = r.Type
	WHERE YEAR(c.Date) = @year
END
Go
EXEC usp_RentByYear 2021
Go

--05
CREATE OR ALTER PROC usp_EndOfContract
AS 
BEGIN
	SELECT c.ContractID AS 'Номер на договор', cs.Name AS 'Име на собственик', c.Date AS 'Дата', c.Term AS 'Период' FROM Contracts AS c
		INNER JOIN Deals AS d ON c.ContractID = d.ContractID
		INNER JOIN Plots AS p ON d.PlotID = p.PlotID
		INNER JOIN Clients AS cs ON d.ClientID = cs.ClientID
	WHERE YEAR(c.Date) + c.Term = YEAR(GETDATE())
END
Go
EXEC usp_EndOfContract
Go

--06
CREATE OR ALTER PROC usp_CountFromDateToDate(@start DATE, @end DATE)
AS
BEGIN
	SELECT COUNT(ContractID) FROM Contracts
	WHERE Date > @start AND Date < @end
END
Go
EXEC usp_CountFromDateToDate '08-11-2020', '12-01-2022'
Go

--07
CREATE OR ALTER PROC usp_InformationCurrentDate
AS
BEGIN
	SELECT c.ContractID AS 'Номер на договор', cs.Name AS 'Име на собственик', c.Date AS 'Дата', c.Term AS 'Период', p.Area AS 'Площ' FROM Contracts AS c
		INNER JOIN Deals AS d ON c.ContractID = d.ContractID
		INNER JOIN Plots AS p ON d.PlotID = p.PlotID
		INNER JOIN Clients AS cs ON d.ClientID = cs.ClientID
	WHERE YEAR(c.Date) = YEAR(GETDATE())
END
Go
EXEC usp_InformationCurrentDate
Go

--08
CREATE OR ALTER PROC usp_AreaByPlant
AS
BEGIN
	SELECT SUM(Area) AS 'Total' , c.Plant FROM Contracts AS c
		INNER JOIN Deals AS d ON c.ContractID = d.ContractID
		INNER JOIN Plots AS p ON d.PlotID = p.PlotID
	GROUP BY c.Plant
END
Go
EXEC usp_AreaByPlant
Go





