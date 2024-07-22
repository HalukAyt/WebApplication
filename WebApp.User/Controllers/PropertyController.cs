using Microsoft.AspNetCore.Mvc;
using WebApp.Business.Abstract;
using WebApp.Entities.Concrete;

public class PropertyController : Controller
{
    private readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }

    public IActionResult Index()
    {
        var properties = _propertyService.GetAllProperties();
        return View(properties.Result);
    }

    public IActionResult Details(string id)
    {
        var property = _propertyService.GetPropertyById(id);
        if (property.Entity == null)
        {
            return NotFound();
        }
        return View(property.Entity);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Property property)
    {
        if (ModelState.IsValid)
        {
            _propertyService.AddProperty(property);
            return RedirectToAction(nameof(Index));
        }
        return View(property);
    }

    [HttpGet]
    public IActionResult Edit(string id)
    {
        var property = _propertyService.GetPropertyById(id);
        if (property.Entity == null)
        {
            return NotFound();
        }
        return View(property.Entity);
    }

    [HttpPost]
    public IActionResult Edit(Property property)
    {
        if (ModelState.IsValid)
        {
            _propertyService.UpdateProperty(property);
            return RedirectToAction(nameof(Index));
        }
        return View(property);
    }

    [HttpGet]
    public IActionResult Delete(string id)
    {
        var property = _propertyService.GetPropertyById(id);
        if (property.Entity == null)
        {
            return NotFound();
        }
        return View(property.Entity);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(string id)
    {
        _propertyService.DeleteProperty(id);
        return RedirectToAction(nameof(Index));
    }
}
