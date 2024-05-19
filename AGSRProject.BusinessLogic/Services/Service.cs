using AGSRProject.Common.Interfaces.Services;
using AGSRProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGSRProject.BusinessLogic.Services
{
    public class Service<T> : IService<T> where T : Entity
    {

    }
}
