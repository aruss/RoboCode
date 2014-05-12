using System;
using System.Collections.Generic;
using Robocode;
using arusslabs.Base;

namespace arusslabs.Logger
{
    public class BattleLog
    {
        public RobotBase Robot;
        public int Capacity; 
        public IDictionary<string, EnemyInfo> InfoCurrent;
        public IDictionary<string, Queue<EnemyInfo>> InfoTrace;

        public BattleLog(RobotBase robot, int capacity)
        {
            this.Robot = robot;
            this.Robot.RobotDeathEvent += this.OnRobotDeathEvent;
            this.Robot.ScannedRobotEvent += this.OnScannedRobotEvent;

            this.Capacity = capacity; 
            this.InfoCurrent = new Dictionary<string, EnemyInfo>();
            this.InfoTrace = new Dictionary<string, Queue<EnemyInfo>>();
        }

        private void OnRobotDeathEvent(RobotBase sender, RobotDeathEvent evnt)
        {
            if (this.InfoCurrent.ContainsKey(evnt.Name))
            {
                this.InfoCurrent.Remove(evnt.Name); 
            }
        }

        private void OnScannedRobotEvent(RobotBase sender, ScannedRobotEvent evnt)
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
}