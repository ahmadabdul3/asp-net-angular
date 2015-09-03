using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MesjidCommittee.Helpers.ServerResponse
{
    public class ServerResponse<T1, T2, T3>
    {
        public T1 status { get; set; }
        public T2 message { get; set; }
        public T3 data { get; set; }
        public ServerResponse(T1 status, T2 message, T3 data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}