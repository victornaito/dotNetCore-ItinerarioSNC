using System;
using System.Collections.Generic;
using System.Text;

namespace ItinerarioSNC.Infra.CrossCutting.Interfaces
{
    public interface ITokenJWTService
    {
        string GerarToken();
    }
}
