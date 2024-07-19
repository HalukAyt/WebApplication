using WebApp.Entities.Concrete;
using WebApp.Core.Models;

namespace WebApp.Business.Abstract
{
    public interface IPropertyService
    {
        GetManyResult<Property> GetAllProperties();
        GetOneResult<Property> GetPropertyById(string id);
        GetOneResult<Property> AddProperty(Property property);
        GetOneResult<Property> UpdateProperty(Property property);
        GetOneResult<Property> DeleteProperty(string id);
    }
}
