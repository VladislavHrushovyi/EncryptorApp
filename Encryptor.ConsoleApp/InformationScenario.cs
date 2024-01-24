using Encryptor.Application.Features.Logger;
using Encryptor.Application.Repositories;

namespace Encryptor.ConsoleApp;

public class InformationScenario(IAppDataRepository dataRepository, List<IAppLogger> loggers)
{
    public void StartScenario()
    {
        bool isBack = false;
        while (!isBack)
        {
            ShowNavigation();
            switch (Console.ReadLine())
            {
                case "1":
                    DisplayInformationOfAllMessages();
                    break;
                case "2":
                    DisplayOfAmountUsageOfCiphers();
                    break;
                case "3":
                    DisplayOfAmountUsageMessages();
                    break;
                case "4":
                    isBack = true;
                    break;
                default:
                    isBack = true;
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    private void DisplayOfAmountUsageMessages()
    {
        foreach (var methodUsage in dataRepository.GetFullInfo())
        {
            foreach (var historyItem in methodUsage.Value.History)
            {
                Console.WriteLine($"Message {historyItem.OriginalMessage} was encrypted via {methodUsage.Value.MethodName} {historyItem.AmountEncrypted} times");
            }
        }
    }

    private void DisplayOfAmountUsageOfCiphers()
    {
        var data = dataRepository.GetFullInfo();
        foreach (var methodUsage in data)
        {
            Console.WriteLine($"{methodUsage.Value.MethodName} was used {methodUsage.Value.AmountUsage} times");
        }
    }

    private void DisplayInformationOfAllMessages()
    {
        var data = dataRepository.GetFullInfo();
        foreach (var methodUsage in data)
        {
            foreach (var historyItem in methodUsage.Value.History)
            {
                Console.WriteLine($"{historyItem.DateTime} -" +
                                  $" Message \'{historyItem.OriginalMessage}\' was encrypted via " +
                                  $"{methodUsage.Value.MethodName} into \'{historyItem.EncryptedMessage}\'");
            }
        }
    }

    private void ShowNavigation()
    {
        Console.Clear();
        Console.WriteLine("**********Information-Menu**********");
        Console.WriteLine("1. Display all usage of ciphers");
        Console.WriteLine("2. Display amount usage of ciphers");
        Console.WriteLine("3. Display amount encrypted messages");
        Console.WriteLine("4. To main menu");
        Console.WriteLine("****************-=END=-*****************");
    }
}