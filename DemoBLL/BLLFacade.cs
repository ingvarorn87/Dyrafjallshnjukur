using BLL;
using BLL.Services;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;


namespace BLL
{
    class BLLFacade
    {
        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }
    }
}
