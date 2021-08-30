using System;
using System.Collections.Generic;
using System.Text;

namespace VAnimate.Data
{
    public class G : SvgElement
    {
        public override string SvgString()
        {
            if (!base.IsTree) throw new ArgumentException("Cannot form string due to overlapping branches or cycles in svg structure.");
            
            var ret = new StringBuilder("<g");
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