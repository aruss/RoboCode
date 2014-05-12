using System;
using System.Collections.Generic;
using Robocode;
using arusslabs.Base;

namespace arusslabs.Logger
{
    public class BattleLog
    {
        public IRobotBase Robot;
        public int Capacity;
        public IDictionary<string, Stack<EnemyInfo>> InfoTrace;

        public BattleLog(IRobotBase robot, int capacity = 100)
        {
            this.Robot = robot;
            this.Robot.RobotDeathEvent += this.OnRobotDeathEvent;
            this.Robot.ScannedRobotEvent += this.OnScannedRobotEvent;

            this.Capacity = capacity;
            this.InfoTrace = new Dictionary<string, Stack<EnemyInfo>>();
        }

        #region private members

        private void OnRobotDeathEvent(IRobotBase sender, RobotDeathEvent evnt)
        {
            if (this.InfoTrace.ContainsKey(evnt.Name))
            {
                this.InfoTrace.Remove(evnt.Name);
            }
        }

        private void OnScannedRobotEvent(IRobotBase sender, ScannedRobotEvent evnt)
        {
            Stack<EnemyInfo> list;

            if (this.InfoTrace.ContainsKey(evnt.Name))
            {
                list = this.InfoTrace[evnt.Name];
            }
            else
            {
                list = new Stack<EnemyInfo>(this.Capacity);
                this.InfoTrace.Add(evnt.Name, list);
            }

            var angle = this.Robot.HeadingRadians + evnt.BearingRadians;
            var info = new EnemyInfo
            {
                X = this.Robot.X + Math.Sin(angle) * evnt.Distance,
                Y = this.Robot.Y + Math.Cos(angle) * evnt.Distance,
                Velocity = evnt.Velocity,
                Heading = evnt.Heading,
                Bearing = evnt.Bearing,
                Distance = evnt.Distance,
                Energy = evnt.Energy
            };

            //if (list.Count == this.Capacity)
            //    list.Dequeue();

            list.Push(info);
        }

        #endregion
    }
}