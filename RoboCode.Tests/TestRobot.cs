using System;
using System.IO;
using Robocode;
using arusslabs.Base;

namespace arusslabs.Tests
{
    public class TestRobot : IRobotBase
    {
        public event BattleEndedEventHandler BattleEndedEvent;
        public virtual void OnBattleEnded(BattleEndedEvent e)
        {
            if (this.BattleEndedEvent != null)
                this.BattleEndedEvent.Invoke(this, e);
        }

        public event BulletHitEventHandler BulletHitEvent;
        public virtual void OnBulletHit(BulletHitEvent e)
        {
            if (this.BulletHitEvent != null)
                this.BulletHitEvent.Invoke(this, e);
        }

        public event BulletHitBulletEventHandler BulletHitBulletEvent;
        public virtual void OnBulletHitBullet(BulletHitBulletEvent e)
        {
            if (this.BulletHitBulletEvent != null)
                this.BulletHitBulletEvent.Invoke(this, e);
        }

        public event BulletMissedEventHandler BulletMissedEvent;
        public virtual void OnBulletMissed(BulletMissedEvent e)
        {
            if (this.BulletMissedEvent != null)
                this.BulletMissedEvent.Invoke(this, e);
        }

        public event DeathEventHandler DeathEvent;
        public virtual void OnDeath(DeathEvent e)
        {
            if (this.DeathEvent != null)
                this.DeathEvent.Invoke(this, e);
        }

        public event HitByBulletEventHandler HitByBulletEvent;
        public virtual void OnHitByBullet(HitByBulletEvent e)
        {
            if (this.HitByBulletEvent != null)
                this.HitByBulletEvent.Invoke(this, e);
        }

        public event HitRobotEventHandler HitRobotEvent;
        public virtual void OnHitRobot(HitRobotEvent e)
        {
            if (this.HitRobotEvent != null)
                this.HitRobotEvent.Invoke(this, e);
        }

        public event HitWallEventHandler HitWallEvent;
        public virtual void OnHitWall(HitWallEvent e)
        {
            if (this.HitWallEvent != null)
                this.HitWallEvent.Invoke(this, e);
        }

        public event RobotDeathEventHandler RobotDeathEvent;
        public virtual void OnRobotDeath(RobotDeathEvent e)
        {
            if (this.RobotDeathEvent != null)
                this.RobotDeathEvent.Invoke(this, e);
        }

        public event RoundEndedEventHandler RoundEndedEvent;
        public virtual void OnRoundEnded(RoundEndedEvent e)
        {
            if (this.RoundEndedEvent != null)
                this.RoundEndedEvent.Invoke(this, e);
        }

        public event ScannedRobotEventHandler ScannedRobotEvent;
        public virtual void OnScannedRobot(ScannedRobotEvent e)
        {
            if (this.ScannedRobotEvent != null)
                this.ScannedRobotEvent.Invoke(this, e);
        }

        public event StatusEventHandler StatusEvent;
        public virtual void OnStatus(StatusEvent e)
        {
            if (this.StatusEvent != null)
                this.StatusEvent.Invoke(this, e);
        }

        public event WinEventHandler WinEvent;
        public virtual void OnWin(WinEvent e)
        {
            if (this.WinEvent != null)
                this.WinEvent.Invoke(this, e);
        }

        public event PaintEventHandler PaintEvent;
        public virtual void OnPaint(IGraphics graphics)
        {
            if (this.PaintEvent != null)
                this.PaintEvent.Invoke(this, graphics);
        }

        public Robocode.RobotInterfaces.IAdvancedEvents GetAdvancedEventListener()
        {
            throw new NotImplementedException();
        }

        public Robocode.RobotInterfaces.IBasicEvents GetBasicEventListener()
        {
            throw new NotImplementedException();
        }

        public Robocode.RobotInterfaces.IRunnable GetRobotRunnable()
        {
            throw new NotImplementedException();
        }

        public void SetOut(TextWriter output)
        {
            throw new NotImplementedException();
        }

        public void SetPeer(Robocode.RobotInterfaces.Peer.IBasicRobotPeer peer)
        {
            throw new NotImplementedException();
        }

        public void OnCustomEvent(CustomEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnSkippedTurn(SkippedTurnEvent evnt)
        {
            throw new NotImplementedException();
        }

        public Robocode.RobotInterfaces.IInteractiveEvents GetInteractiveEventListener()
        {
            throw new NotImplementedException();
        }

        public Robocode.RobotInterfaces.IPaintEvents GetPaintEventListener()
        {
            throw new NotImplementedException();
        }

        public void OnKeyPressed(KeyEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnKeyReleased(KeyEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnKeyTyped(KeyEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnMouseClicked(MouseEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnMouseDragged(MouseEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnMouseEntered(MouseEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnMouseExited(MouseEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnMouseMoved(MouseEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnMousePressed(MouseEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnMouseReleased(MouseEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void OnMouseWheelMoved(MouseWheelMovedEvent evnt)
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public virtual double GunHeadingRadians { get; set; }

        public virtual double HeadingRadians { get; set; }

        public virtual double X { get; set; }

        public virtual double Y { get; set; }

        public double BattleFieldHeight { get; set; }

        public double BattleFieldWidth { get; set; }
        
        public long Time { get; set; }

        public double Velocity { get; set; }

        public double Width { get; set; }

        public void Ahead(double distance)
        {
            throw new NotImplementedException();
        }

        public void Back(double distance)
        {
            throw new NotImplementedException();
        }

        public void DoNothing()
        {
            throw new NotImplementedException();
        }

        public void Fire(double power)
        {
            throw new NotImplementedException();
        }


        public double GunCoolingRate { get; set; }

        public double GunHeading { get; set; }

        public double GunHeat { get; set; }

        public double Heading { get; set; }

        public double RadarHeading { get; set; }
    }
}