using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTVDB_API_v2
{
    /// <summary>
    /// Interface for objects that will be serialized and sent to the server.
    /// </summary>
    public interface ITVDBRequest
    {
    }

    /// <summary>
    /// Interface for classes that will be returned from the server
    /// </summary>
    public interface ITVDBResponse
    {
        string Error { get; set; }
    }
}
