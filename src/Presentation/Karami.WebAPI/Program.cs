using Karami.Core.Common.ClassConsts;
using Karami.Core.Infrastructure.Extensions;
using Karami.Core.WebAPI.Extensions;
using Karami.Infrastructure.Extensions.C;
using Karami.Infrastructure.Extensions.Q;
using Karami.WebAPI.Frameworks.Extensions;

using C_SQLContext = Karami.Persistence.Contexts.C.SQLContext;
using Q_SQLContext = Karami.Persistence.Contexts.Q.SQLContext;

/*-------------------------------------------------------------------*/

WebApplicationBuilder builder = WebApplication.CreateBuilder();

#region Configs

builder.WebHost.ConfigureAppConfiguration((context, builder) => builder.AddJsonFiles(context.HostingEnvironment));

#endregion

/*-------------------------------------------------------------------*/

#region Service Container

builder.RegisterHelpers();
builder.RegisterGrpcServer();
builder.RegisterCommandSqlServer<C_SQLContext>();
builder.RegisterQuerySqlServer<Q_SQLContext>();
builder.RegisterCommandQueryUseCases();
builder.RegisterCommandRepositories();
builder.RegisterQueryRepositories();
builder.RegisterMessageBroker();
builder.RegisterCaching();
builder.RegisterEventsPublisher();
builder.RegisterEventsSubscriber();
builder.RegisterServices();

builder.Services.AddMvc();

#endregion

/*-------------------------------------------------------------------*/

WebApplication application = builder.Build();

/*-------------------------------------------------------------------*/

//Primary processing

application.Services.AutoMigration<C_SQLContext>(context => context.Seed());
application.Services.AutoMigration<Q_SQLContext>(context => context.Seed());

/*-------------------------------------------------------------------*/

#region Middleware

if (application.Environment.IsProduction())
{
    application.UseHsts();
    application.UseHttpsRedirection();
}

application.UseRouting();

application.UseEndpoints(endpoints => {

    endpoints.HealthCheck(application.Services);
    
    #region GRPC's Services

    #endregion

});

#endregion

/*-------------------------------------------------------------------*/

//HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

application.Run();

/*-------------------------------------------------------------------*/

//For Integration Test

public partial class Program {}