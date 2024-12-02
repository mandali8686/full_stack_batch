-- 1.      How many products can you find in the Production.Product table?
SELECT COUNT(ProductID)
FROM Production.Product

-- 2.      Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT COUNT(ProductID)
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL

-- 3.      How many Products reside in each SubCategory? Write a query to display the results with the following titles.

-- ProductSubcategoryID CountedProducts

-- -------------------- ---------------

SELECT ProductSubcategoryID, COUNT(ProductID) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID


-- 4.      How many products that do not have a product subcategory.

SELECT COUNT(ProductID)
FROM Production.Product
WHERE ProductSubcategoryID IS NULL

-- 5.      Write a query to list the sum of products quantity in the Production.ProductInventory table.

SELECT SUM(Quantity)
FROM Production.ProductInventory

-- 6.    Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.

--               ProductID    TheSum

--               -----------        ----------


SELECT ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID =40
GROUP BY ProductID
HAVING SUM(Quantity)<100


-- 7.    Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100

--     Shelf      ProductID    TheSum

--     ----------   -----------        -----------

SELECT Shelf, ProductID, SUM(Quantity) AS TheSum
FROM Production.ProductInventory
WHERE LocationID =40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity)<100

-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.

SELECT ProductID, AVG(Quantity)
FROM Production.ProductInventory
WHERE LocationID =10
GROUP BY ProductID

-- 9.    Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

--     ProductID   Shelf      TheAvg

--     ----------- ---------- -----------


SELECT ProductID,Shelf,AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf

-- 10.  Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

--     ProductID   Shelf      TheAvg

--     ----------- ---------- -----------


SELECT ProductID,Shelf,AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID, Shelf

-- 11.  List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.

--     Color                        Class              TheCount          AvgPrice

--     -------------- - -----    -----------            ---------------------

SELECT Color, Class, COUNT(ProductID) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class

-- Joins:

-- 12.   Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.

--     Country                        Province

--     ---------                          ----------------------

SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c LEFT JOIN Person.StateProvince s
ON c.CountryRegionCode = s.CountryRegionCode

-- 13.  Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.

 

--     Country                        Province

--     ---------                          ----------------------

SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c LEFT JOIN Person.StateProvince s
ON c.CountryRegionCode = s.CountryRegionCode
WHERE c.Name IN ('Canada', 'Germany')

--  Using Northwnd Database: (Use aliases for all the Joins)

-- 14.  List all Products that has been sold at least once in last 27 years.
SELECT D.ProductID
FROM [Order Details] D INNER JOIN Orders O
ON D.OrderID = O.OrderID
WHERE O.OrderDate > DATEADD(YEAR, -27, GETDATE());

-- 15.  List top 5 locations (Zip Code) where the products sold most.

SELECT TOP 5 O.ShipPostalCode, SUM(D.Quantity) AS total 
FROM [Order Details] D INNER JOIN Orders O
ON D.OrderID = O.OrderID
GROUP BY O.ShipPostalCode
ORDER BY total DESC
-- 16.  List top 5 locations (Zip Code) where the products sold most in last 27 years.

SELECT TOP 5 O.ShipPostalCode, SUM(D.Quantity) AS total 
FROM [Order Details] D INNER JOIN Orders O
ON D.OrderID = O.OrderID
WHERE O.OrderDate > DATEADD(YEAR, -27, GETDATE())
GROUP BY O.ShipPostalCode
ORDER BY total DESC

-- 17.   List all city names and number of customers in that city.  

SELECT City, COUNT(CustomerID) 
FROM Customers
GROUP BY City

-- 18.  List city names which have more than 2 customers, and number of customers in that city

SELECT City, COUNT(CustomerID) 
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >2

-- 19.  List the names of customers who placed orders after 1/1/98 with order date.
SELECT C.CompanyName, C.ContactName
FROM Orders O INNER JOIN Customers C
ON O.CustomerID = C.CustomerID
WHERE O.OrderDate > '1998-01-01'
-- 20.  List the names of all customers with most recent order dates
SELECT C.CompanyName, C.ContactName, MAX(O.OrderDate)
FROM Orders O INNER JOIN Customers C
ON O.CustomerID = C.CustomerID
GROUP BY C.CompanyName, C.ContactName

-- 21.  Display the names of all customers  along with the  count of products they bought

SELECT C.CompanyName, C.ContactName, SUM(D.Quantity) AS CountProducts
FROM Orders O INNER JOIN Customers C
ON O.CustomerID = C.CustomerID
INNER JOIN [Order Details] D
ON O.OrderID = D.OrderID
GROUP BY C.CompanyName, C.ContactName


-- 22.  Display the customer ids who bought more than 100 Products with count of products.

SELECT C.CustomerID, SUM(D.Quantity) AS CountProducts
FROM Orders O INNER JOIN Customers C
ON O.CustomerID = C.CustomerID
INNER JOIN [Order Details] D
ON O.OrderID = D.OrderID
GROUP BY C.CustomerID
HAVING SUM(D.Quantity) >100

-- 23.  List all of the possible ways that suppliers can ship their products. Display the results as below

--     Supplier Company Name                Shipping Company Name

--     ---------------------------------            ----------------------------------
SELECT SU.CompanyName AS [Supplier Company Name], S.CompanyName AS [Shipping Company Name] 
FROM Suppliers SU CROSS JOIN Shippers S
 
-- 24.  Display the products order each day. Show Order date and Product Name.

SELECT O.OrderDate, P.ProductID, P.ProductName
FROM Products P INNER JOIN [Order Details] OD
ON P.ProductID = OD.ProductID
INNER JOIN Orders O
ON OD.OrderID = O.OrderID
-- 25.  Displays pairs of employees who have the same job title.

SELECT E1.FirstName+' '+E1.LastName, E2.FirstName+' '+E2.LastName
FROM Employees E1 INNER JOIN Employees E2
ON E1.Title = E2.Title

-- 26.  Display all the Managers who have more than 2 employees reporting to them.

SELECT E2.FirstName+' '+E2.LastName AS Manager
FROM Employees E1 INNER JOIN Employees E2
ON E1.ReportsTo = E2.EmployeeID 
GROUP BY E2.FirstName+' '+E2.LastName
HAVING COUNT(E1.EmployeeID)>2

-- 27.  Display the customers and suppliers by city. The results should have the following columns

-- City

-- Name

-- Contact Name,

-- Type (Customer or Supplier)

SELECT 
COALESCE(C.City, S.City) AS City, 
COALESCE(C.CompanyName, S.CompanyName) AS Name, 
COALESCE(C.ContactName, S.ContactName) AS ContactName, 
CASE 
    WHEN C.CompanyName IS NOT NULL THEN 'Customer' 
    WHEN S.CompanyName IS NOT NULL THEN 'Supplier' 
END AS Type 
FROM Customers C FULL OUTER JOIN Suppliers S
ON C.City = S.City;
