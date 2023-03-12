using DeveloperChallenge.Models.Dtos.OutputDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperChallenge.Services.Interfaces
{
    public interface IShipperService
    {
        Tuple<int, string, object> GetShippers();
        Tuple<int, string, object> GetShipperDetailById(int id);
    }
}
