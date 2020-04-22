using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ServiceModule
    {
        private string _connection;
        public ServiceModule(string connection)
        {
            _connection = connection;
        }
    }
}
