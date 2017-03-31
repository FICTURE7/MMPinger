using System.Drawing;

namespace MMPinger
{
    public static class Utils
    {
        // Linear color interpolation which uses the float overload of Lerp.
        public static Color Lerp(Color a, Color b, float amount)
        {
            // Do some clamping.
            if (amount > 1)
                amount = 1;

            var r = (int)Lerp(a.R, b.R, amount);
            var g = (int)Lerp(a.G, b.G, amount);
            var b1 = (int)Lerp(a.B, b.B, amount);

            return Color.FromArgb(r, g, b1);
        }

        // Linear interpolation.
        public static float Lerp(float a, float b, float amount)
        {
            return a + (b - a) * amount;
        }
    }
}
