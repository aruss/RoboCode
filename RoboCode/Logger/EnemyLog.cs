using System;
using System.Collections.Generic;
using Robocode;
using arusslabs.Base;

namespace arusslabs.Logger
{
    public delegate void EnemyInfoAddHandler(IRobotBase sender, EnemyInfo e);

    public class EnemyLog
    {
        public IRobotBase Robot;
        public int Capacity;
        public IDictionary<string, EnemyInfoStack> InfoTrace;
        public LinkedList<EnemyInfoStack> InfoTraceLru;
        public event EnemyInfoAddHandler EnemyInfoAdd;

        public EnemyLog(IRobotBase robot, int capacity = 100)
        {
            this.Robot = robot;
            this.Robot.RobotDeathEvent += this.OnRobotDeathEvent;
            this.Robot.ScannedRobotEvent += this.OnScannedRobotEvent;

            this.Capacity = capacity;
            this.InfoTrace = new Dictionary<string, EnemyInfoStack>();
            this.InfoTraceLru = new LinkedList<EnemyInfoStack>();
        }

        public void AddInfo(string name, EnemyInfo info)
        {
            #region Handle stack 

            EnemyInfoStack list;

            if (this.InfoTrace.ContainsKey(name))
            {
                list = this.InfoTrace[name];
            }
            else
            {
                list = new EnemyInfoStack(this.Capacity);
                this.InfoTrace.Add(name, list);
            }

            list.Push(info);

            #endregion 

            #region Update LRU list
            
            if (this.InfoTraceLru.Contains(list))
            {
                this.InfoTraceLru.Remove(list);
            }
            this.InfoTraceLru.AddFirst(list);
            
            #endregion 

            #region Rise event

            if (EnemyInfoAdd != null)
            {
                EnemyInfoAdd(this.Robot, info);
            }

            #endregion 
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
            var angle = this.Robot.HeadingRadians + evnt.BearingRadians;
            var info = new EnemyInfo
            {
                X = this.Robot.X + Math.Sin(angle) * evnt.Distance,
                Y = this.Robot.Y + Math.Cos(angle) * evnt.Distance,
                Time = this.Robot.Time,
                Velocity = evnt.Velocity,
                Heading = evnt.Heading,
                Bearing = evnt.Bearing,
                Distance = evnt.Distance,
                Energy = evnt.Energy
            };

            this.AddInfo(evnt.Name, info);
        }

        #endregion
    }

    /* public class EnemyLog
    {
        public IRobotBase Robot;
        public int Capacity;
        public IDictionary<string, Stack<EnemyInfo>> InfoTrace;
        public LinkedList<Stack<EnemyInfo>> InfoTraceLru;
        public event EnemyInfoAddHandler EnemyInfoAdd;

        public EnemyLog(IRobotBase robot, int capacity = 100)
        {
            this.Robot = robot;
            this.Robot.RobotDeathEvent += this.OnRobotDeathEvent;
            this.Robot.ScannedRobotEvent += this.OnScannedRobotEvent;

            this.Capacity = capacity;
            this.InfoTrace = new Dictionary<string, Stack<EnemyInfo>>();
            this.InfoTraceLru = new LinkedList<Stack<EnemyInfo>>();
        }

        public void AddInfo(string name, EnemyInfo info)
        {
            // list
            Stack<EnemyInfo> list;

            if (this.InfoTrace.ContainsKey(name))
            {
                list = this.InfoTrace[name];
            }
            else
            {
                list = new Stack<EnemyInfo>(this.Capacity);
                this.InfoTrace.Add(name, list);
            }

            //if (list.Count == this.Capacity)
            //    list.Dequeue();

            list.Push(info);

            // Update lru list
            if (this.InfoTraceLru.Contains(list))
            {
                this.InfoTraceLru.Remove(list);
            }
            this.InfoTraceLru.AddFirst(list);
            
            / *if (EnemyInfoAdd != null)
            {
                EnemyInfoAdd(this.Robot, info); 
            }* /
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
            var angle = this.Robot.HeadingRadians + evnt.BearingRadians;
            var info = new EnemyInfo
            {
                X = this.Robot.X + Math.Sin(angle) * evnt.Distance,
                Y = this.Robot.Y + Math.Cos(angle) * evnt.Distance,
                Time = this.Robot.Time,
                Velocity = evnt.Velocity,
                Heading = evnt.Heading,
                Bearing = evnt.Bearing,
                Distance = evnt.Distance,
                Energy = evnt.Energy
            };

            this.AddInfo(evnt.Name, info);
        }
        
        #endregion
    }*/
}