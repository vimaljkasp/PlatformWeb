using Platform.DTO;
using Platform.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service
{
    public class ModuleConvertor
    {
        public static ModuleDTO ConvertToModuleDto(Module module)
        {
            ModuleDTO moduleDTO = new ModuleDTO();
            moduleDTO.ModuleId = module.ModuleId;
            moduleDTO.ModuleName = module.ModuleName;
            moduleDTO.IsActive = module.IsActive;
           
            return moduleDTO;

     
    }

        public static void ConvertToModuleEntity(ref Module module, ModuleDTO moduleDTO, bool isUpdate)
        {
            if(isUpdate)
            moduleDTO.ModuleId = module.ModuleId;

            moduleDTO.ModuleName = module.ModuleName;
            moduleDTO.IsActive = module.IsActive;


        }
    }
}
