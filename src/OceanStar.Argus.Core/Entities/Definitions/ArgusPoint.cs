using System;

namespace OceanStar.Argus.Entities.Definitions
{
    public struct ArgusPoint : IEquatable<ArgusPoint>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public ArgusPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public ArgusPoint(double x, double y)
        {
            X = (int)Math.Round(x, 0);
            Y = (int)Math.Round(y, 0);
        }

        public double Distance(ArgusPoint other)
        {

            return Math.Sqrt(Math.Pow((other.X - this.X), 2) + Math.Pow((other.Y - this.Y), 2));
        }

        public static bool operator ==(ArgusPoint left, ArgusPoint right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(ArgusPoint left, ArgusPoint right)
        {
            return !(left == right);
        }

        public bool Equals(ArgusPoint other)
        {
            return this == other;
        }

        public override bool Equals(object? obj)
        {
            return obj is ArgusPoint other && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashHelpers.Combine(this.X, this.Y);
        }

        public override string ToString()
        {
            return "{X=" + X.ToString() + ",Y=" + Y.ToString() + "}";
        }
    }

    internal static class HashHelpers
    {
        public static readonly int RandomSeed = new Random().Next(int.MinValue, int.MaxValue);

        public static int Combine(int h1, int h2)
        {
            return (int)((uint)(h1 << 5) | (uint)h1 >> 27) + h1 ^ h2;
        }
    }
}
