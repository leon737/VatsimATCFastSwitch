using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VatsimConnector.Models;

namespace VatsimConnector.Services
{
    public interface IVatsimService
    {
        Task<ICollection<VatsimController>> GetAllControllers();

        Task<ICollection<VatsimTranceiver>> GetAllTranceivers();

        ICollection<VatsimAtcStation> GetAtcStations(ICollection<VatsimController> controllers, ICollection<VatsimTranceiver> tranceivers);
    }
}
