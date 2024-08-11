// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Tryphon.Infra;

Console.WriteLine("Hello, World!");
ServiceCollection services = new ServiceCollection();
services.AddPersistence();
var serviceProvider = services.BuildServiceProvider();

var testeContext = serviceProvider.GetService<TesteContext>();

//testeContext.Set<Processo>()