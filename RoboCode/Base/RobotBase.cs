using Robocode;

namespace arusslabs.Base
{
    public delegate void BattleEndedEventHandler(RobotBase sender, BattleEndedEvent e);
    public delegate void BulletHitEventHandler(RobotBase sender, BulletHitEvent e);
    public delegate void BulletHitBulletEventHandler(RobotBase sender, BulletHitBulletEvent e);
    public delegate void BulletMissedEventHandler(RobotBase sender, BulletMissedEvent e);
    public delegate void DeathEventHandler(RobotBase sender, DeathEvent e);
    public delegate void HitByBulletEventHandler(RobotBase sender, HitByBulletEvent e);
    public delegate void HitRobotEventHandler(RobotBase sender, HitRobotEvent e);
    public delegate void HitWallEventHandler(RobotBase sender, HitWallEvent e);
    public delegate void RobotDeathEventHandler(RobotBase sender, RobotDeathEvent e);
    public delegate void ScannedRobotEventHandler(RobotBase sender, ScannedRobotEvent e);
    public delegate void RoundEndedEventHandler(RobotBase sender, RoundEndedEvent e);
    public delegate void StatusEventHandler(RobotBase sender, StatusEvent e);
    public delegate void WinEventHandler(RobotBase sender, WinEvent e);

    public abstract class RobotBase : AdvancedRobot
    {
        public event BattleEndedEventHandler BattleEndedEvent;
        public override void OnBattleEnded(BattleEndedEvent e)
        {
            if (this.BattleEndedEvent != null)
                this.BattleEndedEvent.Invoke(this, e);
        }

        public event BulletHitEventHandler BulletHitEvent;
        public override void OnBulletHit(BulletHitEvent e)
        {
            if (this.BulletHitEvent != null)
                this.BulletHitEvent.Invoke(this, e);
        }

        public event BulletHitBulletEventHandler BulletHitBulletEvent;
        public override void OnBulletHitBullet(BulletHitBulletEvent e)
        {
            if (this.BulletHitBulletEvent != null)
                this.BulletHitBulletEvent.Invoke(this, e);
        }

        public event BulletMissedEventHandler BulletMissedEvent;
        public override void OnBulletMissed(BulletMissedEvent e)
        {
            if (this.BulletMissedEvent != null)
                this.BulletMissedEvent.Invoke(this, e);
        }

        public event DeathEventHandler DeathEvent;
        public override void OnDeath(DeathEvent e)
        {
            if (this.DeathEvent != null)
                this.DeathEvent.Invoke(this, e);
        }

        public event HitByBulletEventHandler HitByBulletEvent;
        public override void OnHitByBullet(HitByBulletEvent e)
        {
            if (this.HitByBulletEvent != null)
                this.HitByBulletEvent.Invoke(this, e);
        }

        public event HitRobotEventHandler HitRobotEvent;
        public override void OnHitRobot(HitRobotEvent e)
        {
            if (this.HitRobotEvent != null)
                this.HitRobotEvent.Invoke(this, e);
        }

        public event HitWallEventHandler HitWallEvent;
        public override void OnHitWall(HitWallEvent e)
        {
            if (this.HitWallEvent != null)
                this.HitWallEvent.Invoke(this, e);
        }

        public event RobotDeathEventHandler RobotDeathEvent;
        public override void OnRobotDeath(RobotDeathEvent e)
        {
            if (this.RobotDeathEvent != null)
                this.RobotDeathEvent.Invoke(this, e);
        }

        public event RoundEndedEventHandler RoundEndedEvent;
        public override void OnRoundEnded(RoundEndedEvent e)
        {
            if (this.RoundEndedEvent != null)
                this.RoundEndedEvent.Invoke(this, e);
        }

        public event ScannedRobotEventHandler ScannedRobotEvent;
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            if (this.ScannedRobotEvent != null)
                this.ScannedRobotEvent.Invoke(this, e);
        }

        public event StatusEventHandler StatusEvent;
        public override void OnStatus(StatusEvent e)
        {
            if (this.StatusEvent != null)
                this.StatusEvent.Invoke(this, e);
        }

        public event WinEventHandler WinEvent;
        public override void OnWin(WinEvent e)
        {
            if (this.WinEvent != null) 
                this.WinEvent.Invoke(this, e);
        }
    }
}