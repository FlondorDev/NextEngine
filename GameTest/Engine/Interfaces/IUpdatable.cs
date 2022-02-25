using System;
namespace NextEngine
{
    public interface IUpdatable
    {
        abstract public bool IsActive { get; set; }
        abstract public void Update();
    }
}
