using System.Collections.Generic;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class MockMaterialContext : IMaterialRepo
    {
        public void CreateMaterial(Material cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteMaterial(Material cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            throw new System.NotImplementedException();
        }

        public Material GetMaterialById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateMaterial(Material cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}