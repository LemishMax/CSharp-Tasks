namespace Task_3
{
    using System.Configuration;
    using System.IO;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using CommandBuilders;
    using FunctionBuilders;
    using FunctionStorages;

    public class IoCInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Where(Component.IsInSameNamespaceAs<Serializer>())
                .WithService.DefaultInterfaces()
                .LifestyleTransient());

            container.Register(
                Component.For<IFunctionStorage>()
                    .ImplementedBy<FunctionStorage>()
                    .UsingFactoryMethod(kernel => new FunctionStorage(kernel
                        .Resolve<Serializer>()
                        .Deserialize(File.ReadAllText(ConfigurationManager.AppSettings["Json"])))));

            container.Register(
                Component.For<IFunctionStorage>()
                    .ImplementedBy<FunctionStorageDecorator>()
                    .UsingFactoryMethod(kernel => new FunctionStorageDecorator(kernel
                        .Resolve<FunctionStorage>())));


            container.Register(Component.For<BaseBuildersOfFunctions>()
                .ImplementedBy<BuildersOfFunctions>());

            container.Register(
                Component.For<BuildersOfCommands>()
                    .ImplementedBy<BuildersOfCommandsForFunctionStorage>()
                    .UsingFactoryMethod(kernel => new BuildersOfCommandsForFunctionStorage(kernel
                        .Resolve<BaseBuildersOfFunctions>().GetFunctions())));
        }
    }
}
