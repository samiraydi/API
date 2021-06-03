using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public interface IMaterialRepo
    {
        bool SaveChanges();


        IEnumerable<Material> GetAllMaterials();
        Material GetMaterialById(int id);
        void CreateMaterial(Material cmd);
        void UpdateMaterial(Material cmd);
        void DeleteMaterial(Material cmd);
    }
}