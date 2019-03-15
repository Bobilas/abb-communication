using System;
using Forms.Logging;

namespace ABB_Comunication
{
    public partial class ControlUnit
    {
        public bool TryCircle(decimal radius) => TryCircle((double)radius);
        public bool TryCircle(double radius)
        {
            if (!TryMove(-radius, 0, 0, false))
            {
                return false;
            }

            Logger.InvokeLog($"Drawing circle. Radius: {radius}");
            int count = 20;
            for (int i = 0; i < count; i++)
            {
                double angle = 2 * Math.PI * i / count;
                if (!TryMove(Math.Sin(angle) * radius, Math.Cos(angle) * radius, 0, false))
                {
                    return false;
                }
            }

            if (!TryMove(radius, 0, 0, false))
            {
                return false;
            }

            return true;
        }
    }
}
