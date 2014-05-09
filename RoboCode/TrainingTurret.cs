using System.Collections.Generic;
using System.Diagnostics;
using Robocode;
using System.Drawing;

namespace arusslabs
{
    public class TrainingTurret : AdvancedRobot
    {
        public override void Run()
        {
            SetColors(Color.Black, Color.White, Color.Black);

            
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
            this.Fire(1);
        }
    }
}
