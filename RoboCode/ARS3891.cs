using System;
using System.Collections.Generic;
using System.Diagnostics;
using Robocode;
using System.Drawing;

namespace arusslabs
{
    public class DummyRobot : AdvancedRobot
    {

    }

    public class ARS3891 : AdvancedRobot
    {
        BattleLog log;
        private bool dead = false;

        public override void Run()
        {
            // Black Mamba Mode 
            SetColors(Color.Black, Color.Black, Color.Black);

            this.log = new BattleLog(this, 500);


            // Do stuff as long alive 
            while (!dead)
            {
                Ahead(100); // Move ahead 100
                TurnGunRight(360); // Spin gun around
                Back(100); // Move back 100
                TurnGunRight(360); // Spin gun around
            }
        }

        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            this.Fire(1);
        }

        public override void OnHitByBullet(HitByBulletEvent e)
        {
            this.TurnLeft(90 - e.Bearing);
        }

        public override void OnHitRobot(HitRobotEvent e)
        {

        }

        public override void OnDeath(DeathEvent e)
        {
            this.dead = true;
        }

        public override void OnWin(WinEvent e)
        {

        }

        public override void OnStatus(StatusEvent e)
        {
            Debug.WriteLine("On Status");
        }



        VisualDebugger vDebugger = new VisualDebugger();
        EnemyInfo info = new EnemyInfo() { X = 100, Y = 100 };

        public override void OnPaint(IGraphics graphics)
        {
            vDebugger.DrawEnemyBot(info, graphics);
        }

    }

    public class BattleLog
    {
        public AdvancedRobot Robot;
        public int Capacity; 
        public IDictionary<string, EnemyInfo> InfoCurrent;
        public IDictionary<string, Queue<EnemyInfo>> InfoTrace;

        public BattleLog(AdvancedRobot robot, int capacity)
        {
            this.Robot = robot;
            this.Capacity = capacity; 
            this.InfoCurrent = new Dictionary<string, EnemyInfo>();
            this.InfoTrace = new Dictionary<string, Queue<EnemyInfo>>();
        }

        public void LogEvent(ScannedRobotEvent evnt)
        {
            EnemyInfo info;
            //Queue<EnemyInfo> queue; 

            if (this.InfoCurrent.ContainsKey(evnt.Name))
            {
                info = this.InfoCurrent[evnt.Name];
                //queue = this.InfoTrace[evnt.Name]; 
            }
            else
            {
                info = new EnemyInfo();
                this.InfoCurrent.Add(evnt.Name, info);

                //queue = new Queue<EnemyInfo>(); 
                //this.InfoTrace.Add(evnt.Name, queue);
            }
            
            // update current instance 
            var angle = this.Robot.HeadingRadians + evnt.BearingRadians;
            info.X = this.Robot.X + Math.Sin(angle) * evnt.Distance;
            info.Y = this.Robot.Y + Math.Cos(angle) * evnt.Distance;
            info.Velocity = evnt.Velocity;
            info.Heading = evnt.Heading;
            info.Bearing = evnt.Bearing;
            info.Distance = evnt.Distance;
            info.Energy = evnt.Energy;
        }
    }

    public class EnemyInfo
    {
        public string Name;
        public double X;
        public double Y;
        public double Velocity;
        public double Heading;
        public double TargetX;
        public double TargetY;
        public double Bearing;
        public double Distance;
        public double Energy; 
    }

    public class VisualDebugger
    {
        Pen penRed;

        public VisualDebugger()
        {
            this.penRed = new Pen(Color.Red, 1);
        }

        public void DrawEnemyBot(EnemyInfo info, IGraphics graphics)
        {
            graphics.DrawEllipse(this.penRed, (float)(info.X - 20), (float)(info.Y - 20), 40f, 40f);
        }
    }


}
