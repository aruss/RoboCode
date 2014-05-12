using Robocode;
using System.Drawing;
using arusslabs.Base;
using arusslabs.Debugger;
using arusslabs.Logger;

namespace arusslabs
{
    public class ARS3891 : RobotBase
    {
        VisualDebugger vDebugger; 
        BattleLog log;
        private bool dead = false;

        public override void Run()
        {
            // Black Mamba Mode 
            SetColors(Color.Black, Color.Black, Color.White);

            this.log = new BattleLog(this, 500);
            this.vDebugger = new VisualDebugger(this);

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
            // Debug.WriteLine("Scanned: " + e.Name);
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
            
        }

        public override void OnPaint(IGraphics graphics)
        {
            foreach (var info in this.log.InfoCurrent)
            {
                vDebugger.DrawEnemyInfo(info.Value, graphics);
            }

            base.OnPaint(graphics);
        }

    }
}
