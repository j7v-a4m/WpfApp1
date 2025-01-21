using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace WpfApp1.Core
{
    public interface ISftpService
    {
        SftpClient GetClient();
    }
}
