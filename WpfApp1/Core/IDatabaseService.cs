﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace WpfApp1.Core
{
    public interface IDatabaseService
    {
        OracleConnection GetConnection();
    }
}
