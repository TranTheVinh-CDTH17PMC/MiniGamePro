using MiniGame.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniGame.Repository
{
    public class NguoiDungRepository : GenericRepository<NguoiDung>, INguoiDung
    {
        public int GetIDByName(string name)
        {
            var tenkh = _db.NguoiDungs.SingleOrDefault(x => x.Ten == name);
            return tenkh.Id;
        }
    }
}