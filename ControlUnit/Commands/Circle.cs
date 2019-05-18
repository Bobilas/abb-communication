using System;
using System.Threading.Tasks;

namespace ABBControlUnit
{
    public partial class ControlUnit
    {
        public Task<bool> CircleAsync(DrawPlane plane, double radius, int stepCount = 64, bool doLog = true)
        {
            return Task.FromResult(CommandAsync(new Func<bool>(() => Circle(plane, radius, stepCount, doLog))));
        }

        public bool Circle(DrawPlane plane, double radius, int stepCount = 64, bool doLog = true)
        {
            if (doLog)
            {
                OnMessageCall($"Drawing circle. Radius: {radius}");
            }

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
                        if (!OffsetMove(0, 0, 5.0)
                            || !OffsetMove(-radius, 0, 0)
                            || !OffsetMove(0, 0, -5.0))
                        {
                            return false;
                        }
                        break;
                    case DrawPlane.YZ:
                        if (!OffsetMove(-5.0, 0, 0)
                            || !OffsetMove(0, 0, -radius)
                            || !OffsetMove(5.0, 0, 0))
                        {
                            return false;
                        }
                        break;
                    case DrawPlane.XZ:
                        if (!OffsetMove(0, -5.0, 0)
                            || !OffsetMove(-radius, 0, 0)
                            || !OffsetMove(0, 5.0, 0))
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
                        if (!OffsetMove(0, 0, 5.0)
                            || !OffsetMove(radius, 0, 0)
                            || !OffsetMove(0, 0, -5.0))
                        {
                            return false;
                        }
                        break;
                    case DrawPlane.YZ:
                        if (!OffsetMove(-5.0, 0, 0)
                            || !OffsetMove(0, 0, radius)
                            || !OffsetMove(5.0, 0, 0))
                        {
                            return false;
                        }
                        break;
                    case DrawPlane.XZ:
                        if (!OffsetMove(0, -5.0, 0)
                            || !OffsetMove(radius, 0, 0)
                            || !OffsetMove(0, 5.0, 0))
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
                            if (!OffsetMove(Math.Sin(angle) * stepLength, Math.Cos(angle) * stepLength, 0))
                            {
                                return false;
                            }
                            break;
                        case DrawPlane.YZ:
                            if (!OffsetMove(0, Math.Cos(angle) * stepLength, Math.Sin(angle) * stepLength))
                            {
                                return false;
                            }
                            break;
                        case DrawPlane.XZ:
                            if (!OffsetMove(Math.Sin(angle) * stepLength, 0, Math.Cos(angle) * stepLength))
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
