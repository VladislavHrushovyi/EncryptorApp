using System.Globalization;
using Encryptor.Application.AggregateWebApi.Extension;
using Encryptor.Application.Repositories;
using Encryptor.Domain.Entities;

namespace Encryptor.Application.AggregateWebApi.Features.Encrypt;

public class EncryptService(IAppDataRepository appDataRepository, EncryptionMethodResolver methodResolver)
{
    private readonly IAppDataRepository _dataRepository = appDataRepository;

    public async Task<HistoryItem> ExecuteEncryption(EncryptRequest req)
    {
        var cipher = methodResolver(req.CipherName);

        var resultEncryption = cipher.Encrypt(req.Text);

        var historyItem = new HistoryItem()
        {
            AmountEncrypted = 1,
            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            OriginalMessage = req.Text,
            EncryptedMessage = resultEncryption
        };
        
        await Task.Run(() =>
        {
            _dataRepository.AddMessageInfo(cipher.MethodName, historyItem);
            _dataRepository.SaveChanges();
        });
        return historyItem;
    }
}