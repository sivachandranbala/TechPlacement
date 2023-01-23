using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechPlacement.Model;

namespace TechPlacement.Service.Interface
{
    public interface IUserRepository
    {
        UserInfo GetUserDetails(UserInfo userInfo);

        int CollegeRegister(CollegeMasterModel collegeModel);
        int CompanyRegister(CompanyMasterModel companyModel);

    }
}
