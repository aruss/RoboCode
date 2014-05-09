using System.Collections.Generic;
using Robocode;

namespace arusslabs
{
    public class ScanLog : Queue<Scan>
    {
        private readonly int capacity;
        private readonly List<Scan> archive;

        public ScanLog(int capacity)
            : base()
        {
            this.capacity = capacity;
            this.archive = new List<Scan>();
        }
        
        public void Add(ScannedRobotEvent evnt)
        {
            var scan = new Scan
            {
                Bearing = evnt.Bearing,
                BearingRadians = evnt.BearingRadians,
                Distance = evnt.Distance,
                Energy = evnt.Energy,
                Heading = evnt.Heading,
                HeadingRadians = evnt.HeadingRadians,
                Velocity = evnt.Velocity
            };

            this.Add(scan);
        }

        public void Add(Scan item)
        {
            if (base.Count == this.capacity)
                this.archive.Add(base.Dequeue());

            base.Enqueue(item);
        }
    }

    public class Scan
    {
        public double Bearing;
        public double BearingRadians;
        public double Distance;
        public double Energy;
        public double Heading;
        public double HeadingRadians;
        public double Velocity;
    }
}