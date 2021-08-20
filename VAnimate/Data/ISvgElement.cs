using System.Collections.Generic;

namespace VAnimate.Data
{
    public interface ISvgElement
    {
        List<ISvgElement> Children { get; }
        bool SubtreeContains(ISvgElement element);

        string SvgString();
    }
}