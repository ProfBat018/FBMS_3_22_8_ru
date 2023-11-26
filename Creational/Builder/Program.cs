using Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



MiddlewareBuilder builder = new();

builder.Use<LoggerMiddleware>();
builder.Use<StaticFilesMiddleware>();
builder.Use<ImageMiddleware>();


var handler = builder.Build();

handler.Invoke("First");