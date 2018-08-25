using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Platform.Sql;

namespace Platform.Repository
{
    public class ProductSiteMappingRepository 
    {


        PlatformDBEntities _repository;
        public ProductSiteMappingRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }
        public List<ProductSiteMapping> GetAll()
        {




            List<ProductSiteMapping> productSiteMappingList = new List<ProductSiteMapping>();
            productSiteMappingList = _repository.ProductSiteMappings.ToList<Sql.ProductSiteMapping>();


            return productSiteMappingList;
        }

        public ProductSiteMapping GetById(int productSiteMappingId)
        {
            ProductSiteMapping site = new ProductSiteMapping();

            site = _repository.ProductSiteMappings.FirstOrDefault(x => x.SiteId == productSiteMappingId);



            return site;
        }


        public void Add(ProductSiteMapping productSiteMapping)
        {




            if (productSiteMapping != null)
            {
                _repository.ProductSiteMappings.Add(productSiteMapping);
             //   _repository.SaveChanges();

            }




        }

        public void Update(ProductSiteMapping productSiteMapping)
        {

            if (productSiteMapping != null)
            {
                _repository.Entry<Sql.ProductSiteMapping>(productSiteMapping).State = System.Data.Entity.EntityState.Modified;
           //     _repository.SaveChanges();

            }


        }

        public void Delete(int productSiteMappingId)
        {
            var productSiteMapping = _repository.ProductSiteMappings.Where(x => x.SiteId == productSiteMappingId).FirstOrDefault();
            if (productSiteMapping != null)
                _repository.ProductSiteMappings.Remove(productSiteMapping);

         //   _repository.SaveChanges();

        }

     


    }
}
