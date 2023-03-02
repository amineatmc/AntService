using Azure.Storage.Blobs;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFileService
    {
        string FileSaveToServer(IFormFile file, string filePath);

        // string ReadToServer(IFormFile file);
        Task UploadAsnyc(Stream fileStream, string name, string containerName);
        Task<Stream> DownloadAsync(string fileName, string containerName);

        public bool UploadWithPath(BlobContainerClient blobContainerClient, string remotefileName, string filePath, bool overwrite);
    }
}
