using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Rails.Services
{
    public interface ISectorService
    {

        bool Connect(int fromId, int toId);

    }

}
