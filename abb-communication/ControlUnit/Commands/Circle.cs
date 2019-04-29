using System;
using static ABB_Comunication.MainForm;

namespace ABB_Comunication.Control
{
    public partial class ControlUnit
    {
        public bool TryCircle(DrawPlane plane, decimal radius) => TryCircle(plane, (double)radius);
        public bool TryCircle(DrawPlane plane, double radius)
        {
            Logger.InvokeLog($"Drawing circle. Radius: {radius}");

            int stepCount = 64;
            double circleLength = radius * 2 * Math.PI;
            double stepLength = circleLength / stepCount;

            return
                stepOut()
                && drawCircle()
                && stepIn();

            bool stepOut()
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

                return true;
            }
            bool stepIn()
            {
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
            bool drawCircle()
            {
                for (int i = 0; i < stepCount; i++)
                {
                    double angle = 2 * Math.PI * i / stepCount;

                    switch (plane)
                    {
                        case DrawPlane.XY:
                            if (!TryOffsetMove(plane, Math.Sin(angle) * stepLength, Math.Cos(angle) * stepLength, 0, false))
                            {
                                return false;
                            }
                            break;
                        case DrawPlane.YZ:
                            if (!TryOffsetMove(plane, 0, Math.Cos(angle) * stepLength, Math.Sin(angle) * stepLength, false))
                            {
                                return false;
                            }
                            break;
                        case DrawPlane.XZ:
                            if (!TryOffsetMove(plane, Math.Sin(angle) * stepLength, 0, Math.Cos(angle) * stepLength, false))
                            {
                                return false;
                            }
                            break;
                    }
                }

                return true;
            }
        }
    }
}
