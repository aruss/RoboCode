using Robocode;
using Robocode.RobotInterfaces;

namespace arusslabs.Base
{
    public delegate void BattleEndedEventHandler(IRobotBase sender, BattleEndedEvent e);
    public delegate void BulletHitEventHandler(IRobotBase sender, BulletHitEvent e);
    public delegate void BulletHitBulletEventHandler(IRobotBase sender, BulletHitBulletEvent e);
    public delegate void BulletMissedEventHandler(IRobotBase sender, BulletMissedEvent e);
    public delegate void DeathEventHandler(IRobotBase sender, DeathEvent e);
    public delegate void HitByBulletEventHandler(IRobotBase sender, HitByBulletEvent e);
    public delegate void HitRobotEventHandler(IRobotBase sender, HitRobotEvent e);
    public delegate void HitWallEventHandler(IRobotBase sender, HitWallEvent e);
    public delegate void RobotDeathEventHandler(IRobotBase sender, RobotDeathEvent e);
    public delegate void ScannedRobotEventHandler(IRobotBase sender, ScannedRobotEvent e);
    public delegate void RoundEndedEventHandler(IRobotBase sender, RoundEndedEvent e);
    public delegate void StatusEventHandler(IRobotBase sender, StatusEvent e);
    public delegate void WinEventHandler(IRobotBase sender, WinEvent e);
    public delegate void PaintEventHandler(IRobotBase sender, IGraphics graphics);

    public interface IRobotBase : IAdvancedRobot,  IAdvancedEvents, IInteractiveRobot, IPaintRobot, IBasicEvents3, IInteractiveEvents, IPaintEvents, IRunnable
    {
        event BattleEndedEventHandler BattleEndedEvent;
        event BulletHitEventHandler BulletHitEvent;
        event BulletHitBulletEventHandler BulletHitBulletEvent;
        event BulletMissedEventHandler BulletMissedEvent;
        event DeathEventHandler DeathEvent;
        event HitByBulletEventHandler HitByBulletEvent;
        event HitRobotEventHandler HitRobotEvent;
        event HitWallEventHandler HitWallEvent;
        event RobotDeathEventHandler RobotDeathEvent;
        event RoundEndedEventHandler RoundEndedEvent;
        event ScannedRobotEventHandler ScannedRobotEvent;
        event StatusEventHandler StatusEvent;
        event WinEventHandler WinEvent;
        event PaintEventHandler PaintEvent;

        double GunHeadingRadians { get; }
        double HeadingRadians { get; }
        double X { get; }
        double Y { get; }
        double BattleFieldHeight { get; }
        double BattleFieldWidth { get; }

        // TODO: Add fields from AdvancedRobot implementation as required
    }

    public abstract class RobotBase : AdvancedRobot, IRobotBase
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

        public event PaintEventHandler PaintEvent; 
        public override void OnPaint(IGraphics graphics)
        {
            if (this.PaintEvent != null)
                this.PaintEvent.Invoke(this, graphics);
        }
    }
}