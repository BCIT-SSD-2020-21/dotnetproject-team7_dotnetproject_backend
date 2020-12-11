using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace DotNetTeam7API
{
    public class RouteConfig
    {
    
    routes.MapRoute(
    name: "TmdbApi",
    Url: "TmdbApi/{id}/",
    Defaults: new { Controller = "TmdbApi", action = "GetPerson", id = "" },
    Constraints: new { id = @"^[0-9]+$" }
    );

    routes.MapRoute(
    name: "TmdbApiPaging",
    url: "TmdbApi/{peopleName}/{page}",
    defaults: new { controller = "TmdbApi", action = "Index", peopleName = "", page = "" },
    constraints: new { peopleName = @"^[a-zA-Z]+$", page = @"^[0-9]+$" }
    );

    }
}
