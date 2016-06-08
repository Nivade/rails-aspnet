using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Rails.Models.Binders
{
    public class TrackViewBinder : DefaultModelBinder
    {

        /// <summary>
        /// Binds the specified property by using the specified controller context and binding context and the specified property descriptor.
        /// </summary>
        /// <param name="controllerContext">The context within which the controller operates. The context information includes the controller, HTTP content, request context, and route data.</param><param name="bindingContext">The context within which the model is bound. The context includes information such as the model object, model name, model type, property filter, and value provider.</param><param name="propertyDescriptor">Describes a property to be bound. The descriptor provides information such as the component type, property type, and property value. It also provides methods to get or set the property value.</param>
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            if (propertyDescriptor.Name == "Accessible")
            {
                int accessible = Convert.ToInt32(controllerContext.HttpContext.Request.Form["Accessible"].Contains("true"));
                propertyDescriptor.SetValue(bindingContext.Model, accessible);
                return;
            }

            if (propertyDescriptor.Name == "InOutTrack")
            {
                int inOutTrack = Convert.ToInt32(controllerContext.HttpContext.Request.Form["InOutTrack"].Contains("true"));
                propertyDescriptor.SetValue(bindingContext.Model, inOutTrack);
                return;
            }

            /*if (propertyDescriptor.Name == "DepotId")
            {
                ApplicationDbContext db = new ApplicationDbContext();
                string depot = controllerContext.HttpContext.Request.Form["Depot"];
                propertyDescriptor.SetValue(bindingContext.Model, db.Depots.First(x => x.Name == depot).Id);
                return;
            }*/
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }

    }
}
