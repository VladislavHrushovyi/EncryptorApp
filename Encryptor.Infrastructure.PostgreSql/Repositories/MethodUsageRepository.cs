using System.Globalization;
using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;
using Encryptor.Infrastructure.PostgreSql.DataContext;
using Encryptor.Infrastructure.PostgreSql.Entities;
using Encryptor.Infrastructure.PostgreSql.Entities.MapExtension;
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
            result.Add(cipher.Name, cipher.ToMethodUsage());
        }

        return result;
    }

    public MethodUsage GetInfoByMethodName(string methodName)
    {
        var cipherByName = _context.Ciphers.Include(ciphers => ciphers.History).First(x => x.Name == methodName);

        var result = cipherByName.ToMethodUsage();
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