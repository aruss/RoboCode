using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Robocode;
using System.Drawing;
using Robocode.Util;
using arusslabs.Base;
using arusslabs.Debugger;
using arusslabs.Logger;

namespace arusslabs
{
    // http://students.seattleu.edu/clubs/compsci/robocode/blackknight2.html
    public class ARS3891 : RobotBase
    {
        VisualDebugger vDebugger;
        EnemyLog log;
        private bool dead = false;

        public override void Run()
        {
            // Black Mamba Mode 
            SetColors(Color.Black, Color.Black, Color.White);



            this.log = new EnemyLog(this, 500);
            this.vDebugger = new VisualDebugger(this);

            // Loop forever
            while (true)
            {
                try
                {
                    TurnGunRight(10); // Scans automatically
                }
                catch (Exception)
                {
                }

            }
        }

        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            
            base.OnScannedRobot(e);

            // Calculate exact location of the robot
            double absoluteBearing = Heading + e.Bearing;
            double bearingFromGun = Utils.NormalRelativeAngleDegrees(absoluteBearing - GunHeading);

            // If it's close enough, fire!
            if (Math.Abs(bearingFromGun) <= 3)
            {
                TurnGunRight(bearingFromGun);
                // We check gun heat here, because calling Fire()
                // uses a turn, which could cause us to lose track
                // of the other robot.
                if (GunHeat == 0)
                {
                    Fire(Math.Min(3 - Math.Abs(bearingFromGun), Energy - .1));
                }
            }
            else
            {
                // otherwise just set the gun to turn.
                // Note:  This will have no effect until we call scan()
                TurnGunRight(bearingFromGun);
            }
            // Generates another scan event if we see a robot.
            // We only need to call this if the gun (and therefore radar)
            // are not turning.  Otherwise, scan is called automatically.
            if (bearingFromGun == 0)
            {
                try
                {
                    this.Scan();
                }
                catch (Exception)
                {
                }

            }
        }

        private int dist = 50;
        public override void OnHitByBullet(HitByBulletEvent e)
        {
            base.OnHitByBullet(e); 

            this.TurnRight(Utils.NormalRelativeAngleDegrees(90 - (this.Heading - e.Heading)));

            this.Ahead(dist);
            dist *= -1;
            this.Scan();
        }

        /// <summary>
        ///   onHitRobot:  Aim at it.  Fire Hard!
        /// </summary>
        public override void OnHitRobot(HitRobotEvent e)
        {
            base.OnHitRobot(e);

            var turnGunAmt = Utils.NormalRelativeAngleDegrees(e.Bearing + Heading - GunHeading);
            this.TurnGunRight(turnGunAmt);
            this.Fire(3);
        }

        public override void OnPaint(IGraphics graphics)
        {

            vDebugger.DrawLogMeta(this.log, graphics); 
            /*
            foreach (var info in this.log.InfoCurrent)
            {
                vDebugger.DrawEnemyInfo(info.Value, graphics);
            }
            */
            base.OnPaint(graphics);
        }

    }
}
