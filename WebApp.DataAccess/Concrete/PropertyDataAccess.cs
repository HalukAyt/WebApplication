using WebApp.Entities.Concrete;
using WebApp.Core.Settings;
using WebApp.DataAccess.Abstract;
using WebApp.DataAccess.Repository;
using Microsoft.Extensions.Options;

namespace WebApp.DataAccess.Concrete
{
    public class PropertyDataAccess(IOptions<MongoSettings> settings) : MongoRepositoryBase<Property>(settings), IPropertyDataAccess
    {
    }
}
