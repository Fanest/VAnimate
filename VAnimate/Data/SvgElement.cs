using System;
using System.Collections.Generic;
namespace VAnimate.Data

{
    public abstract class SvgElement
    {
        public List<SvgElement> Children { get; } = new List<SvgElement>();

        protected bool IsTree
        {
            get => Visit(this, new HashSet<SvgElement>());
        }

        private bool Visit(SvgElement current, HashSet<SvgElement> visited) //Depth first search
        {
            if (visited.Contains(current)) return false;
            visited.Add(current);
            foreach (var child in Children)
            {
                if (!Visit(child, visited)) return false;
            }
            return true;
        }

        public abstract string SvgString();
    }
}