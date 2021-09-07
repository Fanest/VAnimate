using System;
using System.Collections.Generic;
using System.Text;

namespace VAnimate.Data
{
    public class G : SvgElement
    {
        public override string SvgString()
        {
            var ret = new StringBuilder("<g");
            if (base.Id != null) ret.Append($"id=\"{base.Id}\"");
            ret.Append('>');
            
            foreach (var child in base.Children)
            {
                ret.Append(child.SvgString());
            }
            ret.Append("</g>\n");
            return ret.ToString();
        }
    }
}