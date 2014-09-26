using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Robocode;
using arusslabs.Base;

namespace arusslabs.Targeting
{
    public class LinearTargeting
    {
        IRobotBase robot;

        public LinearTargeting(IRobotBase robot)
        {
            this.robot = robot;

        }
        private void GetAngle(ScannedRobotEvent e)
        {
            var power = 5; // fireSmart(e);
            double gunDir = this.robot.GunHeading;
            double d = e.Distance; //distance to robot initially
            double vB = 20 - 3 * power; //bullet velocity is 20-3*power
            double hT = e.HeadingRadians; //heading of target
            double bTo = Math.ToRadians(fixAngle(e.Bearing + this.robot.Heading)); //bearing to initial target
            double xo = getX(); //x of robot
            double yo = getY(); //y of robot
            double xTo = d * Math.Sin(bTo) + xo; //initial x of target
            double yTo = d * Math.Cos(bTo) + yo; //initial y of target
            double vT = averageVelocity(e.Velocity); //velocity of target
            double v = getVelocity();
            double gunTurnSpeed = 20;
            double time = d / vB; //initial guess at time until impact
            double timeCur = time; //current guess at time

            //following variables initialized just to satisfy compiler, set in iterations
            double x = 0;
            double xCheck = 0;
            double y = 0;
            double bT = 0;
            double gunSwing = 0;

            //keep readjusting the time until impact by 
            for (int tryNum = 1; tryNum < 30; tryNum++)
            {
                x = vT * timeCur * Math.Sin(hT) + xTo; //proposed x position of impact
                y = vT * timeCur * Math.Cos(hT) + yTo; //proposed y position of impact
                bT = fixAngleRad(Math.Atan2((x - xo), (y - yo))); //bearing to proposed impact position
                if (getTurnRemaining() * (bT - Math.toRadians(gunDir)) > 0)
                    gunTurnSpeed = 30 - .75 * Math.Abs(getVelocity());
                else
                    gunTurnSpeed = 10 + .75 * Math.Abs(getVelocity());
                xCheck = vB * (timeCur - Math.abs(FixAngle(Math.ToDegrees(bT) - gunDir)) / gunTurnSpeed) * Math.Sin(bT) + xo; //see where the bullet will be for the current time
                if (((xCheck - xo) / (x - xo)) > 1) //lower the guess
                    timeCur = timeCur - time / Math.Pow(2, tryNum);
                else //raise the guess
                    timeCur = timeCur + time / Math.Pow(2, tryNum);
            }

            return fixAngle(Math.toDegrees(bT) - gunDir); //turn gun to the correct spot
        }
    }
}
