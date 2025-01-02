namespace Geometry
{
    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static double GetLength(Segment segment)
        {
            return GetLength(new Vector() { X = segment.End.X - segment.Begin.X, Y = segment.End.Y - segment.Begin.Y });
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            return GetLength(new Segment() { Begin = segment.Begin, End = vector })
                + GetLength(new Segment() { Begin = vector, End = segment.End }) == GetLength(segment);
        }

        public static Vector Add(Vector vectorOne, Vector vectorTwo)
        {
            return new Vector() { X = vectorOne.X + vectorTwo.X, Y = vectorOne.Y + vectorTwo.Y };
        }
    }
}