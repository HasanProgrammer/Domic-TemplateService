using Domic.Core.Infrastructure.Extensions;
using Domic.Core.WebAPI.Extensions;
using Domic.Infrastructure.Extensions.C;
using Domic.Infrastructure.Extensions.Q;
using Domic.WebAPI.Frameworks.Extensions;

using C_SQLContext = Domic.Persistence.Contexts.C.SQLContext;
using Q_SQLContext = Domic.Persistence.Contexts.Q.SQLContext;

/*-------------------------------------------------------------------*/

WebApplicationBuilder builder = WebApplication.CreateBuilder();

#region Configs

builder.WebHost.ConfigureAppConfiguration((context, builder) => builder.AddJsonFiles(context.HostingEnvironment));

#endregion

/*-------------------------------------------------------------------*/

#region ServiceContainer

builder.RegisterHelpers();
builder.RegisterELK();
builder.RegisterGrpcServer();
builder.RegisterEntityFrameworkCoreCommand<C_SQLContext, string>();
builder.RegisterEntityFrameworkCoreQuery<Q_SQLContext>();
builder.RegisterCommandQueryUseCases();
builder.RegisterCommandRepositories();
builder.RegisterQueryRepositories();
builder.RegisterMessageBroker();
builder.RegisterRedisCaching();
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