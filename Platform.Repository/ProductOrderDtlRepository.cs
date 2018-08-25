using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Platform.Sql;

namespace Platform.Repository
{
    public class ProductOrderDtlRepository 
    {

        PlatformDBEntities _repository;
        public ProductOrderDtlRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }
        public List<ProductOrderDetail> GetAll()
        {

            List<ProductOrderDetail> productOrderDetailList = new List<ProductOrderDetail>();
            productOrderDetailList = _repository.ProductOrderDetails.ToList<Sql.ProductOrderDetail>();


            return productOrderDetailList;
        }

        public ProductOrderDetail GetById(int productOrderDetailId)
        {
            ProductOrderDetail productOrderDetail = new ProductOrderDetail();

            productOrderDetail = _repository.ProductOrderDetails.FirstOrDefault(x => x.ProductOrderDetailId == productOrderDetailId);



            return productOrderDetail;
        }


        public void Add(ProductOrderDetail productOrderDetail)
        {

            if (productOrderDetail != null)
            {
                _repository.ProductOrderDetails.Add(productOrderDetail);
           //     _repository.SaveChanges();

            }




        }

        public void Update(ProductOrderDetail productOrderDetail)
        {

            if (productOrderDetail != null)
            {
                _repository.Entry<Sql.ProductOrderDetail>(productOrderDetail).State = System.Data.Entity.EntityState.Modified;
           //     _repository.SaveChanges();

            }


        }

        public void Delete(int productOrderDetailId)
        {
            var productOrderDetail = _repository.ProductOrderDetails.Where(x => x.ProductOrderDetailId == productOrderDetailId).FirstOrDefault();
            if (productOrderDetail != null)
                _repository.ProductOrderDetails.Remove(productOrderDetail);

         //   _repository.SaveChanges();

        }

        


    }
}
