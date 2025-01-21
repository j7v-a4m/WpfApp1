using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using WpfApp1.Core;

namespace WpfApp1.Infrastructure
{
    internal class SftpService : ISftpService
    {
        private readonly SftpClient _sftpClient;
        
        public SftpService(string host, string username, string password)
        {
            _sftpClient = new SftpClient(host, username, password);
            _sftpClient.Connect();
        }

        public SftpClient GetClient()
        {
            if (!_sftpClient.IsConnected)
            {
                _sftpClient.Connect();
            }
            return _sftpClient;
        }

        public void Dispose()
        {
            _sftpClient?.Disconnect();
            _sftpClient?.Dispose();
        }
    }
}
