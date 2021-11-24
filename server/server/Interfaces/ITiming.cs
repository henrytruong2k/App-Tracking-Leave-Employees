using System;

namespace server.Interfaces
{
    public interface ITiming
    {
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
