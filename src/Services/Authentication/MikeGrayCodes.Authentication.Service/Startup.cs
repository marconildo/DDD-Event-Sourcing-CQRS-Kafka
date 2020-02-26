using Autofac;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MikeGrayCodes.Authentication.Domain.Entities.ApplicationUser;
using MikeGrayCodes.Authentication.Infrastructure;
using MikeGrayCodes.BuildingBlocks.Application;
using MikeGrayCodes.BuildingBlocks.Application.Behaviors;
using MikeGrayCodes.BuildingBlocks.Domain;
using MikeGrayCodes.BuildingBlocks.Infrastructure;
using MikeGrayCodes.BuildingBlocks.Infrastructure.DomainEventsDispatching;
using MikeGrayCodes.BuildingBlocks.Infrastructure.Outbox;
using MikeGrayCodes.BuildingBlocks.Persistence.EntityFramework;
using MikeGrayCodes.BuildingBlocks.Persistence.EntityFramework.Outbox;
using MikeGrayCodes.BuildingBlocks.Persistence.EntityFrameWork;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MikeGrayCodes.Authentication.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IRequestExecutor, RequestExecutor>();

            var entryAssembly = Assembly.GetEntryAssembly();
            var referencedAssemblies = entryAssembly.GetReferencedAssemblies().Select(Assembly.Load);
            var assemblies = new List<Assembly> { entryAssembly }.Concat(referencedAssemblies);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkTransactionBehavior<,>));

            services.AddMediatR(assemblies.ToArray());

            services.AddDbContext<AuthenticationDbContext>(options => options.UseInMemoryDatabase(databaseName: "Auth"));

            services.AddScoped<BaseDbContext<AuthenticationDbContext>, AuthenticationDbContext>();

            services.AddScoped<DbContext, AuthenticationDbContext>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //configure auto fac here
            builder.RegisterType<DomainEventsDispatcher>()
                .As<IDomainEventsDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DomainEventsAccessor<AuthenticationDbContext>>()
                .As<IDomainEventsAccessor>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork<AuthenticationDbContext>>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<OutboxAccessor<AuthenticationDbContext>>()
                .As<IOutbox>()
                .InstancePerLifetimeScope();

            builder.RegisterType<InternalCommandRepository<AuthenticationDbContext>>()
                .As<IInternalCommandRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserUniquenessChecker>()
                .As<IApplicationUserUniquenessChecker>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserRepository>()
                .As<IApplicationUserRepository>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<CommandsScheduler>()
            //    .As<ICommandsScheduler>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterGenericDecorator(
            //    typeof(UnitOfWorkCommandHandlerDecorator<>),
            //    typeof(ICommandHandler<>));

            //builder.RegisterGenericDecorator(
            //    typeof(ValidationCommandHandlerDecorator<>),
            //    typeof(ICommandHandler<>));

            //builder.RegisterGenericDecorator(
            //    typeof(LoggingCommandHandlerDecorator<>),
            //    typeof(ICommandHandler<>));

            //builder.RegisterGenericDecorator(
            //    typeof(DomainEventsDispatcherNotificationHandlerDecorator<>),
            //    typeof(INotificationHandler<>));

            //builder.RegisterAssemblyTypes(System.Configuration.Assemblies.Application)
            //    .AsClosedTypesOf(typeof(IDomainEventNotification<>))
            //    .InstancePerDependency();
        }

        //...


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
