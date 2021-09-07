using System;
using System.Collections.Generic;
using System.Text;

namespace VAnimate.Data
{
    public class Svg : SvgElement
    {
        public (int? x, int? y, int? width, int? height) ViewBox { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }

        public override string SvgString()
        {
            if (!base.IsTree) throw new ArgumentException("Cannot form string due to overlapping branches or cycles in svg structure.");
            
            var ret = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\"");
            if (base.Id != null) ret.Append($" id=\"{base.Id}\"");
            if (ViewBox != (null, null, null, null))
            {
                if (!ViewBox.x.HasValue) throw new ArgumentException("Please specify x coordinate for the viewport. Incomplete viewport specification is not supported.");
                if (!ViewBox.y.HasValue) throw new ArgumentException("Please specify y coordinate for the viewport. Incomplete viewport specification is not supported.");
                if (!ViewBox.width.HasValue) throw new ArgumentException("Please specify width for the viewport. Incomplete viewport specification is not supported.");
                if (!ViewBox.height.HasValue) throw new ArgumentException("Please specify height for the viewport. Incomplete viewport specification is not supported.");
                ret.Append($" viewBox=\"{ViewBox.x} {ViewBox.y} {ViewBox.width} {ViewBox.height}\"");
            }
            if (X != null) ret.Append($" x=\"{X}\"");
            if (Y != null) ret.Append($" y=\"{Y}\"");
            if (Height != null) ret.Append($" height=\"{Height}\"");
            if (Width != null) ret.Append($" width=\"{Width}\"");
            ret.Append('>');
            foreach (var child in base.Children)
            {
                ret.Append(child.SvgString());
            }
            ret.Append("</svg>\n");
            return ret.ToString();
        }
    }
}