-- 1.      List all cities that have both Employees and Customers.

SELECT DISTINCT E.City
FROM Employees E INNER JOIN Customers C
ON E.City = C.City 
 
-- 2.      List all cities that have Customers but no Employee.

-- a.      Use sub-query
SELECT DISTINCT City
FROM Customers
WHERE City NOT IN
    (SELECT City FROM Employees) 

-- b.      Do not use sub-query
SELECT DISTINCT C.City
FROM Employees E RIGHT JOIN Customers C
ON E.City = C.City 
WHERE E.City IS NULL

-- 3.      List all products and their total order quantities throughout all orders.

SELECT P.ProductName, SUM(D.Quantity) 
FROM Products P LEFT JOIN [Order Details] D
ON P.ProductID = D.ProductID
GROUP BY P.ProductName

-- 4.      List all Customer Cities and total products ordered by that city.

SELECT City, SUM(Quantity) 
FROM Customers C
INNER JOIN Orders O 
ON C.CustomerID = O.CustomerID
INNER JOIN [Order Details] D
ON O.OrderID = D.OrderID
GROUP BY City

-- 5.      List all Customer Cities that have at least two customers.

SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) >2

-- 6.      List all Customer Cities that have ordered at least two different kinds of products.

SELECT C.City
FROM Customers C INNER JOIN [Orders] O
ON C.CustomerID = O.CustomerID
INNER JOIN [Order Details] D
ON O.OrderID=D.OrderID
GROUP BY C.City
HAVING COUNT(DISTINCT D.ProductID) >2
-- 7.      List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT DISTINCT C.CompanyName
FROM Customers C INNER JOIN [Orders] O
ON C.CustomerID = O.CustomerID
WHERE C.City != O.ShipCity
-- 8.      List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH PopularProduct AS(
    SELECT D.ProductID, P.ProductName, SUM(D.Quantity) AS TotalQuantity, AVG(D.UnitPrice) AS AvgPrice
    FROM [Order Details] D INNER JOIN Products P
    ON D.ProductID = P.ProductID
    GROUP BY D.ProductID, P.ProductName
),
TopFive AS(
    SELECT TOP 5 ProductID,[ProductName], TotalQuantity, AvgPrice
    FROM PopularProduct
    ORDER BY TotalQuantity DESC
),
OrderCity AS(
    SELECT D.ProductID, C.City, SUM(d.Quantity) AS TotalQuantity
    FROM [Order Details] D INNER JOIN Orders O
    ON D.OrderID = O.OrderID
    INNER JOIN Customers C
    ON O.CustomerID=C.CustomerID
    GROUP BY D.ProductID, C.City
),
MaxCityQuantity AS (
    SELECT OC.ProductID, OC.City, OC.TotalQuantity,
           RANK() OVER (PARTITION BY OC.ProductID ORDER BY OC.TotalQuantity DESC) AS Rank
    FROM OrderCity OC
)
SELECT TF.ProductName, TF.AvgPrice, MCQ.City, MCQ.TotalQuantity AS MaxQuantityInCity
FROM TopFive TF
INNER JOIN MaxCityQuantity MCQ
    ON TF.ProductID = MCQ.ProductID
WHERE MCQ.Rank = 1; 
-- 9.      List all cities that have never ordered something but we have employees there.

-- a.      Use sub-query

SELECT City 
FROM Employees
WHERE City NOT IN (
    SELECT City FROM Customers
    WHERE CustomerID IN(
        SELECT CustomerID FROM Orders
    )
)
-- b.      Do not use sub-query

SELECT E.City
FROM Employees E LEFT JOIN Customers C
ON E.City = C.City
LEFT JOIN Orders O
ON C.CustomerID = O.CustomerID
WHERE O.CustomerID IS NULL

-- 10.  List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

WITH MOE AS(
    SELECT TOP 1 E.City, COUNT(O.OrderID) AS TotalOrders 
    FROM Orders O INNER JOIN Employees E
    ON O.EmployeeID=E.EmployeeID
    GROUP BY E.City
    ORDER BY COUNT(O.OrderID) DESC
),
MOP AS(
    SELECT TOP 1 C.City AS City, SUM(D.Quantity) AS TotalQuantity
    FROM Orders O
    INNER JOIN [Order Details] D
    ON O.OrderID = D.OrderID
    INNER JOIN Customers C
    ON O.CustomerID = C.CustomerID
    GROUP BY C.City
    ORDER BY TotalQuantity DESC
)
SELECT E.City
FROM MOE E
INNER JOIN MOP P
ON E.City = P.City;

-- 11. How do you remove the duplicates record of a table?
WITH CTE AS (
    SELECT 
        *,
        ROW_NUMBER() OVER (PARTITION BY DuplicatedColumns ORDER BY (SELECT NULL)) AS RowNum
    FROM Table
)
DELETE FROM CTE
WHERE RowNum > 1;
