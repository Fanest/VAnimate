using System.Collections.Generic;

namespace VAnimate
{
    public class Svg : ISvgElement
    {
        //Ensure Elements never contain themselves
        private List<ISvgElement> _elements = new List<ISvgElement>();
        
        
        
        public void Add(ISvgElement element)
        {
            
        }

        public void RemoveElement(ISvgElement element)
        {
            
        }

        private bool SubtreeContains(ISvgElement element)
        {
            foreach (var svgElement in _elements)
            {
                if (svgElement == element) return true;
                
            }
        }
    }
}