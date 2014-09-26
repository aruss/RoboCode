using System.Diagnostics;
using System.Drawing;
using Robocode;
using arusslabs.Base;
using arusslabs.Logger;
using System.Linq;

namespace arusslabs.Debugger
{
    public class VisualDebugger
    {
        Pen penRed;
        SolidBrush brush;
        Font font;
        IRobotBase robot; 

        public VisualDebugger(IRobotBase robot)
        {
            this.robot = robot; 
            this.penRed = new Pen(Color.Yellow, 1);
            this.font = new Font("Courier New", 1f);
            this.brush = new SolidBrush(Color.Yellow);

        }

        public void DrawLogMeta(EnemyLog log, IGraphics graphics)
        {
            var line = 0;
            foreach (var kv in log.InfoTrace)
            {
                // draw tracked enemy informations
                graphics.DrawString(string.Format(" {0}: {1}", kv.Key, kv.Value.Count), font, brush, 20, 20 + (20 * line));
                line++;

                // draw guess target position 
                graphics.DrawEllipse(this.penRed, 
                    (float)(kv.Value.GuessX(this.robot.Time) - 20),
                    (float)(kv.Value.GuessY(this.robot.Time) - 20), 40f, 40f);
                


            }

        }
    }
}