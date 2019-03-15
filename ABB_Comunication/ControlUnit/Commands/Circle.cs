using System;
using Forms.Logging;

namespace ABB_Comunication
{
    public partial class ControlUnit
    {
        public enum CirclePlane
        {
            XY,
            YZ,
            XZ
        }
        public bool TryCircle(CirclePlane plane, decimal radius) => TryCircle(plane, (double)radius);
        public bool TryCircle(CirclePlane plane, double radius)
        {
            switch (plane)
            {
                case CirclePlane.XY:
                    if (!TryMove(-radius, 0, 0, false))
                    {
                        return false;
                    }
                    break;
                case CirclePlane.YZ:
                    if (!TryMove(0, 0, -radius, false))
                    {
                        return false;
                    }
                    break;
                case CirclePlane.XZ:
                    if (!TryMove(-radius, 0, 0, false))
                    {
                        return false;
                    }
                    break;
            }

            Logger.InvokeLog($"Drawing circle. Radius: {radius}");

            int count = 20;

            for (int i = 0; i < count; i++)
            {
                double angle = 2 * Math.PI * i / count;

                switch (plane)
                {
                    case CirclePlane.XY:
                        if (!TryMove(Math.Sin(angle) * radius, Math.Cos(angle) * radius, 0, false))
                        {
                            return false;
                        }
                        break;
                    case CirclePlane.YZ:
                        if (!TryMove(0, Math.Cos(angle) * radius, Math.Sin(angle) * radius, false))
                        {
                            return false;
                        }
                        break;
                    case CirclePlane.XZ:
                        if (!TryMove(Math.Sin(angle) * radius, 0, Math.Cos(angle) * radius, false))
                        {
                            return false;
                        }
                        break;
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
