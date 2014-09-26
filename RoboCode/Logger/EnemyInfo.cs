using System;
using System.Collections.Generic;

namespace arusslabs.Logger
{
    public class EnemyInfoStack : Stack<EnemyInfo>
    {
        public EnemyInfoStack(int capacity = 100)
        {
            
        }

        public EnemyInfo LastScan { get; set; }
        
        public new void Push(EnemyInfo item)
        {
            base.Push(item);
            this.LastScan = item; 
        }

        public double GuessX(long when)
        {
            var diff = this.LastScan.Time - when;
            return this.LastScan.X + Math.Sin(this.LastScan.Heading) * LastScan.Velocity * diff;
        }

        public double GuessY(long when)
        {
            var diff = this.LastScan.Time - when;
            return this.LastScan.Y + Math.Cos(this.LastScan.Heading) * LastScan.Velocity * diff;
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
        public long Time; 
    }
}