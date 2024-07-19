using WebApp.Entities.Concrete;
using WebApp.Core.Models;
using WebApp.DataAccess.Abstract;
using WebApp.Business.Abstract;

namespace WebApp.Business.Concrete
{
    public class PropertyManager(IPropertyDataAccess propertyDataAccess) : IPropertyService
    {
        private readonly IPropertyDataAccess _propertyDataAccess = propertyDataAccess;

        public GetManyResult<Property> GetAllProperties()
        {
            return _propertyDataAccess.GetAll();
        }

        public GetOneResult<Property> GetPropertyById(string id)
        {
            return _propertyDataAccess.GetById(id);
        }

        public GetOneResult<Property> AddProperty(Property property)
        {
            return _propertyDataAccess.InsertOne(property);
        }

        public GetOneResult<Property> UpdateProperty(Property property)
        {
            return _propertyDataAccess.ReplaceOne(property, property.Id.ToString());
        }

        public GetOneResult<Property> DeleteProperty(string id)
        {
            return _propertyDataAccess.DeleteById(id);
        }

    }
}
