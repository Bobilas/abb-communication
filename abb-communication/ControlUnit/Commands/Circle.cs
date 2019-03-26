using System;
using System.Threading;
using Forms.Logging;

namespace ABB_Comunication
{
    public partial class ControlUnit
    {
        public bool TryCircle(DrawPlane plane, decimal radius) => TryCircle(plane, (double)radius);
        public bool TryCircle(DrawPlane plane, double radius)
        {
            switch (plane)
            {
                case DrawPlane.XY:
                    if (!TryOffsetMove(plane, 0, 0, 5.0, false)
                        || !TryOffsetMove(plane, -radius, 0, 0, false) 
                        || !TryOffsetMove(plane, 0, 0, -5.0, false))
                    {
                        return false;
                    }
                    break;
                case DrawPlane.YZ:
                    if (!TryOffsetMove(plane, -5.0, 0, 0, false) 
                        || !TryOffsetMove(plane, 0, 0, -radius, false)
                        || !TryOffsetMove(plane, 5.0, 0, 0, false))
                    {
                        return false;
                    }
                    break;
                case DrawPlane.XZ:
                    if (!TryOffsetMove(plane, 0, -5.0, 0, false)
                        || !TryOffsetMove(plane, -radius, 0, 0, false)
                        || !TryOffsetMove(plane, 0, 5.0, 0, false))
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
                    case DrawPlane.XY:
                        if (!TryOffsetMove(plane, Math.Sin(angle) * step, Math.Cos(angle) * step, 0, false))
                        {
                            return false;
                        }
                        break;
                    case DrawPlane.YZ:
                        if (!TryOffsetMove(plane, 0, Math.Cos(angle) * step, Math.Sin(angle) * step, false))
                        {
                            return false;
                        }
                        break;
                    case DrawPlane.XZ:
                        if (!TryOffsetMove(plane, Math.Sin(angle) * step, 0, Math.Cos(angle) * step, false))
                        {
                            return false;
                        }
                        break;
                }
            }

            switch (plane)
            {
                case DrawPlane.XY:
                    if (!TryOffsetMove(plane, 0, 0, 5.0, false)
                        || !TryOffsetMove(plane, radius, 0, 0, false)
                        || !TryOffsetMove(plane, 0, 0, -5.0, false))
                    {
                        return false;
                    }
                    break;
                case DrawPlane.YZ:
                    if (!TryOffsetMove(plane, -5.0, 0, 0, false)
                        || !TryOffsetMove(plane, 0, 0, radius, false)
                        || !TryOffsetMove(plane, 5.0, 0, 0, false))
                    {
                        return false;
                    }
                    break;
                case DrawPlane.XZ:
                    if (!TryOffsetMove(plane, 0, -5.0, 0, false)
                        || !TryOffsetMove(plane, radius, 0, 0, false)
                        || !TryOffsetMove(plane, 0, 5.0, 0, false))
                    {
                        return false;
                    }
                    break;
            }

            return true;
        }
    }
}
