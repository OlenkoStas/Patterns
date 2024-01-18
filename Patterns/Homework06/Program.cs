using Homework06;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Starting Homework #06");
Console.WriteLine("Author: {0}", "TODO: Your Name or Nickname here");

// test regular constructor behavior
new Car("Mercedes", "SLS AMG", new DieselEngine(), 2022).start();

Console.WriteLine("Initializing context");

var serviceProvider = new ServiceCollection()
    .AddLogging()
    .AddTransient<DieselEngine>()
    .AddTransient<CarFactory>()
    .BuildServiceProvider(new ServiceProviderOptions { ValidateOnBuild = true, ValidateScopes = true });

// TODO: add missing registrations

Console.WriteLine("Context initialized");

var dieselEngine = serviceProvider.GetService<DieselEngine>();
dieselEngine.Hp = 333;

// test DI works
dieselEngine.StartEngine();

CarFactory carFactory = serviceProvider.GetService<CarFactory>();

carFactory.Get("TODO: your diesel car option", "TODO", 2020, 170).start();
carFactory.Get("TODO: your electric car option", "TODO", 2015, 259).start();