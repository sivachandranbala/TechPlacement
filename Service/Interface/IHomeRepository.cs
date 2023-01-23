using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPlacement.Model;

namespace TechPlacement.Service.Interface
{
    public interface IHomeRepository
    {
        List<Functions> GetFunctionsList(int UserId, int FunctionTypeId);
    }
}
