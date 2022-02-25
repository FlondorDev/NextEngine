using System;
namespace NextEngine
{
    public interface IDrawable
    {
        abstract public bool IsActive { get; set; }

        abstract public void Draw();
    }
}
