using System;

namespace OceanStar.Argus.Entities.Definitions
{
    public struct ArgusLine : IEquatable<ArgusLine>
    {
        public ArgusPoint Start { get; set; }

        public ArgusPoint Stop { get; set; }

        public ArgusLine(ArgusPoint start, ArgusPoint stop)
        {
            Start = start;
            Stop = stop;
        }

        public ArgusLine(int x1, int y1, int x2, int y2)
        {
            Start = new ArgusPoint(x1, y1);
            Stop = new ArgusPoint(x2, y2);
        }

        public ArgusLine(double x1, double y1, double x2, double y2)
        {
            Start = new ArgusPoint(x1, y1);
            Stop = new ArgusPoint(x2, y2);
        }

        public static bool operator ==(ArgusLine left, ArgusLine right)
        {
            return left.Start == right.Start && left.Stop == right.Stop;
        }

        public static bool operator !=(ArgusLine left, ArgusLine right)
        {
            return !(left == right);
        }

        public bool Equals(ArgusLine other)
        {
            return this == other;
        }

        public override bool Equals(object? obj)
        {
            return obj is ArgusLine other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode() + Stop.GetHashCode();
        }

        public override string ToString()
        {
            return "Line: Start=" + Start.ToString() + ", Stop=" + Stop.ToString() + ".";
        }
    }
}
