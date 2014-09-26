using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using arusslabs.Base;
using arusslabs.Logger;

namespace arusslabs.Movement
{
    // http://robowiki.net/wiki/Anti-Gravity_Tutorial
    // http://students.seattleu.edu/clubs/compsci/robocode/smartbomb2.html
    // http://students.seattleu.edu/clubs/compsci/robocode/smartbomb4.html

    //AntiGravity: make virtual magnets and get attracted/repelled from them
    private class AntiGravity
    {
        Point2D.Double[] points; //stores all of the objects, their positions, and their field strength objects[objects][property]
        double[] fields;
        //properties:
        //0: x
        //1: y
        //2: strength
        //if strength is negative, it attracts

        private AntiGravity()
        {
            points = new Point2D.Double[GRAV_EXTENT];
            fields = new double[GRAV_EXTENT];

        }

        public double getDirection()
        {
            double Xcomp = 0;
            double Ycomp = 0;
            double x = getX();
            double y = getY();
            double distance, magnitude, angle;

            addWalls();

            for (int i = 0; i < GRAV_EXTENT; i++)
            {
                if (points[i] != null && points[i].distanceSq(x, y) != 0)
                {
                    magnitude = fields[i] / points[i].distance(x, y);
                    angle = Math.atan2(x - points[i].getX(), y - points[i].getY());
                    Xcomp += magnitude * Math.sin(angle);
                    Ycomp += magnitude * Math.cos(angle);
                }
            }
            clearObjects();
            return Math.atan2(Xcomp, Ycomp);
        }

        private void clearObjects()
        {
            for (int i = 0; i < GRAV_EXTENT; i++)
                points[i] = null;
        }

        private void addWalls()
        {
            addObject(getX(), 0, GRAV_WALL);
            addObject(getX(), ySize, GRAV_WALL);
            addObject(0, getY(), GRAV_WALL);
            addObject(xSize, getY(), GRAV_WALL);
            addObject(0, 0, GRAV_WALL);
            addObject(0, ySize, GRAV_WALL);
            addObject(xSize, 0, GRAV_WALL);
            addObject(xSize, ySize, GRAV_WALL);
        }

        public boolean addObject(double x, double y, double field)
        {
            int i = 0;
            while (i < GRAV_EXTENT && points[i] != null)
                i++;
            if (i == GRAV_EXTENT) return false;
            points[i] = new Point2D.Double(x, y);
            fields[i] = field;
            return true;
        }
    }
}
