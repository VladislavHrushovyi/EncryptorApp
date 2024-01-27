using Encryptor.Application.Features.Logger;
using Encryptor.Application.Repositories;
using Encryptor.ConsoleApp;
using Encryptor.Infrastructure.Repositories;

List<IAppLogger> _loggers = new() { new ConsoleLogger(), new FileLogger() };
IAppDataRepository dataRepository = new AppDataRepository();

ApplicationMenu appMenu = new ApplicationMenu(dataRepository, _loggers);
appMenu.Start();