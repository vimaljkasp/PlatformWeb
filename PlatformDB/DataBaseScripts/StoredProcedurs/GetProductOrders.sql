IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[dbo].[GetProductOrders]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
   DROP PROCEDURE [dbo].[GetProductOrders]
END
GO

CREATE PROCEDURE [dbo].[GetProductOrders] 
AS

SELECT
c.CustomerId,
c.Name,
c.MobileNumber,
o.OrderId,
od.ProductOrderDetailId,
ps.ProductMappingId,
p.ProductName,
ISNULL(Od.Quantity,0),
ISNULL(O.OrderTotalPrice,0),
o.OrderPurchaseDtm,
od.OrderStatus,
o.OrderNumber,
od.OrderAddress,
o.OrderComments,
od.DeliveryExpectedDate,
o.OrderPriority
FROM
[ProductOrder] O
inner join [Customer] c on c.customerId=O.OrderCustomerId
inner join [ProductOrderDetail] Od on O.OrderId=Od.OrderId
inner join [ProductSiteMapping] Ps on ps.ProductMappingId=od.ProductMappingId
inner join [Product] P on ps.ProductId=p.ProductId

Order By
o.OrderPurchaseDtm desc


GO