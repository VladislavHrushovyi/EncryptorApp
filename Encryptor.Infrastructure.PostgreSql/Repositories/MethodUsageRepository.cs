using System.Globalization;
using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;
using Encryptor.Infrastructure.PostgreSql.DataContext;
using Encryptor.Infrastructure.PostgreSql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Encryptor.Infrastructure.PostgreSql.Repositories;

public class MethodUsageRepository : IAppDataRepository
{
    private readonly AppDataContext _context;
    public MethodUsageRepository(AppDataContext context)
    {
        _context = context;
        InitCiphers();
    }

    private void InitCiphers()
    {
        var ciphersName = new string[] {"Xor, Caesar, Vigenere"};
        if (!_context.Ciphers.Any())
        {
            _context.Ciphers.AddRange(
                    ciphersName.Select(x => new Ciphers()
                    {
                        AmountUsage = 0,
                        Name = x,
                        UpdateAt = DateTime.Now
                    })
                );
        }
    }

    public Dictionary<string, MethodUsage> GetFullInfo()
    {
        return new Dictionary<string, MethodUsage>();
    }

    public MethodUsage GetInfoByMethodName(string methodName)
    {
        var cipherByName = _context.Ciphers.First(x => x.Name == methodName);

        var result = new MethodUsage()
        {
            AmountUsage = cipherByName.AmountUsage,
            MethodName = cipherByName.Name,
            History = cipherByName.History.Select(x => new HistoryItem()
            {
                OriginalMessage = x.OriginalText,
                DateTime = x.CreatedAt.ToString(CultureInfo.InvariantCulture),
                EncryptedMessage = x.EncryptedText,
                AmountEncrypted = 1
            }).ToList()
        };
        return result;
    }

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void AddMessageInfo(string methodName, HistoryItem historyItem)
    {
        var cipherData = _context.Ciphers.First(x => x.Name == methodName);
        cipherData.AmountUsage += 1;
        cipherData.History.Add(new History()
        {
            CreatedAt = DateTime.Now,
            EncryptedText = historyItem.EncryptedMessage,
            OriginalText = historyItem.OriginalMessage
        });
    }
}