using eManager.Web.Controllers;
using eManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace eManager.Web.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {


        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            if (controllerName.ToLower().StartsWith("proteintracker"))
            {
                var repository = new ProteinRepository();
                var service = new ProteinTrackingService(repository);
                var controller = new ProteinTrackerController(service);
                return controller;
            }

            var defaultFactory = new DefaultControllerFactory();
            return defaultFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}