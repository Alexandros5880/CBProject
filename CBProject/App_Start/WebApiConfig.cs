﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace CBProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Camel notation
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;


            // Ignore reference looping
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    }
}
