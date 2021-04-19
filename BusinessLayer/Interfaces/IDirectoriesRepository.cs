using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IDirectoriesRepository
    {
        IEnumerable<Directory> GetAllDirectories(bool includeMaterials = false);
        Directory GetDirectoryById(int directoryId, bool includeMaterials = false);
        void SaveDirectory(Directory dir);
        void DeleteDirectory(Directory dir);
    }
}
