using Robocode;
using System.Drawing;

namespace arusslabs
{
    public class ARS3891 : AdvancedRobot
    {
        public override void Run()
        {
            // Black Mamba Mode 
            SetColors(Color.Black, Color.Black, Color.Black);

        }

        public override void OnScannedRobot(ScannedRobotEvent e)
        {
        }

        public override void OnHitByBullet(HitByBulletEvent e)
        {
        }

        public override void OnHitRobot(HitRobotEvent e)
        {
        }
    }
}
