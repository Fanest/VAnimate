using System;
using System.Text;

namespace VAnimate.Data
{
    public class Circle : SvgElement
    {
        public (int? x, int? y) Center { get; set; }
        public int? Radius { get; set; }
        
        
        public override string SvgString()
        {
            var ret = new StringBuilder("<circle");
            if (base.Id != null) ret.Append($" id=\"{base.Id}\"");

            if (Center != (null, null))
            {
                if (Center.x == null)
                    throw new ArgumentException(
                        "Please provide x coordinate for the circle. Single coordinate not supported!");
                if (Center.y == null)
                    throw new ArgumentException(
                        "Please provide y coordinate for the circle. Single coordinate not supported!");
                ret.Append($" cx=\"{Center.x}\" cy=\"{Center.y}\"");
            }
            if (Radius != null) ret.Append($" r=\"{Radius}\"");
            
            if (Children.Exists((element => true)))
            {
                ret.Append('>');
                foreach (var child in Children)
                {
                    ret.Append(child.SvgString());
                }
                ret.Append("</circle>");
            }
            else
            {
                ret.Append("/>");
            }
            return ret.ToString();
        }
    }
}