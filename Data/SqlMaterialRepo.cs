using System;
using System.Collections.Generic;
using System.Linq;
using IIT.Clubs.Models;

namespace IIT.Clubs.Data
{
    public class SqlMaterialRepo : IMaterialRepo
    {
        private readonly IITContext _context;

        public SqlMaterialRepo(IITContext context)
        {
            _context = context;
        }

        public void CreateMaterial(Material cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Materials.Add(cmd);
        }

        public void DeleteMaterial(Material cmd)
        {
             if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Materials.Remove(cmd);
        }

        public IEnumerable<Material> GetAllMaterials()
        {
            return _context.Materials.ToList();
        }

        public Material GetMaterialById(int id)
        {
            return _context.Materials.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMaterial(Material cmd)
        {
            //Nothing
        }
    }
}