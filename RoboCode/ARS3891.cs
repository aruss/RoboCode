﻿using Robocode;
using System.Drawing;
using arusslabs.Debugger;
using arusslabs.Logger;

namespace arusslabs
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
    
    public class RobotBase : AdvancedRobot
    {

        public event BattleEndedEventHandler BattleEndedEvent;
        public override void OnBattleEnded(BattleEndedEvent e)
        {
            this.BattleEndedEvent.Invoke(this, e);
        }

        public event BulletHitEventHandler BulletHitEvent;
        public override void OnBulletHit(BulletHitEvent e)
        {
            this.BulletHitEvent.Invoke(this, e);
        }

        public event BulletHitBulletEventHandler BulletHitBulletEvent;
        public override void OnBulletHitBullet(BulletHitBulletEvent e)
        {
            this.BulletHitBulletEvent.Invoke(this, e);
        }

        public event BulletMissedEventHandler BulletMissedEvent;
        public override void OnBulletMissed(BulletMissedEvent e)
        {
            this.BulletMissedEvent.Invoke(this, e);
        }

        public event DeathEventHandler DeathEvent;
        public override void OnDeath(DeathEvent e)
        {
            this.DeathEvent.Invoke(this, e);
        }

        public event HitByBulletEventHandler HitByBulletEvent;
        public override void OnHitByBullet(HitByBulletEvent e)
        {
            this.HitByBulletEvent.Invoke(this, e);
        }

        public event HitRobotEventHandler HitRobotEvent;
        public override void OnHitRobot(HitRobotEvent e)
        {
            this.HitRobotEvent.Invoke(this, e);
        }

        public event HitWallEventHandler HitWallEvent;
        public override void OnHitWall(HitWallEvent e)
        {
            this.HitWallEvent.Invoke(this, e);
        }

        public event RobotDeathEventHandler RobotDeathEvent;
        public override void OnRobotDeath(RobotDeathEvent e)
        {
            this.RobotDeathEvent.Invoke(this, e);
        }

        public event RoundEndedEventHandler RoundEndedEvent;
        public override void OnRoundEnded(RoundEndedEvent e)
        {
            this.RoundEndedEvent.Invoke(this, e);
        }

        public event ScannedRobotEventHandler ScannedRobotEvent;
        public override void OnScannedRobot(ScannedRobotEvent e)
        {
            this.ScannedRobotEvent.Invoke(this, e);
        }

        public event StatusEventHandler StatusEvent;
        public override void OnStatus(StatusEvent e)
        {
            this.StatusEvent.Invoke(this, e);
        }

        public event WinEventHandler WinEvent;
        public override void OnWin(WinEvent e)
        {
            this.WinEvent.Invoke(this, e);
        }
    }

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
