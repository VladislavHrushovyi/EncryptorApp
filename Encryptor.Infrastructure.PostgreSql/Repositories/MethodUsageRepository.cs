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
        if (_context.Ciphers.Any()) return;
        var ciphers = new[] {"Xor", "Caesar", "Vigenere"}.Select(x => new Ciphers()
        {
            AmountUsage = 0,
            Name = x,
            UpdateAt = DateTime.UtcNow
        }).ToList();
        _context.Ciphers.AddRange(ciphers);
        _context.SaveChanges();
    }

    public Dictionary<string, MethodUsage> GetFullInfo()
    {
        var result = new Dictionary<string, MethodUsage>();
        var ciphers = _context.Ciphers.Include(x => x.History).ToList();
        foreach (var cipher in ciphers)
        {
            result.Add(cipher.Name, new MethodUsage()
            {
                AmountUsage = cipher.AmountUsage,
                MethodName = cipher.Name,
                History = cipher.History.DistinctBy(x => x.OriginalText)
                    .Select(historyItem => new HistoryItem()
                    {
                        OriginalMessage = historyItem.OriginalText,
                        DateTime = _context.History.OrderBy(x => x.CreatedAt)
                            .Last(x => x.CreatedAt == historyItem.CreatedAt)
                            .CreatedAt.ToString(CultureInfo.InvariantCulture),
                        EncryptedMessage = historyItem.EncryptedText,
                        AmountEncrypted = _context.History.Count(x => x.OriginalText == historyItem.OriginalText &&
                                                                      x.CiphersId == cipher.Id)
                    })
                    .ToList()
            });
        }

        return result;
    }

    public MethodUsage GetInfoByMethodName(string methodName)
    {
        var cipherByName = _context.Ciphers.Include(ciphers => ciphers.History).First(x => x.Name == methodName);

        var result = new MethodUsage()
        {
            AmountUsage = cipherByName.AmountUsage,
            MethodName = cipherByName.Name,
            History = cipherByName.History.DistinctBy(x => x.OriginalText)
                .Select(historyItem => new HistoryItem()
                {
                    OriginalMessage = historyItem.OriginalText,
                    DateTime = _context.History.OrderBy(x => x.CreatedAt)
                        .Last(x => x.CreatedAt == historyItem.CreatedAt)
                        .CreatedAt.ToString(CultureInfo.InvariantCulture),
                    EncryptedMessage = historyItem.EncryptedText,
                    AmountEncrypted = _context.History.Count(x => x.OriginalText == historyItem.OriginalText 
                                                                        && x.CiphersId == cipherByName.Id)
                })
                .ToList()
        };
        return result;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void AddMessageInfo(string methodName, HistoryItem historyItem)
    {
        var cipherData = _context.Ciphers
            .Include(x => x.History)
            .First(x => x.Name == methodName);
        cipherData.AmountUsage += 1;
        cipherData.History.Add(new History()
        {
            CreatedAt = DateTime.UtcNow,
            EncryptedText = historyItem.EncryptedMessage,
            OriginalText = historyItem.OriginalMessage
        });
        _context.SaveChanges();
    }
}