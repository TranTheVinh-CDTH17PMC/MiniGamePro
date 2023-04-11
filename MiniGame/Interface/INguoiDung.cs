using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGame.Interface
{
    public interface INguoiDung : IGenericRepository<NguoiDung>
    {
        int GetIDByName(string name);
    }
}
