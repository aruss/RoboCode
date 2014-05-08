using System.Collections.Generic;

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

        public void Add(Scan item)
		{
			if (base.Count == this.capacity)
				archive.Add(base.Dequeue()); 

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