using System.CommandLine;
using ApiClient.BLL;
using ApiClient.Infrastructure;
using ApiClient.Presentation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.ApiClient.json")
    .Build();

var services = new ServiceCollection();

services.AddBusinessLogicLayer()
    .AddInfrastructure(configuration["ApiBaseUrl"]!)
    .AddPresentationLayer();

var serviceProvider = services.BuildServiceProvider();

var rootCommand = new RootCommand("Awesome Files Client Utility");

var commandHandler = serviceProvider.GetRequiredService<CommandHandler>();

rootCommand.Subcommands.Add(commandHandler.CreateListCommand());
rootCommand.Subcommands.Add(commandHandler.CreateArchiveCommand());
rootCommand.Subcommands.Add(commandHandler.CreateStatusCommand());
rootCommand.Subcommands.Add(commandHandler.CreateDownloadCommand(configuration["DownloadPath"]!));
rootCommand.Subcommands.Add(commandHandler.CreateAutoArchiveCommand(configuration["DownloadPath"]!));

return rootCommand.Parse(args).Invoke();