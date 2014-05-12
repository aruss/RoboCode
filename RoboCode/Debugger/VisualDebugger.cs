using System.Diagnostics;
using System.Drawing;
using Robocode;
using arusslabs.Logger;

namespace arusslabs.Debugger
{
    public class VisualDebugger
    {
        Pen penRed;

        public VisualDebugger(RobotBase robot)
        {
            this.penRed = new Pen(Color.Yellow, 1);
        }

        public void DrawEnemyInfo(EnemyInfo info, IGraphics graphics)
        {
            Debug.WriteLine("Dra2");
            graphics.DrawEllipse(this.penRed, (float)(info.X - 20), (float)(info.Y - 20), 40f, 40f);
        }
    }
}