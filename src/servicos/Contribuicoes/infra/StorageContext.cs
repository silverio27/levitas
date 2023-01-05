using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;

namespace infra;
public class StorageContext
{
    public StorageSettings _storageSettings;
    public BlobContainerClient Fotos;
    public StorageContext(IOptions<StorageSettings> storageSettings)
    {
        _storageSettings = storageSettings.Value;
        Fotos = new BlobContainerClient(_storageSettings.ConnectionString, nameof(Fotos).ToLower());
        Fotos.CreateIfNotExists();
    }


}
