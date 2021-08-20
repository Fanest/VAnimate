using System;
using System.Collections.Generic;
using System.Text;

namespace VAnimate.Data
{
    public class Svg : ISvgElement
    {
        public List<ISvgElement> Children {get;} = new List<ISvgElement>();//Ensure References are Acyclic
        
        public (int? x, int? y, int? width, int? height) ViewBox;
        public int? X;
        public int? Y;
        public int? Height;
        public int? Width;
        public bool IsAcyclic => SubtreeContains(this);

        //Useful to check for Cycles
        public bool SubtreeContains(ISvgElement element)
        {
            foreach (var svgElement in Children)
            {
                if (svgElement == element) return true;
                if (svgElement.Children == null) continue;
                if (svgElement.Children.Exists(e => e.SubtreeContains(element))) return true;
            }
            return false;
        }

        public string SvgString()
        {
            if (!IsAcyclic) throw new AcyclicException("svg elements can't contain themselves");
            
            StringBuilder ret = new StringBuilder("<svg xmlns=\"http://www.w3.org/2000/svg\"");
            if (ViewBox != (null, null, null, null)) ret.Append($"viewBox=\"{ViewBox.x} {ViewBox.y} {ViewBox.width} {ViewBox.height}\"");
            if (X != null) ret.Append($" x=\"{X}\"");
            if (Y != null) ret.Append($" y=\"{Y}\"");
            if (Height != null) ret.Append($" height=\"{Height}\"");
            if (Width != null) ret.Append($" width=\"{Width}\"");
            ret.Append(">");
            foreach (var child in Children)
            {
                ret.Append(child.SvgString());
            }
            ret.Append("</svg>\n");
            return ret.ToString();
        }
    }

    public class AcyclicException : Exception
    {
        public AcyclicException()
        {
        }

        public AcyclicException(string message)
            : base(message)
        {
        }

        public AcyclicException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}