using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FileManager : IFileService
    {
        private readonly BlobServiceClient _blobServiceClient;
        BlobContainerClient _blobContainerClient;
        public FileManager()
        {
            string fullLink = "https://taxi7x24prodstorage.blob.core.windows.net/ruhsat?";
            _blobServiceClient = new BlobServiceClient(new Uri(fullLink));                   
        }

        public async Task<Stream> DownloadAsync(string fileName, string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            Response<BlobDownloadInfo> response = await blobClient.DownloadAsync();
            return response.Value.Content;
        }

        public string FileSaveToServer(IFormFile file, string filePath)
        {
            var fileFormat = file.FileName.Substring(file.FileName.LastIndexOf("."));
            fileFormat = fileFormat.ToLower();
            string fileName = Guid.NewGuid().ToString() + fileFormat;
            string path = filePath + fileName;
            using (var stream = System.IO.File.Create(path))
            {
                file.CopyTo(stream);

            

                //string fullLink = "https://taxi7x24prodstorage.blob.core.windows.net/ruhsat?";
                //var blobServiceClient = new BlobServiceClient(new Uri(fullLink), null);
                //var blobContainerClient = blobServiceClient.GetBlobContainerClient("ruhsat");


                //FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
                //UploadWithPath(fileStream, Path.GetFileName(fileName), overwrite: true);
            }
            return fileName;
        }

        public async Task UploadAsnyc(Stream fileStream, string name,string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(name);
            await blobClient.UploadAsync(fileStream);
        }









        public static BlobContainerClient GetBlobContainerClientSAS(string fullLink) 
        {
            var blobServiceClient = new BlobServiceClient(new Uri(fullLink), null);
            var info = blobServiceClient.GetAccountInfo(); 
            Console.WriteLine(info.Value.AccountKind); 
            var blobContainerClient = blobServiceClient.GetBlobContainerClient("containername");
            return blobContainerClient;
        }

        public bool UploadWithPath(BlobContainerClient blobContainerClient, string remotefileName, string filePath, bool overwrite = true) 
        {
            var blobClient = blobContainerClient.GetBlobClient(remotefileName); 
            try 
            {
                BlobUploadOptions blobUploadOptions = new BlobUploadOptions();
                var result = blobClient.Upload(filePath, overwrite: true);
                return true; 
            } 
            catch (RequestFailedException)
            {
                return false;
            }
        }
        
        public static bool UploadWithStream(BlobContainerClient blobContainerClient, string remotefileName, Stream stream, bool overwrite = true) 
        {
            var blobClient = blobContainerClient.GetBlobClient(remotefileName); 
            try
            {
                var result = blobClient.Upload(stream, overwrite: overwrite);
                return true;
            } 
            catch (RequestFailedException) 
            {
                return false; 
            }
        }
    }
}
