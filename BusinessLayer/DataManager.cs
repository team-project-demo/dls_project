using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class DataManager
    {
        private IDirectoriesRepository _dirRepos;
        private IMaterialsRepository _matRepos;

        public DataManager(IDirectoriesRepository dirRepos, IMaterialsRepository matRepos)
        {
            _dirRepos = dirRepos;
            _matRepos = matRepos;
        }

        public IDirectoriesRepository DirRepos {
            get { return _dirRepos; }
        }

        public IMaterialsRepository MatRepos
        {
            get { return _matRepos; }
        }
    }
}
