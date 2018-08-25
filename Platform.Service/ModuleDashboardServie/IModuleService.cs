using Platform.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public interface IModuleService
    {
         List<ModuleDTO> GetAllModules();

        ModuleDTO GetModuleById(int moduleId);

        void AddModule(ModuleDTO customerDto);

        void UpdateModule(ModuleDTO customerDto);

        void DeleteModule(int moduleId);






    }
}
