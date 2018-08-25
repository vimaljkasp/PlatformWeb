
IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[GetDashboardDetails]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
   DROP PROCEDURE [dbo].[GetDashboardDetails]
END
GO

CREATE PROCEDURE [dbo].[GetDashboardDetails] 

AS


--Get Last 10 Orders

SELECT
Top 10
c.CustomerId,
c.Name,
c.MobileNumber,
o.OrderId,
od.ProductOrderDetailId,
ps.ProductMappingId,
p.ProductName,
ISNULL(Od.Quantity,0),
ISNULL(O.OrderTotalPrice,0),
od.OrderStatus,
o.OrderPurchaseDtm
FROM
[ProductOrder] O
inner join [Customer] c on c.customerId=O.OrderCustomerId
inner join [ProductOrderDetail] Od on O.OrderId=Od.OrderId
inner join [ProductSiteMapping] Ps on ps.ProductMappingId=od.ProductMappingId
inner join [Product] P on ps.ProductId=p.ProductId

Order By
o.OrderPurchaseDtm desc


SELECT
Top 10
S.SalesId,
S.SalesDate,
s.Quantity,
s.TotalPrice,
ps.ProductMappingId,
p.ProductName
FROM
[ProductSales] S
inner join [ProductSiteMapping] Ps on ps.ProductMappingId=s.ProductMappingId
inner join [Product] P on ps.ProductId=p.ProductId

Where
S.SalesDate=GETUTCDATE()


SELECT
Top 10
c.CustomerId,
c.Name,
w.WalletBalance,
c.MobileNumber
FROM
[CustomerWallet] W
inner join [Customer] C on w.CustomerId=c.CustomerId

Order By
w.WalletBalance desc


GO