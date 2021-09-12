using System.Collections.Generic;
using VAnimate.Data.Attributes;

namespace VAnimate.Data
{
    public class Animate : SvgElement
    {
        //Add Later: (Items in Braces are Optional)
        //(end, min, max, restart, repeatDur)
        //values, keyTimes, from, to, (calcMode, keySplines, by)
        //attributeName, (additive, accumulate)
        public BeginValue Begin { get; set; } = new();
        public double? Dur { get; set; } = null; //Media not supported for lack of usefulness null == indefinite
        public int? RepeatCount { get; set; } = null; //null == indefinite
        public bool Fill { get; set; } = false; //true means freeze; false means remove
        
        public override string SvgString()
        {
            throw new System.NotImplementedException();
        }
    }
}