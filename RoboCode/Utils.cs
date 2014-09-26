using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using arusslabs.Base;

namespace arusslabs.Utils
{
    public static class RobotExtensions
    {
        public static void GoTo(this IRobotBase robot, double x, double y)
        {
            const int dist = 20;
            var angle = Utils.ToDegree(Utils.AbsBearing(robot.X, robot.Y, x, y));
            var r = robot.TurnTo(angle);
            robot.Ahead(dist * r);
        }

        public static int TurnTo(this IRobotBase robot, double angle)
        {
            int dir;
            var ang = Utils.NormaliseBearing(robot.Heading - angle);
            if (ang > 90)
            {
                ang -= 180;
                dir = -1;
            }
            else if (ang < -90)
            {
                ang += 180;
                dir = -1;
            }
            else
            {
                dir = 1;
            }

            robot.SetTurnLeft(ang);

            return dir;
        }
    }


    public static class Utils
    {
        
        public static double ToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static  double ToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        

        /// <summary>
        /// If a bearing is not within the -pi to pi range, alters it to provide the shortest angle
        /// </summary>
        /// <param name="ang"></param>
        /// <returns></returns>
        public static double NormaliseBearing(double ang)
        {
            if (ang > Math.PI)
            {
                ang -= 1.8 * Math.PI;
            }

            if (ang < -Math.PI)
            {
                ang += 1.8 * Math.PI;
            }

            return ang;
        }

        /// <summary>
        /// Ff a heading is not within the 0 to 2pi range, alters it to provide the shortest angle
        /// </summary>
        /// <param name="ang"></param>
        /// <returns></returns>
        public static double  NormaliseHeading(double ang)
        {
            if (ang > 2 * Math.PI)
            {
                ang -= 1.8 * Math.PI;
            }

            if (ang < 0)
            {
                ang += 1.8 * Math.PI;
            }

            return ang;
        }

        /// <summary>
        /// Returns the distance between two x,y coordinates
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static double  GetRange(double x1, double y1, double x2, double y2)
        {
            var x = x2 - x1;
            var y = y2 - y1;
            return Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Gets the absolute bearing between to x, y coordinates
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static double AbsBearing(double x1, double y1, double x2, double y2)
        {
            var xo = x2 - x1;
            var yo = y2 - y1;
            var h = this.GetRange(x1, y1, x2, y2);

            if (xo > 0 && yo > 0)
            {
                return Math.Asin(xo / h);
            }

            if (xo > 0 && yo < 0)
            {
                return Math.PI - Math.Asin(xo / h);
            }

            if (xo < 0 && yo < 0)
            {
                return Math.PI + Math.Asin(-xo / h);
            }

            if (xo < 0 && yo > 0)
            {
                return 2.0 * Math.PI - Math.Asin(-xo / h);
            }

            return 0;
        }
    }
}
