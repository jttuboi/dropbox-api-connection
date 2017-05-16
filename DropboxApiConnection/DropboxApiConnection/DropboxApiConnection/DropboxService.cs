using Dropbox.Api;
using Dropbox.Api.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropboxApiConnection
{
    public class DropboxService
    {
        // https://www.dropbox.com/developers/documentation/dotnet#tutorial

        string token = "";
        string toUpload = "asdasdasdasdasdasdasdasdasdasd";

        DropboxClient dropbox;

        public DropboxService()
        {
            dropbox = new DropboxClient(token);
        }

        public async Task<String> GetCurrentAccountAsync()
        {
            var account = await dropbox.Users.GetCurrentAccountAsync();
            return account.Name.DisplayName + ", " + account.Email;
        }

        public async Task<string> GetFile()
        {
            var file = await dropbox.Files.DownloadAsync("/data.json");
            return await file.GetContentAsStringAsync();
        }

        public async Task SetFile()
        {
            var mem = new MemoryStream(Encoding.UTF8.GetBytes(toUpload));
            var updated = await dropbox.Files.UploadAsync("/data2.txt", WriteMode.Overwrite.Instance, body: mem);
        }
    }
}
