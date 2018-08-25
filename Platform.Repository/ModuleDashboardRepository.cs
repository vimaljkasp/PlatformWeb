using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Platform.Sql;

namespace Platform.Repository
{
    public class ModuleDashboardRepository 
    {

        PlatformDBEntities _repository;
        public ModuleDashboardRepository(PlatformDBEntities repository)
        {
            _repository = repository;
        }
        public List<Module> GetAll()
        {

            List<Module> moduleList = new List<Module>();
            moduleList = _repository.Modules.ToList<Sql.Module>();


            return moduleList;
        }

        public Module GetById(int productSiteMappingId)
        {
            Module module = new Module();

            module = _repository.Modules.FirstOrDefault(x => x.ModuleId == productSiteMappingId);



            return module;
        }


        public void Add(Module module)
        {




            if (module != null)
            {
                _repository.Modules.Add(module);
             //   _repository.SaveChanges();

            }




        }

        public void Update(Module module)
        {

            if (module != null)
            {
                _repository.Entry<Sql.Module>(module).State = System.Data.Entity.EntityState.Modified;
//_repository.SaveChanges();

            }


        }

        public void Delete(int productSiteMappingId)
        {
            var module = _repository.Modules.Where(x => x.ModuleId == productSiteMappingId).FirstOrDefault();
            if (module != null)
                _repository.Modules.Remove(module);

         //   _repository.SaveChanges();

        }

       


    }
}
