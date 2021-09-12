using System;
using System.Collections.Generic;
using System.Text;

namespace VAnimate.Data.Attributes
{
    public class BeginValue
    {
        public List<Kind> Values { get; set; } = new();
        public string ToAttributeString()
        {
            var ret = new StringBuilder(" begin=\"");
            bool first = true;
            foreach (var value in Values)
            {
                if (!first) ret.Append(';');
                first = false;
                ret.Append(value.ToAttributeString());
            }
            return ret.ToString() + '\"';
        }
        
        public Kind Type { get; set; }

        public abstract class Kind
        {
            public abstract string ToAttributeString();
        }
        public class Offset : Kind
        {
            public double OffsetValue { get; set; }
            public override string ToAttributeString()
            {
                return $"{OffsetValue}s";
            }
        }
        
        public class SyncBase : Kind
        {
            public string Id { get; set; }
            public Offset Offset { get; set; }
            public Type Anchor { get; set; }
            public enum Type
            {
                End, Begin
            }

            public override string ToAttributeString()
            {
                return $"{Id}.{Anchor.ToString().ToLower()}{Offset.OffsetValue}s";
            }
        }

        public class Event : Kind
        {
            public string Id { get; set; }
            public Events EventType { get; set; }
            public Offset Offset { get; set; }
            public enum Events
            {
                Focus, Blur, FocusIn, FocusOut, Activate, AuxClick, Click, DblClick, MouseDown, MouseEnter, MouseLeave,
                MouseMove, MouseOut, MouseOver, MouseUp, Wheel, BeforeInput, Input, Keydown, Keyup, CompositionStart,
                CompositionUpdate, CompositionEnd, Load, Unload, Abort, Error, Select, Resize, Scroll, BeginEvent,
                EndEvent, RepeatEvent
            }

            public override string ToAttributeString()
            {
                return $"{Id}.{EventType.ToString().ToLower()}{Offset.OffsetValue}s";
            }
        }

        public class Repeat : Kind
        {
            public string Id { get; set; }
            public Offset Offset { get; set; }
            public int Repetitions { get; set; }
            public override string ToAttributeString()
            {
                return $"{Id}.repeat({Repetitions}){Offset.OffsetValue}s";
            }
        }
        
        public class AccessKey : Kind
        {
            public char Key { get; set; }
            public Offset Offset { get; set; }
            public override string ToAttributeString()
            {
                return $"accessKey({Key}){Offset.OffsetValue}s";
            }
        }

        public class WallClock : Kind
        {
            public DateTime Time { get; set; }
            public override string ToAttributeString()
            {
                return $"wallclock({Time.ToString("s", System.Globalization.CultureInfo.InvariantCulture)})";
            }
        }

        public class Indefinite : Kind
        {
            public override string ToAttributeString()
            {
                return "indefinite";
            }
        }
    }
}