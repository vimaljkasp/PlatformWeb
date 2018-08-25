using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Platform.DTO;
using Platform.Sql;


namespace Platform.Repository
{
    public class DashboardRepository
    {
        PlatformDBEntities _repository;
        public DashboardRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }

        public List<ProductOrders> GetProductOrders()
        {
            List<ProductOrders> productOrders = new List<ProductOrders>();

            // Create a SQL command to execute the sproc 
            var cmd = _repository.Database.Connection.CreateCommand();
            cmd.CommandText = "[dbo].[GetProductOrders]";

            try
            {
                _repository.Database.Connection.Open();

                // Run the sproc  
                var reader = cmd.ExecuteReader();
                while (reader.Read())

                    productOrders.Add(
                        new ProductOrders()
                        {
                            CustomerId = reader.GetInt32(0),
                            CustomerName = reader.GetString(1),
                            CustomerMobileNumber = reader.GetString(2),
                            OrderId = reader.GetInt32(3),
                            ProductOrderDetailId = reader.GetInt32(4),
                            ProductMappingId = reader.GetInt32(5),
                            ProductName = reader.GetString(6),
                            Quantity = reader.GetDecimal(7),
                            Amount = reader.GetDecimal(8),
                            OrderDate = reader.GetDateTime(9),
                            OrderStatus = ((OrderStatus)reader.GetInt32(10)).ToString(),
                            OrderNumber = reader.GetString(11),
                            OrderAddress = DbDataReaderExtension.SafeGetString(reader, 12),//GetString(12),
                            OrderComments = DbDataReaderExtension.SafeGetString(reader, 13),
                            ExpectedDeliveryDate = reader.GetDateTime(14),
                            OrderPriority= DbDataReaderExtension.SafeGetString(reader, 15)

                        });

            }

            finally
            {
                _repository.Database.Connection.Close();
            }

            return productOrders;

        }

        public DashboardDTO GetDashBoardDetails(DateTime salesDate)
        {
            DashboardDTO dashboardDTO = new DashboardDTO()
            {
                productOrderList = new List<ProductOrders>(),
                productSalesList = new List<ProductSales>(),
                customerBalanceList = new List<CustomerBalance>()
            };

            // Create a SQL command to execute the sproc 
            var cmd = _repository.Database.Connection.CreateCommand();
            cmd.CommandText = "[dbo].[GetDashBoardDetails]";

            try
            {
                _repository.Database.Connection.Open();

                // Run the sproc  
                var reader = cmd.ExecuteReader();
                while (reader.Read())

                    dashboardDTO.productOrderList.Add(
                        new ProductOrders()
                        {
                            CustomerId = reader.GetInt32(0),
                            CustomerName = reader.GetString(1),
                            CustomerMobileNumber = reader.GetString(2),
                            OrderId = reader.GetInt32(3),
                            ProductOrderDetailId = reader.GetInt32(4),
                            ProductMappingId = reader.GetInt32(5),
                            ProductName = reader.GetString(6),
                            Quantity = reader.GetDecimal(7),
                            Amount = reader.GetDecimal(8),
                            OrderStatus = ((OrderStatus)reader.GetInt32(9)).ToString(),

                            OrderDate  = reader.GetDateTime(10),

                        });



                reader.NextResult();
                while (reader.Read())
                {
                    dashboardDTO.productSalesList.Add(
                        new ProductSales()
                        {
                            SalesId = reader.GetInt32(0),
                            SalesDate = reader.GetDateTime(1),
                            SaleQuantity = reader.GetDecimal(2),
                            SalesAmount = reader.GetDecimal(3),
                            ProductMappingId = reader.GetInt32(4),
                            ProductName = reader.GetString(5)
                        });
                }
                reader.NextResult();
                while (reader.Read())
                {
                    dashboardDTO.customerBalanceList.Add(
                        new CustomerBalance()
                        {
                            CustomerId = reader.GetInt32(0),
                            CustomerName = reader.GetString(1),
                            PendingAmount = reader.GetDecimal(2),
                            MobileNumber = reader.GetString(3),
                        });
                }

            }

            finally
            {
                _repository.Database.Connection.Close();
            }

            return dashboardDTO;
        }


        public Int32 NextNumberGenerator(string enitityCode)
        {
            int nextNumber = 0;

            // Create a SQL command to execute the sproc 
            var cmd = _repository.Database.Connection.CreateCommand();
            cmd.CommandText = "[dbo].[GetNextEntityNumber]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@EntityName", SqlDbType.NVarChar, 50));
            cmd.Parameters.Add(new SqlParameter("@NextNumber", SqlDbType.Int, 4));
            cmd.Parameters["@NextNumber"].Direction = ParameterDirection.Output;
            cmd.Parameters["@NextNumber"].Value = nextNumber;
            cmd.Parameters["@EntityName"].Value = enitityCode;
            try
            {
                _repository.Database.Connection.Open();

                // Run the sproc  
                var reader = cmd.ExecuteReader();
                while (reader.Read())

                { }
                nextNumber = (int)cmd.Parameters[1].Value;
            }

            finally
            {
                _repository.Database.Connection.Close();
            }

            return nextNumber;
        }


    }

    public static class DbDataReaderExtension
    {
        public static string SafeGetString(this DbDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }


    }
}
