using System;

namespace GdsSample.Dal
{
    public abstract class BaseObject
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
