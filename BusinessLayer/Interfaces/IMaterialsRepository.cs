using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IMaterialsRepository
    {
        IEnumerable<Material> GetAllMaterials();
        IEnumerable<Material> GetMaterialsByDirectory(int directoryId);
        Material GetMaterialById(int materialId);
        void SaveMaterial(Material material);
        void DeleteMaterial(Material material);
    }
}
