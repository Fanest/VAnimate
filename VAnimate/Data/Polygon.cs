using System;
using System.Collections.Generic;
using System.Text;

namespace VAnimate.Data
{
    public class Polygon : SvgElement
    {
        public List<(double? x, double? y)> Points { get; set; } = new();
        
        public override string SvgString()
        {
            var ret = new StringBuilder("<polygon");
            if (base.Id != null) ret.Append($" id=\"{base.Id}\"");

            ret.Append(" points=\"");
            foreach (var point in Points)
            {
                ret.Append($" {point.x},{point.y}");
            }
            ret.Append('\"');
            
            if (Children.Exists((element => true)))
            {
                ret.Append('>');
                foreach (var child in Children)
                {
                    ret.Append(child.SvgString());
                }
                ret.Append("</polygon>");
            }
            else
            {
                ret.Append("/>");
            }
            return ret.ToString();
        }
    }
}