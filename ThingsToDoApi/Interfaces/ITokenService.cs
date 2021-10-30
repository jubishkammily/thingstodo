using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoApi.Entities;

namespace ThingsToDoApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}