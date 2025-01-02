using Geometry;
using System.Drawing;

namespace GeometryPainting
{
    public static class SegmentExtansions
    {
        public static Dictionary<Segment, Color> SegmentColors = new();

        public static Color GetColor(this Segment segment)
        {
            return SegmentColors.TryGetValue(segment, out Color color) ? color : Color.FromArgb(255, 0, 0, 0);
        }

        public static void SetColor(this Segment segment, Color color)
        {
            if (SegmentColors.ContainsKey(segment))
            {
                SegmentColors.Remove(segment);
            }

            SegmentColors.Add(segment, color);
        }
    }
}
