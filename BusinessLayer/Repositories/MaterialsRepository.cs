using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataLayer;

namespace BusinessLayer.Repositories
{
    public class MaterialsRepository : IMaterialsRepository
    {
        private EFDBContext _context;

        public MaterialsRepository(EFDBContext context)
        {
            _context = context;
        }

        public void DeleteMaterial(Material material)
        {
            _context.Materials.Remove(material);
            _context.SaveChanges();
        }

        public IEnumerable<Material> GetAllMaterials(bool includeDirectory = false)
        {
            if (includeDirectory)
                return _context.Materials.Include(x => x.Directory).AsNoTracking().ToList();
            else
                return _context.Materials.ToList();
        }

        public Material GetMaterialById(int materialId, bool includeDirectory = false)
        {
            if (includeDirectory)
                return _context.Materials.Include(x => x.Directory).AsNoTracking()
                    .Where(x => x.Id == materialId).FirstOrDefault();
            else
                return _context.Materials.FirstOrDefault(x => x.Id == materialId);
        }

        public IEnumerable<Material> GetMaterialsByDirectory(int directoryId, bool includeDirectory = false)
        {
            if (includeDirectory)
                return _context.Materials.Include(x => x.Directory).AsNoTracking()
                    .Where(x => x.DirectoryId == directoryId).ToList();
            else
                return _context.Materials.Where(x => x.DirectoryId == directoryId).ToList();
        }

        public void SaveMaterial(Material material)
        {
            if (material.Id == 0)
                _context.Materials.Add(material);
            else
                _context.Entry(material).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
