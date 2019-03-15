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

            int count = 64;
            double length = radius * 2 * Math.PI;
            double step = length / count;

            for (int i = 0; i < count; i++)
            {
                double angle = 2 * Math.PI * i / count;

                switch (plane)
                {
                    case CirclePlane.XY:
                        if (!TryMove(Math.Sin(angle) * step, Math.Cos(angle) * step, 0, false))
                        {
                            return false;
                        }
                        break;
                    case CirclePlane.YZ:
                        if (!TryMove(0, Math.Cos(angle) * step, Math.Sin(angle) * step, false))
                        {
                            return false;
                        }
                        break;
                    case CirclePlane.XZ:
                        if (!TryMove(Math.Sin(angle) * step, 0, Math.Cos(angle) * step, false))
                        {
                            return false;
                        }
                        break;
                }
            }

            switch (plane)
            {
                case CirclePlane.XY:
                    if (!TryMove(radius, 0, 0, false))
                    {
                        return false;
                    }
                    break;
                case CirclePlane.YZ:
                    if (!TryMove(0, 0, radius, false))
                    {
                        return false;
                    }
                    break;
                case CirclePlane.XZ:
                    if (!TryMove(radius, 0, 0, false))
                    {
                        return false;
                    }
                    break;
            }

            return true;
        }
    }
}
