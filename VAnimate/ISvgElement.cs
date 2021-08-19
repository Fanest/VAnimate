using System.Collections.Generic;

namespace VAnimate
{
    public interface ISvgElement
    {
        List<ISvgElement> Children { get; }
        bool SubtreeContains(ISvgElement element);

        string SvgString();
    }
}