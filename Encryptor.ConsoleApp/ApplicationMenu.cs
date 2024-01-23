using Encryptor.Application.Features.Logger;
using Encryptor.Application.Repositories;

namespace Encryptor.ConsoleApp;

public class ApplicationMenu(IAppDataRepository dataRepository, List<IAppLogger> loggers)
{
    public void Start()
    {
        bool isExit = false;
        while (!isExit)
        {
            ShowNavigation();
            switch (Console.ReadLine())
            {
                case "1":
                    var encryptionScenario = new EncryptionScenario(dataRepository, loggers);
                    encryptionScenario.StartScenario();
                    break;
                case "2":
                    var informationScenario = new InformationScenario(dataRepository, loggers);
                    informationScenario.StartScenario();
                    break;
                case "3":
                    isExit = true;
                    dataRepository.SaveChanges();
                    Console.WriteLine("EXIT");
                    break;
                default:
                    isExit = true;
                    dataRepository.SaveChanges();
                    Console.WriteLine("Incorrect choose. Application has been closed");
                    break;
            }   
        }
    }

    private void ShowNavigation()
    {
        Console.Clear();
        Console.WriteLine("**********START-MENU**********");
        Console.WriteLine("1. Do Encryption");
        Console.WriteLine("2. Log information");
        Console.WriteLine("3. Exit");
        Console.WriteLine("***********END-MENU***********");
    }
}