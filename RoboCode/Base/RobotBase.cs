using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

    public interface IRobotBase : IAdvancedRobot, IAdvancedEvents, IInteractiveRobot, IPaintRobot, IBasicEvents3, IInteractiveEvents, IPaintEvents, IRunnable
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

        // Summary:
        //     Returns the data quota available in your data directory, i.e. the amount
        //     of bytes left in the data directory for the robot.  Robocode.AdvancedRobot.GetDataDirectory()
        //     Robocode.AdvancedRobot.GetDataFile(System.String)
        long DataQuotaAvailable { get; }
        //
        // Summary:
        //     Returns the distance remaining in the robot's current move measured in pixels.
        //      This call returns both positive and negative values. Positive values means
        //     that the robot is currently moving forwards. Negative values means that the
        //     robot is currently moving backwards. If the returned value is 0, the robot
        //     currently stands still.  Robocode.AdvancedRobot.TurnRemaining Robocode.AdvancedRobot.TurnRemainingRadians
        //     Robocode.AdvancedRobot.GunTurnRemaining Robocode.AdvancedRobot.GunTurnRemainingRadians
        //     Robocode.AdvancedRobot.RadarTurnRemaining Robocode.AdvancedRobot.RadarTurnRemainingRadians
        double DistanceRemaining { get; }
        //
        // Summary:
        //     Returns the direction that the robot's gun is facing, in radians.  The value
        //     returned will be between 0 and 2 * PI (is excluded).  Note that the heading
        //     in Robocode is like a compass, where 0 means North, PI / 2 means East, PI
        //     means South, and 3 * PI / 2 means West.  Robocode.Robot.GunHeading Robocode.AdvancedRobot.HeadingRadians
        //     Robocode.AdvancedRobot.RadarHeadingRadians
        double GunHeadingRadians { get; }
        //
        // Summary:
        //     Returns the angle remaining in the gun's turn, in degrees.  This call returns
        //     both positive and negative values.  Positive values means that the gun is
        //     currently turning to the right.  Negative values means that the gun is currently
        //     turning to the left.  If the returned value is 0, the gun is currently not
        //     turning.  Robocode.AdvancedRobot.GunTurnRemainingRadians Robocode.AdvancedRobot.DistanceRemaining
        //     Robocode.AdvancedRobot.TurnRemaining Robocode.AdvancedRobot.TurnRemainingRadians
        //     Robocode.AdvancedRobot.RadarTurnRemaining Robocode.AdvancedRobot.RadarTurnRemainingRadians
        double GunTurnRemaining { get; }
        //
        // Summary:
        //     Returns the angle remaining in the gun's turn, in radians.  This call returns
        //     both positive and negative values. Positive values means that the gun is
        //     currently turning to the right. Negative values means that the gun is currently
        //     turning to the left.  Robocode.AdvancedRobot.GunTurnRemaining Robocode.AdvancedRobot.TurnRemaining
        //     Robocode.AdvancedRobot.TurnRemainingRadians Robocode.AdvancedRobot.RadarTurnRemaining
        //     Robocode.AdvancedRobot.RadarTurnRemainingRadians
        double GunTurnRemainingRadians { get; }
        //
        // Summary:
        //     Returns the direction that the robot's body is facing, in radians.  The value
        //     returned will be between 0 and 2 * PI (is excluded).  Note that the heading
        //     in Robocode is like a compass, where 0 means North, PI / 2 means East, PI
        //     means South, and 3 * PI / 2 means West.  Robocode.Robot.Heading Robocode.AdvancedRobot.GunHeadingRadians
        //     Robocode.AdvancedRobot.RadarHeadingRadians
        double HeadingRadians { get; }
        //
        // Summary:
        //     Call this during an event handler to allow new events of the same priority
        //     to restart the event handler.   override void OnScannedRobot(ScannedRobotEvent
        //     e) { Fire(1); IsInterruptible = true; Ahead(100); // If you see a robot while
        //     moving ahead, // this handler will start from the top // Without IsInterruptible
        //     (true), we wouldn't // receive scan events at all! // We'll only get here
        //     if we don't see a robot during the move.  Out.WriteLine("Ok, I can't see
        //     anyone"); } Robocode.AdvancedRobot.SetEventPriority(System.String,System.Int32)
        //     Robocode.Robot.OnScannedRobot(Robocode.ScannedRobotEvent)
        bool IsInterruptible { set; }
        //
        // Summary:
        //     Sets the maximum turn rate of the robot measured in degrees if the robot
        //     should turn slower than Robocode.Rules.MAX_TURN_RATE (10 degress/turn). 
        //     Robocode.Robot.TurnRight(System.Double) Robocode.Robot.TurnLeft(System.Double)
        //     Robocode.AdvancedRobot.SetTurnRight(System.Double) Robocode.AdvancedRobot.SetTurnLeft(System.Double)
        //     Robocode.AdvancedRobot.MaxVelocity
        double MaxTurnRate { set; }
        //
        // Summary:
        //     Sets the maximum velocity of the robot measured in pixels/turn if the robot
        //     should move slower than Robocode.Rules.MAX_VELOCITY (8 pixels/turn).  Robocode.Robot.Ahead(System.Double)
        //     Robocode.AdvancedRobot.SetAhead(System.Double) Robocode.Robot.Back(System.Double)
        //     Robocode.AdvancedRobot.SetBack(System.Double) Robocode.AdvancedRobot.MaxTurnRate
        double MaxVelocity { set; }
        //
        // Summary:
        //     Returns the direction that the robot's radar is facing, in radians.  The
        //     value returned will be between 0 and 2 * PI (is excluded).  Note that the
        //     heading in Robocode is like a compass, where 0 means North, PI / 2 means
        //     East, PI means South, and 3 * PI / 2 means West.  Robocode.Robot.RadarHeading
        //     Robocode.AdvancedRobot.HeadingRadians Robocode.AdvancedRobot.GunHeadingRadians
        double RadarHeadingRadians { get; }
        //
        // Summary:
        //     Returns the angle remaining in the radar's turn, in degrees.  This call returns
        //     both positive and negative values.  Positive values means that the radar
        //     is currently turning to the right.  Negative values means that the radar
        //     is currently turning to the left.  If the returned value is 0, the radar
        //     is currently not turning.  Robocode.AdvancedRobot.RadarTurnRemainingRadians
        //     Robocode.AdvancedRobot.DistanceRemaining Robocode.AdvancedRobot.GunTurnRemaining
        //     Robocode.AdvancedRobot.GunTurnRemainingRadians Robocode.AdvancedRobot.RadarTurnRemaining
        //     Robocode.AdvancedRobot.RadarTurnRemainingRadians
        double RadarTurnRemaining { get; }
        //
        // Summary:
        //     Returns the angle remaining in the radar's turn, in radians.  This call returns
        //     both positive and negative values. Positive values means that the radar is
        //     currently turning to the right. Negative values means that the radar is currently
        //     turning to the left.  Robocode.AdvancedRobot.RadarTurnRemaining Robocode.AdvancedRobot.TurnRemaining
        //     Robocode.AdvancedRobot.TurnRemainingRadians Robocode.AdvancedRobot.GunTurnRemaining
        //     Robocode.AdvancedRobot.GunTurnRemainingRadians
        double RadarTurnRemainingRadians { get; }
        //
        // Summary:
        //     Returns the angle remaining in the robots's turn, in degrees.  This call
        //     returns both positive and negative values.  Positive values means that the
        //     robot is currently turning to the right.  Negative values means that the
        //     robot is currently turning to the left.  If the returned value is 0, the
        //     robot is currently not turning.  Robocode.AdvancedRobot.TurnRemainingRadians
        //     Robocode.AdvancedRobot.DistanceRemaining Robocode.AdvancedRobot.GunTurnRemaining
        //     Robocode.AdvancedRobot.GunTurnRemainingRadians Robocode.AdvancedRobot.RadarTurnRemaining
        //     Robocode.AdvancedRobot.RadarTurnRemainingRadians
        double TurnRemaining { get; }
        //
        // Summary:
        //     Returns the angle remaining in the robot's turn, in radians.  This call returns
        //     both positive and negative values. Positive values means that the robot is
        //     currently turning to the right. Negative values means that the robot is currently
        //     turning to the left.  Robocode.AdvancedRobot.TurnRemaining Robocode.AdvancedRobot.GunTurnRemaining
        //     Robocode.AdvancedRobot.GunTurnRemainingRadians Robocode.AdvancedRobot.RadarTurnRemaining
        //     Robocode.AdvancedRobot.RadarTurnRemainingRadians
        double TurnRemainingRadians { get; }

        // Summary:
        //     Registers a custom event to be called when a condition is met.  When you
        //     are finished with your condition or just want to remove it you must call
        //     Robocode.AdvancedRobot.RemoveCustomEvent(Robocode.Condition).  // Create
        //     the condition for our custom event Condition triggerHitCondition = new Condition("triggerhit")
        //     {  bool Test() { return (Energy <= trigger); } } // Add our custom
        //     event based on our condition AddCustomEvent(triggerHitCondition); Robocode.Condition
        //     Robocode.AdvancedRobot.RemoveCustomEvent(Robocode.Condition)
        //
        // Parameters:
        //   condition:
        //     The condition that must be met.  Throws ArgumentException if the condition
        //     parameter has been set to null.
        void AddCustomEvent(Condition condition);
        //
        // Summary:
        //     Same as Robocode.AdvancedRobot.AddCustomEvent(Robocode.Condition), but alows
        //     to define condition as anonymous method.
        void AddCustomEvent(string name, int priority, ConditionTest test);
        //
        // Summary:
        //     Clears Out any pending events in the robot's event queue immediately.  Robocode.AdvancedRobot.GetAllEvents()
        void ClearAllEvents();
        //
        // Summary:
        //     Executes any pending actions, or continues executing actions that are in
        //     process. This call returns after the actions have been started.  Note that
        //     advanced robots must call this function in order to Execute pending set*
        //     calls like e.g. Robocode.AdvancedRobot.SetAhead(System.Double), Robocode.AdvancedRobot.SetFire(System.Double),
        //     Robocode.AdvancedRobot.SetTurnLeft(System.Double) etc.  Otherwise, these
        //     calls will never get executed.  In this example the robot will move while
        //     turning: SetTurnRight(90); SetAhead(100); Execute(); while (DistanceRemaining
        //     > 0 && TurnRemaining > 0) { Execute(); }
        void Execute();
        //
        // Summary:
        //     Returns a list containing all events currently in the robot's queue.  You
        //     might, for example, call this while processing another event.  for (Event
        //     evnt : GetAllEvents()) { if (evnt is HitRobotEvent) { // do something with
        //     the event } else if (evnt is HitByBulletEvent) { // do something with the
        //     event } } Robocode.Event Robocode.AdvancedRobot.ClearAllEvents() Robocode.AdvancedRobot.GetStatusEvents()
        //     Robocode.AdvancedRobot.GetScannedRobotEvents() Robocode.AdvancedRobot.GetBulletHitEvents()
        //     Robocode.AdvancedRobot.GetBulletMissedEvents() Robocode.AdvancedRobot.GetBulletHitBulletEvents()
        //     Robocode.AdvancedRobot.GetRobotDeathEvents()
        IList<Event> GetAllEvents();
        //
        // Summary:
        //     Returns a list containing all BulletHitBulletEvents currently in the robot's
        //     queue. You might, for example, call this while processing another event.
        //      for (BulletHitBulletEvent evnt : GetBulletHitBulletEvents()) { // do something
        //     with the event } Robocode.Robot.OnBulletHitBullet(Robocode.BulletHitBulletEvent)
        //     Robocode.BulletHitBulletEvent Robocode.AdvancedRobot.GetAllEvents()
        IList<BulletHitBulletEvent> GetBulletHitBulletEvents();
        //
        // Summary:
        //     Returns a list containing all BulletHitEvents currently in the robot's queue.
        //     You might, for example, call this while processing another event.  for (BulletHitEvent
        //     event: GetBulletHitEvents()) { // do something with the event } Robocode.Robot.OnBulletHit(Robocode.BulletHitEvent)
        //     Robocode.BulletHitEvent Robocode.AdvancedRobot.GetAllEvents()
        IList<BulletHitEvent> GetBulletHitEvents();
        //
        // Summary:
        //     Returns a list containing all BulletMissedEvents currently in the robot's
        //     queue. You might, for example, call this while processing another event.
        //      for (BulletMissedEvent evnt : GetBulletMissedEvents()) { // do something
        //     with the event } Robocode.Robot.OnBulletMissed(Robocode.BulletMissedEvent)
        //     Robocode.BulletMissedEvent Robocode.AdvancedRobot.GetAllEvents()
        IList<BulletMissedEvent> GetBulletMissedEvents();
        //
        // Summary:
        //     Returns a file representing a data directory for the robot.  The system will
        //     automatically create the directory for you, so you do not need to create
        //     it by yourself.  Robocode.AdvancedRobot.GetDataFile(System.String)
        string GetDataDirectory();
        //
        // Summary:
        //     Returns a file in your data directory that you can write to.  The system
        //     will automatically create the directory for you, so you do not need to create
        //     it by yourself.  Please notice that the max. size of your data file is set
        //     to 200000 bytes (~195 KB).  See the Sample.SittingDuck to see an example
        //     of how to use this method.  Robocode.AdvancedRobot.GetDataDirectory()
        //
        // Parameters:
        //   filename:
        //     The file name of the data file for your robot
        Stream GetDataFile(string filename);
        //
        // Summary:
        //     Returns the current priority of a class of events.  An event priority is
        //     a value from 0 - 99. The higher value, the higher priority.  int myHitRobotPriority
        //     = GetEventPriority("HitRobotEvent"); The default priorities are, from highest
        //     to lowest: Robocode.BattleEndedEvent: 100 (reserved) Robocode.WinEvent: 100
        //     (reserved) Robocode.SkippedTurnEvent: 100 (reserved) Robocode.StatusEvent:
        //     99 Key and mouse events: 98 Robocode.CustomEvent: 80 (default value) Robocode.MessageEvent:
        //     75 Robocode.RobotDeathEvent: 70 Robocode.BulletMissedEvent: 60 Robocode.BulletHitBulletEvent:
        //     55 Robocode.BulletHitEvent: 50 Robocode.HitByBulletEvent: 40 Robocode.HitWallEvent:
        //     30 Robocode.HitRobotEvent: 20 Robocode.ScannedRobotEvent: 10 Robocode.PaintEvent:
        //     5 Robocode.DeathEvent: -1 (reserved) Robocode.AdvancedRobot.SetEventPriority(System.String,System.Int32)
        //
        // Parameters:
        //   eventClass:
        //     the name of the event class (string)
        int GetEventPriority(string eventClass);
        //
        // Summary:
        //     Returns a list containing all HitByBulletEvents currently in the robot's
        //     queue. You might, for example, call this while processing another event.
        //      for (HitByBulletEvent evnt : GetHitByBulletEvents()) { // do something with
        //     the event } Robocode.Robot.OnHitByBullet(Robocode.HitByBulletEvent) Robocode.HitByBulletEvent
        //     Robocode.AdvancedRobot.GetAllEvents()
        IList<HitByBulletEvent> GetHitByBulletEvents();
        //
        // Summary:
        //     Returns a list containing all HitRobotEvents currently in the robot's queue.
        //     You might, for example, call this while processing another event.  for (HitRobotEvent
        //     evnt : GetHitRobotEvents()) { // do something with the event } Robocode.Robot.OnHitRobot(Robocode.HitRobotEvent)
        //     Robocode.HitRobotEvent Robocode.AdvancedRobot.GetAllEvents()
        IList<HitRobotEvent> GetHitRobotEvents();
        //
        // Summary:
        //     Returns a list containing all HitWallEvents currently in the robot's queue.
        //     You might, for example, call this while processing another event.  for (HitWallEvent
        //     evnt : GetHitWallEvents()) { // do something with the event } Robocode.Robot.OnHitWall(Robocode.HitWallEvent)
        //     Robocode.HitWallEvent Robocode.AdvancedRobot.GetAllEvents()
        IList<HitWallEvent> GetHitWallEvents();
        //
        // Summary:
        //     Returns a list containing all RobotDeathEvents currently in the robot's queue.
        //     You might, for example, call this while processing another event.  for (RobotDeathEvent
        //     evnt : GetRobotDeathEvents()) { // do something with the event } Robocode.Robot.OnRobotDeath(Robocode.RobotDeathEvent)
        //     Robocode.RobotDeathEvent Robocode.AdvancedRobot.GetAllEvents()
        IList<RobotDeathEvent> GetRobotDeathEvents();
        //
        // Summary:
        //     Returns a list containing all ScannedRobotEvents currently in the robot's
        //     queue.  You might, for example, call this while processing another event.
        //      for (ScannedRobotEvent evnt : GetScannedRobotEvents()) { // do something
        //     with the event } Robocode.Robot.OnScannedRobot(Robocode.ScannedRobotEvent)
        //     Robocode.ScannedRobotEvent Robocode.AdvancedRobot.GetAllEvents()
        IList<ScannedRobotEvent> GetScannedRobotEvents();
        //
        // Summary:
        //     Returns a list containing all StatusEvents currently in the robot's queue.
        //     You might, for example, call this while processing another event.  for (StatusEvent
        //     evnt : GetStatusEvents()) { // do something with the event } Robocode.Robot.OnStatus(Robocode.StatusEvent)
        //     Robocode.StatusEvent Robocode.AdvancedRobot.GetAllEvents()
        IList<StatusEvent> GetStatusEvents();
        //

        //
        // Summary:
        //     This method is called if your robot dies.  You should override it in your
        //     robot if you want to be informed of this event. Actions will have no effect
        //     if called from this section. The intent is to allow you to perform calculations
        //     or print something out when the robot is killed.  Robocode.DeathEvent Robocode.Event
        //
        // Parameters:
        //   evnt:
        //     the death event set by the game
        void OnDeath(DeathEvent evnt);

        //
        // Summary:
        //     Removes a custom event that was previously added by calling Robocode.AdvancedRobot.AddCustomEvent(Robocode.Condition).
        //      // Create the condition for our custom event Condition triggerHitCondition
        //     = new Condition("triggerhit") {  bool Test() { return (Energy <= trigger);
        //     } } // Add our custom event based on our condition AddCustomEvent(triggerHitCondition);
        //     ...  // do something with your robot ...  // Remove the custom event based
        //     on our condition RemoveCustomEvent(triggerHitCondition); Robocode.Condition
        //     Robocode.AdvancedRobot.AddCustomEvent(Robocode.Condition)
        //
        // Parameters:
        //   condition:
        //     The condition that was previous added and that must be removed now.
        void RemoveCustomEvent(Condition condition);
        //
        // Summary:
        //     Sets the robot to move ahead (forward) by distance measured in pixels when
        //     the next execution takes place.  This call returns immediately, and will
        //     not execute until you call Robocode.AdvancedRobot.Execute() or take an action
        //     that executes.  Note that both positive and negative values can be given
        //     as input, where positive values means that the robot is set to move ahead,
        //     and negative values means that the robot is set to move back. If 0 is given
        //     as input, the robot will stop its movement, but will have to decelerate till
        //     it stands still, and will thus not be able to stop its movement immediately,
        //     but eventually.
        //
        // Parameters:
        //   distance:
        //     The distance to move measured in pixels.  If distance > 0 the robot is set
        //     to move ahead.  If distance < 0 the robot is set to move back.  If distance
        //     = 0 the robot is set to stop its movement.
        void SetAhead(double distance);
        //
        // Summary:
        //     Sets the robot to move back by distance measured in pixels when the next
        //     execution takes place.  This call returns immediately, and will not execute
        //     until you call Robocode.AdvancedRobot.Execute() or take an action that executes.
        //      Note that both positive and negative values can be given as input, where
        //     positive values means that the robot is set to move back, and negative values
        //     means that the robot is set to move ahead. If 0 is given as input, the robot
        //     will stop its movement, but will have to decelerate till it stands still,
        //     and will thus not be able to stop its movement immediately, but eventually.
        //      // Set the robot to move 50 pixels back SetBack(50); // Set the robot to
        //     move 100 pixels ahead // (overrides the previous order) SetBack(-100); ...
        //      // Executes the last SetBack() Execute(); Robocode.Robot.Back(System.Double)
        //     Robocode.Robot.Ahead(System.Double) Robocode.AdvancedRobot.SetAhead(System.Double)
        //
        // Parameters:
        //   distance:
        //     The distance to move measured in pixels.  If distance > 0 the robot is set
        //     to move back.  If distance < 0 the robot is set to move ahead.  If distance
        //     = 0 the robot is set to stop its movement.
        void SetBack(double distance);
        //
        // Summary:
        //     Sets the priority of a class of events.  Events are sent to the onXXX handlers
        //     in order of priority.  Higher priority events can interrupt lower priority
        //     events.  For events with the same priority, newer events are always sent
        //     first.  Valid priorities are 0 - 99, where 100 is reserved and 80 is the
        //     default priority.  SetEventPriority("RobotDeathEvent", 15); The default priorities
        //     are, from highest to lowest: Robocode.WinEvent: 100 (reserved) Robocode.SkippedTurnEvent:
        //     100 (reserved) Robocode.StatusEvent: 99 Robocode.CustomEvent: 80 Robocode.MessageEvent:
        //     75 Robocode.RobotDeathEvent: 70 Robocode.BulletMissedEvent: 60 Robocode.BulletHitBulletEvent:
        //     55 Robocode.BulletHitEvent: 50 Robocode.HitByBulletEvent: 40 Robocode.HitWallEvent:
        //     30 Robocode.HitRobotEvent: 20 Robocode.ScannedRobotEvent: 10 Robocode.PaintEvent:
        //     5 Robocode.DeathEvent: -1 (reserved) Note that you cannot change the priority
        //     for events with the special priority value -1 or 100 (reserved) as these
        //     events are system events.  Also note that you cannot change the priority
        //     of CustomEvent.  Instead you must change the priority of the condition(s)
        //     for your custom event(s).  Robocode.AdvancedRobot.GetEventPriority(System.String)
        //
        // Parameters:
        //   eventClass:
        //     The name of the event class (string) to set the priority for
        //
        //   priority:
        //     The new priority for that event class
        void SetEventPriority(string eventClass, int priority);
        //
        // Summary:
        //     Sets the gun to Fire a bullet when the next execution takes place.  The bullet
        //     will travel in the direction the gun is pointing.  This call returns immediately,
        //     and will not execute until you call Execute() or take an action that executes.
        //      The specified bullet power is an amount of energy that will be taken from
        //     the robot's energy. Hence, the more power you want to spend on the bullet,
        //     the more energy is taken from your robot.  The bullet will do (4 * power)
        //     damage if it hits another robot. If power is greater than 1, it will do an
        //     additional 2 * (power - 1) damage.  You will get (3 * power) back if you
        //     hit the other robot. You can call Rules.GetBulletDamage(double)} for getting
        //     the damage that a bullet with a specific bullet power will do.  The specified
        //     bullet power should be between Robocode.Rules.MIN_BULLET_POWER and Robocode.Rules.MAX_BULLET_POWER.
        //      Note that the gun cannot Fire if the gun is overheated, meaning that Robocode.Robot.GunHeat
        //     returns a value > 0.  An event is generated when the bullet hits a robot,
        //     wall, or another bullet.  // Fire a bullet with maximum power if the gun
        //     is ready if (GunGeat == 0) { SetFire(Rules.MAX_BULLET_POWER); } ...  Execute();
        //     Robocode.AdvancedRobot.SetFireBullet(System.Double) Robocode.Robot.Fire(System.Double)
        //     Robocode.Robot.FireBullet(System.Double) Robocode.Robot.GunHeat Robocode.Robot.GunCoolingRate
        //     Robocode.Robot.OnBulletHit(Robocode.BulletHitEvent) Robocode.Robot.OnBulletHitBullet(Robocode.BulletHitBulletEvent)
        //     Robocode.Robot.OnBulletMissed(Robocode.BulletMissedEvent)
        //
        // Parameters:
        //   power:
        //     The amount of energy given to the bullet, and subtracted from the robot's
        //     energy.
        void SetFire(double power);
        //
        // Summary:
        //     Sets the gun to Fire a bullet when the next execution takes place.  The bullet
        //     will travel in the direction the gun is pointing.  This call returns immediately,
        //     and will not execute until you call Execute() or take an action that executes.
        //      The specified bullet power is an amount of energy that will be taken from
        //     the robot's energy. Hence, the more power you want to spend on the bullet,
        //     the more energy is taken from your robot.  The bullet will do (4 * power)
        //     damage if it hits another robot. If power is greater than 1, it will do an
        //     additional 2 * (power - 1) damage.  You will get (3 * power) back if you
        //     hit the other robot. You can call Robocode.Rules.GetBulletDamage(System.Double)
        //     for getting the damage that a bullet with a specific bullet power will do.
        //      The specified bullet power should be between Robocode.Rules.MIN_BULLET_POWER
        //     and Robocode.Rules.MAX_BULLET_POWER.  Note that the gun cannot Fire if the
        //     gun is overheated, meaning that Robocode.Robot.GunHeat returns a value >
        //     0.  An event is generated when the bullet hits a robot (Robocode.BulletHitEvent),
        //     wall (Robocode.BulletMissedEvent), or another bullet (Robocode.BulletHitBulletEvent).
        //      Bullet bullet = null; // Fire a bullet with maximum power if the gun is
        //     ready if (GunHeat == 0) { bullet = SetFireBullet(Rules.MAX_BULLET_POWER);
        //     } ...  Execute(); ...  // Get the velocity of the bullet if (bullet != null)
        //     { double bulletVelocity = bullet.Velocity; } Robocode.AdvancedRobot.SetFire(System.Double)
        //     Robocode.Bullet Robocode.Robot.Fire(System.Double) Robocode.Robot.FireBullet(System.Double)
        //     Robocode.Robot.GunHeat Robocode.Robot.GunCoolingRate Robocode.Robot.OnBulletHit(Robocode.BulletHitEvent)
        //     Robocode.Robot.OnBulletHitBullet(Robocode.BulletHitBulletEvent) Robocode.Robot.OnBulletMissed(Robocode.BulletMissedEvent)
        //
        // Parameters:
        //   power:
        //     The amount of energy given to the bullet, and subtracted from the robot's
        //     energy.
        Bullet SetFireBullet(double power);
        //
        // Summary:
        //     Sets the robot to resume the movement stopped by Robocode.Robot.Stop() or
        //     Robocode.AdvancedRobot.SetStop(), if any.  This call returns immediately,
        //     and will not execute until you call Robocode.AdvancedRobot.Execute() or take
        //     an action that executes.  Robocode.Robot.Resume() Robocode.Robot.Stop() Robocode.Robot.Stop(System.Boolean)
        //     Robocode.AdvancedRobot.SetStop() Robocode.AdvancedRobot.SetStop(System.Boolean)
        //     Robocode.AdvancedRobot.Execute()
        void SetResume();
        //
        // Summary:
        //     This call is identical to Robocode.Robot.Stop(), but returns immediately,
        //     and will not execute until you call Robocode.AdvancedRobot.Execute() or take
        //     an action that executes.  If there is already movement saved from a previous
        //     stop, this will have no effect.  This call is equivalent to calling SetStop(false);
        //     Robocode.Robot.Stop() Robocode.Robot.Stop(System.Boolean) Robocode.Robot.Resume()
        //     Robocode.AdvancedRobot.SetResume() Robocode.AdvancedRobot.SetStop(System.Boolean)
        //     Robocode.AdvancedRobot.Execute()
        void SetStop();
        //
        // Summary:
        //     This call is identical to Robocode.Robot.Stop(System.Boolean), but returns
        //     immediately, and will not execute until you call Robocode.AdvancedRobot.Execute()
        //     or take an action that executes.  If there is already movement saved from
        //     a previous stop, you can overwrite it by calling SetStop(true).  Robocode.Robot.Stop()
        //     Robocode.Robot.Stop(System.Boolean) Robocode.Robot.Resume() Robocode.AdvancedRobot.SetResume()
        //     Robocode.AdvancedRobot.SetStop() Robocode.AdvancedRobot.Execute()
        //
        // Parameters:
        //   overwrite:
        //     true if the movement saved from a previous stop should be overwritten; false
        //     otherwise.
        void SetStop(bool overwrite);
        //
        // Summary:
        //     Sets the robot's gun to turn left by degrees when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     gun is set to turn right instead of left.  // Set the gun to turn 180 degrees
        //     to the left SetTurnGunLeft(180); // Set the gun to turn 90 degrees to the
        //     right instead of left // (overrides the previous order) SetTurnGunLeft(-90);
        //     ...  // Executes the last SetTurnGunLeft() Execute(); Robocode.AdvancedRobot.SetTurnGunLeftRadians(System.Double)
        //     Robocode.Robot.TurnGunLeft(System.Double) Robocode.AdvancedRobot.TurnGunLeftRadians(System.Double)
        //     Robocode.Robot.TurnGunRight(System.Double) Robocode.AdvancedRobot.TurnGunRightRadians(System.Double)
        //     Robocode.AdvancedRobot.SetTurnGunRight(System.Double) Robocode.AdvancedRobot.SetTurnGunRightRadians(System.Double)
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's gun to the left.  If degrees >
        //     0 the robot's gun is set to turn left.  If degrees < 0 the robot's gun is
        //     set to turn right.  If degrees = 0 the robot's gun is set to stop turning.
        void SetTurnGunLeft(double degrees);
        //
        // Summary:
        //     Sets the robot's gun to turn left by radians when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     gun is set to turn right instead of left.  // Set the gun to turn 180 degrees
        //     to the left SetTurnGunLeftRadians(Math.PI); // Set the gun to turn 90 degrees
        //     to the right instead of left // (overrides the previous order) SetTurnGunLeftRadians(-Math.PI
        //     / 2); ...  // Executes the last SetTurnGunLeftRadians() Execute(); Robocode.AdvancedRobot.SetTurnGunLeft(System.Double)
        //     Robocode.Robot.TurnGunLeft(System.Double) Robocode.AdvancedRobot.TurnGunLeftRadians(System.Double)
        //     Robocode.Robot.TurnGunRight(System.Double) Robocode.AdvancedRobot.TurnGunRightRadians(System.Double)
        //     Robocode.AdvancedRobot.SetTurnGunRight(System.Double) Robocode.AdvancedRobot.SetTurnGunRightRadians(System.Double)
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's gun to the left.  If radians >
        //     0 the robot's gun is set to turn left.  If radians < 0 the robot's gun is
        //     set to turn right.  If radians = 0 the robot's gun is set to stop turning.
        void SetTurnGunLeftRadians(double radians);
        //
        // Summary:
        //     Sets the robot's gun to turn right by degrees when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     gun is set to turn left instead of right.  // Set the gun to turn 180 degrees
        //     to the right SetTurnGunRight(180); // Set the gun to turn 90 degrees to the
        //     left instead of right // (overrides the previous order) SetTurnGunRight(-90);
        //     ...  // Executes the last SetTurnGunRight() Execute(); Robocode.AdvancedRobot.SetTurnGunRightRadians(System.Double)
        //     Robocode.Robot.TurnGunRight(System.Double) Robocode.AdvancedRobot.TurnGunRightRadians(System.Double)
        //     Robocode.Robot.TurnGunLeft(System.Double) Robocode.AdvancedRobot.TurnGunLeftRadians(System.Double)
        //     Robocode.AdvancedRobot.SetTurnGunLeft(System.Double) Robocode.AdvancedRobot.SetTurnGunLeftRadians(System.Double)
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's gun to the right.  If degrees >
        //     0 the robot's gun is set to turn right.  If degrees < 0 the robot's gun is
        //     set to turn left.  If degrees = 0 the robot's gun is set to stop turning.
        void SetTurnGunRight(double degrees);
        //
        // Summary:
        //     Sets the robot's gun to turn right by radians when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     gun is set to turn left instead of right.  // Set the gun to turn 180 degrees
        //     to the right SetTurnGunRightRadians(Math.PI); // Set the gun to turn 90 degrees
        //     to the left instead of right // (overrides the previous order) SetTurnGunRightRadians(-Math.PI
        //     / 2); ...  // Executes the last SetTurnGunRightRadians() Execute(); Robocode.AdvancedRobot.SetTurnGunRight(System.Double)
        //     Robocode.Robot.TurnGunRight(System.Double) Robocode.AdvancedRobot.TurnGunRightRadians(System.Double)
        //     Robocode.Robot.TurnGunLeft(System.Double) Robocode.AdvancedRobot.TurnGunLeftRadians(System.Double)
        //     Robocode.AdvancedRobot.SetTurnGunLeft(System.Double) Robocode.AdvancedRobot.SetTurnGunLeftRadians(System.Double)
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's gun to the right.  If radians >
        //     0 the robot's gun is set to turn left.  If radians < 0 the robot's gun is
        //     set to turn right.  If radians = 0 the robot's gun is set to stop turning.
        void SetTurnGunRightRadians(double radians);
        //
        // Summary:
        //     Sets the robot's body to turn left by degrees when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     body is set to turn right instead of left.  // Set the robot to turn 180
        //     degrees to the left SetTurnLeft(180); // Set the robot to turn 90 degrees
        //     to the right instead of left // (overrides the previous order) SetTurnLeft(-90);
        //     ...  // Executes the last SetTurnLeft() Execute(); Robocode.AdvancedRobot.SetTurnLeftRadians(System.Double)
        //     Robocode.Robot.TurnLeft(System.Double) Robocode.AdvancedRobot.TurnLeftRadians(System.Double)
        //     Robocode.Robot.TurnRight(System.Double) Robocode.AdvancedRobot.TurnRightRadians(System.Double)
        //     Robocode.AdvancedRobot.SetTurnRight(System.Double) Robocode.AdvancedRobot.SetTurnRightRadians(System.Double)
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's body to the left.  If degrees >
        //     0 the robot is set to turn left.  If degrees < 0 the robot is set to turn
        //     right.  If degrees = 0 the robot is set to stop turning.
        void SetTurnLeft(double degrees);
        //
        // Summary:
        //     Sets the robot's body to turn left by radians when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     body is set to turn right instead of left.  // Set the robot to turn 180
        //     degrees to the left SetTurnLeftRadians(Math.PI); // Set the robot to turn
        //     90 degrees to the right instead of left // (overrides the previous order)
        //     SetTurnLeftRadians(-Math.PI / 2); ...  // Executes the last SetTurnLeftRadians()
        //     Execute(); Robocode.AdvancedRobot.SetTurnLeft(System.Double) Robocode.Robot.TurnLeft(System.Double)
        //     Robocode.AdvancedRobot.TurnLeftRadians(System.Double) Robocode.Robot.TurnRight(System.Double)
        //     Robocode.AdvancedRobot.TurnRightRadians(System.Double) Robocode.AdvancedRobot.SetTurnRight(System.Double)
        //     Robocode.AdvancedRobot.SetTurnRightRadians(System.Double)
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's body to the left.  If radians >
        //     0 the robot is set to turn left.  If radians < 0 the robot is set to turn
        //     right.  If radians = 0 the robot is set to stop turning.
        void SetTurnLeftRadians(double radians);
        //
        // Summary:
        //     Sets the robot's radar to turn left by degrees when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     radar is set to turn right instead of left.  // Set the radar to turn 180
        //     degrees to the left SetTurnRadarLeft(180); // Set the radar to turn 90 degrees
        //     to the right instead of left // (overrides the previous order) SetTurnRadarLeft(-90);
        //     ...  // Executes the last SetTurnRadarLeft() Execute(); Robocode.AdvancedRobot.SetTurnRadarLeftRadians(System.Double)
        //     Robocode.Robot.TurnRadarLeft(System.Double) Robocode.AdvancedRobot.TurnRadarLeftRadians(System.Double)
        //     Robocode.Robot.TurnRadarRight(System.Double) Robocode.AdvancedRobot.TurnRadarRightRadians(System.Double)
        //     Robocode.AdvancedRobot.SetTurnRadarRight(System.Double) Robocode.AdvancedRobot.SetTurnRadarRightRadians(System.Double)
        //     Robocode.Robot.IsAdjustRadarForRobotTurn Robocode.Robot.IsAdjustRadarForGunTurn
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's radar to the left.  If degrees
        //     > 0 the robot's radar is set to turn left.  If degrees < 0 the robot's radar
        //     is set to turn right.  If degrees = 0 the robot's radar is set to stop turning.
        void SetTurnRadarLeft(double degrees);
        //
        // Summary:
        //     Sets the robot's radar to turn left by radians when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     radar is set to turn right instead of left.  // Set the radar to turn 180
        //     degrees to the left SetTurnRadarLeftRadians(Math.PI); // Set the radar to
        //     turn 90 degrees to the right instead of left // (overrides the previous order)
        //     SetTurnRadarLeftRadians(-Math.PI / 2); ...  // Executes the last SetTurnRadarLeftRadians()
        //     Execute(); Robocode.AdvancedRobot.SetTurnRadarLeft(System.Double) Robocode.Robot.TurnRadarLeft(System.Double)
        //     Robocode.AdvancedRobot.TurnRadarLeftRadians(System.Double) Robocode.Robot.TurnRadarRight(System.Double)
        //     Robocode.AdvancedRobot.TurnRadarRightRadians(System.Double) Robocode.AdvancedRobot.SetTurnRadarRight(System.Double)
        //     Robocode.AdvancedRobot.SetTurnRadarRightRadians(System.Double) Robocode.Robot.IsAdjustRadarForRobotTurn
        //     Robocode.Robot.IsAdjustRadarForGunTurn
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's radar to the left.  If radians
        //     > 0 the robot's radar is set to turn left.  If radians < 0 the robot's radar
        //     is set to turn right.  If radians = 0 the robot's radar is set to stop turning.
        void SetTurnRadarLeftRadians(double radians);
        //
        // Summary:
        //     Sets the robot's radar to turn right by degrees when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     radar is set to turn left instead of right.  // Set the radar to turn 180
        //     degrees to the right SetTurnRadarRight(180); // Set the radar to turn 90
        //     degrees to the right instead of right // (overrides the previous order) SetTurnRadarRight(-90);
        //     ...  // Executes the last SetTurnRadarRight() Execute(); Robocode.AdvancedRobot.SetTurnRadarRightRadians(System.Double)
        //     Robocode.Robot.TurnRadarRight(System.Double) Robocode.AdvancedRobot.TurnRadarRightRadians(System.Double)
        //     Robocode.Robot.TurnRadarLeft(System.Double) Robocode.AdvancedRobot.TurnRadarLeftRadians(System.Double)
        //     Robocode.AdvancedRobot.SetTurnRadarLeft(System.Double) Robocode.AdvancedRobot.SetTurnRadarLeftRadians(System.Double)
        //     Robocode.Robot.IsAdjustRadarForRobotTurn Robocode.Robot.IsAdjustRadarForGunTurn
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's radar to the rright.  If degrees
        //     > 0 the robot's radar is set to turn right.  If degrees < 0 the robot's radar
        //     is set to turn left.  If degrees = 0 the robot's radar is set to stop turning.
        void SetTurnRadarRight(double degrees);
        //
        // Summary:
        //     Sets the robot's radar to turn right by radians when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     radar is set to turn left instead of right.  // Set the radar to turn 180
        //     degrees to the right SetTurnRadarRightRadians(Math.PI); // Set the radar
        //     to turn 90 degrees to the right instead of right // (overrides the previous
        //     order) SetTurnRadarRightRadians(-Math.PI / 2); ...  // Executes the last
        //     SetTurnRadarRightRadians() Execute(); Robocode.AdvancedRobot.SetTurnRadarRight(System.Double)
        //     Robocode.Robot.TurnRadarRight(System.Double) Robocode.AdvancedRobot.TurnRadarRightRadians(System.Double)
        //     Robocode.Robot.TurnRadarLeft(System.Double) Robocode.AdvancedRobot.TurnRadarLeftRadians(System.Double)
        //     Robocode.AdvancedRobot.SetTurnRadarLeft(System.Double) Robocode.AdvancedRobot.SetTurnRadarLeftRadians(System.Double)
        //     Robocode.Robot.IsAdjustRadarForRobotTurn Robocode.Robot.IsAdjustRadarForGunTurn
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's radar to the right.  If radians
        //     > 0 the robot's radar is set to turn left.  If radians < 0 the robot's radar
        //     is set to turn right.  If radians = 0 the robot's radar is set to stop turning.
        void SetTurnRadarRightRadians(double radians);
        //
        // Summary:
        //     Sets the robot's body to turn right by degrees when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     body is set to turn left instead of right.  // Set the robot to turn 180
        //     degrees to the right SetTurnRight(180); // Set the robot to turn 90 degrees
        //     to the left instead of right // (overrides the previous order) SetTurnRight(-90);
        //     ...  // Executes the last SetTurnRight() Execute(); Robocode.AdvancedRobot.SetTurnRightRadians(System.Double)
        //     Robocode.Robot.TurnRight(System.Double) Robocode.AdvancedRobot.TurnRightRadians(System.Double)
        //     Robocode.Robot.TurnLeft(System.Double) Robocode.AdvancedRobot.TurnLeftRadians(System.Double)
        //     Robocode.AdvancedRobot.SetTurnLeft(System.Double) Robocode.AdvancedRobot.SetTurnLeftRadians(System.Double)
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's body to the right.  If degrees
        //     > 0 the robot is set to turn right.  If degrees < 0 the robot is set to turn
        //     left.  If degrees = 0 the robot is set to stop turning.
        void SetTurnRight(double degrees);
        //
        // Summary:
        //     Sets the robot's body to turn right by radians when the next execution takes
        //     place.  This call returns immediately, and will not execute until you call
        //     Execute() or take an action that executes.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     body is set to turn left instead of right.  // Set the robot to turn 180
        //     degrees to the right SetTurnRightRadians(Math.PI); // Set the robot to turn
        //     90 degrees to the left instead of right // (overrides the previous order)
        //     SetTurnRightRadians(-Math.PI / 2); ...  // Executes the last SetTurnRightRadians()
        //     Execute(); Robocode.AdvancedRobot.SetTurnRight(System.Double) Robocode.Robot.TurnRight(System.Double)
        //     Robocode.AdvancedRobot.TurnRightRadians(System.Double) Robocode.Robot.TurnLeft(System.Double)
        //     Robocode.AdvancedRobot.TurnLeftRadians(System.Double) Robocode.AdvancedRobot.SetTurnLeft(System.Double)
        //     Robocode.AdvancedRobot.SetTurnLeftRadians(System.Double)
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's body to the right.  If radians
        //     > 0 the robot is set to turn right.  If radians < 0 the robot is set to turn
        //     left.  If radians = 0 the robot is set to stop turning.
        void SetTurnRightRadians(double radians);
        //
        // Summary:
        //     Immediately turns the robot's gun to the left by radians.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the gun's turn is 0.  Note that both positive and negative values
        //     can be given as input, where negative values means that the robot's gun is
        //     set to turn right instead of left.  // Turn the robot's gun 180 degrees to
        //     the left TurnGunLeftRadians(Math.PI); // Afterwards, turn the robot's gun
        //     90 degrees to the right TurnGunLeftRadians(-Math.PI / 2); Robocode.Robot.TurnGunLeft(System.Double)
        //     Robocode.Robot.TurnGunRight(System.Double) Robocode.AdvancedRobot.TurnGunRightRadians(System.Double)
        //     Robocode.Robot.TurnLeft(System.Double) Robocode.AdvancedRobot.TurnLeftRadians(System.Double)
        //     Robocode.Robot.TurnRight(System.Double) Robocode.AdvancedRobot.TurnRightRadians(System.Double)
        //     Robocode.Robot.TurnRadarLeft(System.Double) Robocode.AdvancedRobot.TurnRadarLeftRadians(System.Double)
        //     Robocode.Robot.TurnRadarRight(System.Double) Robocode.AdvancedRobot.TurnRadarRightRadians(System.Double)
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's gun to the left.  If radians >
        //     0 the robot's gun will turn left.  If radians < 0 the robot's gun will turn
        //     right.  If radians = 0 the robot's gun will not turn, but execute.
        void TurnGunLeftRadians(double radians);
        //
        // Summary:
        //     Immediately turns the robot's gun to the right by radians.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the gun's turn is 0.  Note that both positive and negative values
        //     can be given as input, where negative values means that the robot's gun is
        //     set to turn left instead of right.  // Turn the robot's gun 180 degrees to
        //     the right TurnGunRightRadians(Math.PI); // Afterwards, turn the robot's gun
        //     90 degrees to the left TurnGunRightRadians(-Math.PI / 2); Robocode.Robot.TurnGunRight(System.Double)
        //     Robocode.Robot.TurnGunLeft(System.Double) Robocode.AdvancedRobot.TurnGunLeftRadians(System.Double)
        //     Robocode.Robot.TurnLeft(System.Double) Robocode.AdvancedRobot.TurnLeftRadians(System.Double)
        //     Robocode.Robot.TurnRight(System.Double) Robocode.AdvancedRobot.TurnRightRadians(System.Double)
        //     Robocode.Robot.TurnRadarLeft(System.Double) Robocode.AdvancedRobot.TurnRadarLeftRadians(System.Double)
        //     Robocode.Robot.TurnRadarRight(System.Double) Robocode.AdvancedRobot.TurnRadarRightRadians(System.Double)
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's gun to the right.  If radians >
        //     0 the robot's gun will turn right.  If radians < 0 the robot's gun will turn
        //     left.  If radians = 0 the robot's gun will not turn, but execute.
        void TurnGunRightRadians(double radians);
        //
        // Summary:
        //     Immediately turns the robot's body to the left by radians.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the robot's turn is 0.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     body is set to turn right instead of left.  // Turn the robot 180 degrees
        //     to the left TurnLeftRadians(Math.PI); // Afterwards, turn the robot 90 degrees
        //     to the right TurnLeftRadians(-Math.PI / 2); Robocode.Robot.TurnLeft(System.Double)
        //     Robocode.Robot.TurnRight(System.Double) Robocode.AdvancedRobot.TurnRightRadians(System.Double)
        //     Robocode.Robot.TurnGunLeft(System.Double) Robocode.AdvancedRobot.TurnGunLeftRadians(System.Double)
        //     Robocode.Robot.TurnGunRight(System.Double) Robocode.AdvancedRobot.TurnGunRightRadians(System.Double)
        //     Robocode.Robot.TurnRadarLeft(System.Double) Robocode.AdvancedRobot.TurnRadarLeftRadians(System.Double)
        //     Robocode.Robot.TurnRadarRight(System.Double) Robocode.AdvancedRobot.TurnRadarRightRadians(System.Double)
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's body to the left.  If radians >
        //     0 the robot will turn right.  If radians < 0 the robot will turn left.  If
        //     radians = 0 the robot will not turn, but execute.
        void TurnLeftRadians(double radians);
        //
        // Summary:
        //     Immediately turns the robot's radar to the left by radians.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the radar's turn is 0.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     radar is set to turn right instead of left.  // Turn the robot's radar 180
        //     degrees to the left TurnRadarLeftRadians(Math.PI); // Afterwards, turn the
        //     robot's radar 90 degrees to the right TurnRadarLeftRadians(-Math.PI / 2);
        //     Robocode.Robot.TurnRadarLeft(System.Double) Robocode.Robot.TurnRadarRight(System.Double)
        //     Robocode.AdvancedRobot.TurnGunRightRadians(System.Double) Robocode.Robot.TurnLeft(System.Double)
        //     Robocode.AdvancedRobot.TurnLeftRadians(System.Double) Robocode.Robot.TurnRight(System.Double)
        //     Robocode.AdvancedRobot.TurnRightRadians(System.Double) Robocode.Robot.TurnGunLeft(System.Double)
        //     Robocode.AdvancedRobot.TurnGunLeftRadians(System.Double) Robocode.Robot.TurnGunRight(System.Double)
        //     Robocode.AdvancedRobot.TurnGunRightRadians(System.Double) Robocode.Robot.IsAdjustRadarForRobotTurn
        //     Robocode.Robot.IsAdjustRadarForGunTurn
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's radar to the left.  If radians
        //     > 0 the robot's radar will turn left.  If radians < 0 the robot's radar will
        //     turn right.  If radians = 0 the robot's radar will not turn, but execute.
        void TurnRadarLeftRadians(double radians);
        //
        // Summary:
        //     Immediately turns the robot's radar to the right by radians.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the radar's turn is 0.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     radar is set to turn left instead of right.  // Turn the robot's radar 180
        //     degrees to the right TurnRadarRightRadians(Math.PI); // Afterwards, turn
        //     the robot's radar 90 degrees to the left TurnRadarRightRadians(-Math.PI /
        //     2); Robocode.Robot.TurnRadarRight(System.Double) Robocode.Robot.TurnRadarLeft(System.Double)
        //     Robocode.AdvancedRobot.TurnGunLeftRadians(System.Double) Robocode.Robot.TurnLeft(System.Double)
        //     Robocode.AdvancedRobot.TurnLeftRadians(System.Double) Robocode.Robot.TurnRight(System.Double)
        //     Robocode.AdvancedRobot.TurnRightRadians(System.Double) Robocode.Robot.TurnGunLeft(System.Double)
        //     Robocode.AdvancedRobot.TurnGunLeftRadians(System.Double) Robocode.Robot.TurnGunRight(System.Double)
        //     Robocode.AdvancedRobot.TurnGunRightRadians(System.Double) Robocode.Robot.IsAdjustRadarForRobotTurn
        //     Robocode.Robot.IsAdjustRadarForGunTurn
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's radar to the right.  If radians
        //     > 0 the robot's radar will turn right.  If radians < 0 the robot's radar
        //     will turn left.  If radians = 0 the robot's radar will not turn, but execute.
        void TurnRadarRightRadians(double radians);
        //
        // Summary:
        //     Immediately turns the robot's body to the right by radians.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the robot's turn is 0.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     body is set to turn left instead of right.  // Turn the robot 180 degrees
        //     to the right TurnRightRadians(Math.PI); // Afterwards, turn the robot 90
        //     degrees to the left TurnRightRadians(-Math.PI / 2); Robocode.Robot.TurnRight(System.Double)
        //     Robocode.Robot.TurnLeft(System.Double) Robocode.AdvancedRobot.TurnLeftRadians(System.Double)
        //     Robocode.Robot.TurnGunLeft(System.Double) Robocode.AdvancedRobot.TurnGunLeftRadians(System.Double)
        //     Robocode.Robot.TurnGunRight(System.Double) Robocode.AdvancedRobot.TurnGunRightRadians(System.Double)
        //     Robocode.Robot.TurnRadarLeft(System.Double) Robocode.AdvancedRobot.TurnRadarLeftRadians(System.Double)
        //     Robocode.Robot.TurnRadarRight(System.Double) Robocode.AdvancedRobot.TurnRadarRightRadians(System.Double)
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        //
        // Parameters:
        //   radians:
        //     the amount of radians to turn the robot's body to the right.  If radians
        //     > 0 the robot will turn right.  If radians < 0 the robot will turn left.
        //      If radians = 0 the robot will not turn, but execute.
        void TurnRightRadians(double radians);
        //
        // Summary:
        //     Does not return until a condition is met, i.e. when a Robocode.Condition.Test()
        //     returns true.  This call executes immediately.  See the Sample.Crazy robot
        //     for how this method can be used.  Robocode.Condition Robocode.Condition.Test()
        //
        // Parameters:
        //   condition:
        //     the condition that must be met before this call returns
        void WaitFor(Condition condition);

        // ##############################################################################################################################

        // Summary:
        //     Returns the height of the current battlefield measured in pixels.
        double BattleFieldHeight { get; }
        //
        // Summary:
        //     Returns the width of the current battlefield measured in pixels.
        double BattleFieldWidth { get; }
        //
        // Summary:
        //     Sets the color of the robot's body.  A null indicates the default (blue)
        //     color.  // Don't forget to using System.Drawing at the top...  using System.Drawing;
        //     ...   void Run() { SetBodyColor(Color.Black); ...  } Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetAllColors(System.Drawing.Color) Robocode.Robot.GunColor
        //     Robocode.Robot.RadarColor Robocode.Robot.BulletColor Robocode.Robot.ScanColor
        //     System.Drawing.Color
        Color BodyColor { get; set; }
        //
        // Summary:
        //     Sets the color of the robot's bullets.  A null indicates the default white
        //     color.  // Don't forget to using System.Drawing at the top...  using System.Drawing;
        //     ...   void Run() { SetBulletColor(Color.Green); ...  } Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetAllColors(System.Drawing.Color) Robocode.Robot.BodyColor
        //     Robocode.Robot.GunColor Robocode.Robot.RadarColor Robocode.Robot.ScanColor
        //     System.Drawing.Color
        Color BulletColor { get; set; }
        //
        // Summary:
        //     Sets the debug property with the specified key to the specified value.  This
        //     method is very useful when debugging or reviewing your robot as you will
        //     be able to see this property displayed in the robot console for your robots
        //     under the Debug Properties tab page.
        Robot.DebugPropertyH DebugProperty { get; }
        //
        // Summary:
        //     Returns the robot's current energy.
        double Energy { get; }
        //
        // Summary:
        //     Returns a graphics context used for painting graphical items for the robot.
        //      This method is very useful for debugging your robot.  Note that the robot
        //     will only be painted if the "Paint" is enabled on the robot's console window;
        //     otherwise the robot will never get painted (the reason being that all robots
        //     might have graphical items that must be painted, and then you might not be
        //     able to tell what graphical items that have been painted for your robot).
        //      Also note that the coordinate system for the graphical context where you
        //     paint items fits for the Robocode coordinate system where (0, 0) is at the
        //     bottom left corner of the battlefield, where X is towards right and Y is
        //     upwards.  Robocode.Robot.OnPaint(Robocode.IGraphics)
        IGraphics Graphics { get; }
        //
        // Summary:
        //     Sets the color of the robot's gun.  A null indicates the default (blue) color.
        //      // Don't forget to using System.Drawing at the top...  using System.Drawing;
        //     ...   void Run() { SetGunColor(Color.Red); ...  } Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetAllColors(System.Drawing.Color) Robocode.Robot.BodyColor
        //     Robocode.Robot.RadarColor Robocode.Robot.BulletColor Robocode.Robot.ScanColor
        //     System.Drawing.Color
        Color GunColor { get; set; }
        //
        // Summary:
        //     Returns the rate at which the gun will cool down, i.e. the amount of heat
        //     the gun heat will drop per turn.  The gun cooling rate is default 0.1 / turn,
        //     but can be changed by the battle setup. So don't count on the cooling rate
        //     being 0.1! Robocode.Robot.GunHeat Robocode.Robot.Fire(System.Double) Robocode.Robot.FireBullet(System.Double)
        double GunCoolingRate { get; }
        //
        // Summary:
        //     Returns the direction that the robot's gun is facing, in degrees.  The value
        //     returned will be between 0 and 360 (is excluded).  Note that the heading
        //     in Robocode is like a compass, where 0 means North, 90 means East, 180 means
        //     South, and 270 means West.  Robocode.Robot.Heading Robocode.Robot.RadarHeading
        double GunHeading { get; }
        //
        // Summary:
        //     Returns the current heat of the gun. The gun cannot Fire unless this is 0.
        //     (Calls to Fire will succeed, but will not actually Fire unless GetGunHeat()
        //     == 0).  The amount of gun heat generated when the gun is fired is 1 + (firePower
        //     / 5).  Each turn the gun heat drops by the amount returned by Robocode.Robot.GunCoolingRate,
        //     which is a battle setup.  Note that all guns are "hot" at the start of each
        //     round, where the gun heat is 3.  Robocode.Robot.GunCoolingRate Robocode.Robot.Fire(System.Double)
        //     Robocode.Robot.FireBullet(System.Double)
        double GunHeat { get; }
        //
        // Summary:
        //     Returns the direction that the robot's body is facing, in degrees.  The value
        //     returned will be between 0 and 360 (is excluded).  Note that the heading
        //     in Robocode is like a compass, where 0 means North, 90 means East, 180 means
        //     South, and 270 means West.  Robocode.Robot.GunHeading Robocode.Robot.RadarHeading
        double Heading { get; }
        //
        // Summary:
        //     Returns the height of the robot measured in pixels.  Robocode.Robot.Width
        double Height { get; }
        //
        // Summary:
        //     Sets the gun to turn independent from the robot's turn.  Ok, so this needs
        //     some explanation: The gun is mounted on the robot's body. So, normally, if
        //     the robot turns 90 degrees to the right, then the gun will turn with it as
        //     it is mounted on top of the robot's body. To compensate for this, you can
        //     call Robocode.Robot.IsAdjustGunForRobotTurn.  When this is set, the gun will
        //     turn independent from the robot's turn, i.e. the gun will compensate for
        //     the robot's body turn.  Note: This method is additive until you reach the
        //     maximum the gun can turn. The "adjust" is added to the amount you set for
        //     turning the robot, then capped by the physics of the game. If you turn infinite,
        //     then the adjust is ignored (and hence overridden).  Assuming both the robot
        //     and gun start Out facing up (0 degrees): // Set gun to turn with the robot's
        //     turn SetAdjustGunForRobotTurn(false); // This is the default TurnRight(90);
        //     // At this point, both the robot and gun are facing right (90 degrees) TurnLeft(90);
        //     // Both are back to 0 degrees -- or -- // Set gun to turn independent from
        //     the robot's turn SetAdjustGunForRobotTurn(true); TurnRight(90); // At this
        //     point, the robot is facing right (90 degrees), but the gun is still facing
        //     up.  TurnLeft(90); // Both are back to 0 degrees.  Note: The gun compensating
        //     this way does count as "turning the gun".  Robocode.Robot.IsAdjustRadarForGunTurn
        bool IsAdjustGunForRobotTurn { get; set; }
        //
        // Summary:
        //     Sets the radar to turn independent from the gun's turn.  Ok, so this needs
        //     some explanation: The radar is mounted on the robot's gun. So, normally,
        //     if the gun turns 90 degrees to the right, then the radar will turn with it
        //     as it is mounted on top of the gun. To compensate for this, you can call
        //     Robocode.Robot.IsAdjustRadarForGunTurn = (true).  When this is set, the radar
        //     will turn independent from the robot's turn, i.e. the radar will compensate
        //     for the gun's turn.  Note: This method is additive until you reach the maximum
        //     the radar can turn. The "adjust" is added to the amount you set for turning
        //     the gun, then capped by the physics of the game. If you turn infinite, then
        //     the adjust is ignored (and hence overridden).  Assuming both the gun and
        //     radar start Out facing up (0 degrees): // Set radar to turn with the gun's
        //     turn SetAdjustRadarForGunTurn(false); // This is the default TurnGunRight(90);
        //     // At this point, both the radar and gun are facing right (90 degrees); --
        //     or -- // Set radar to turn independent from the gun's turn SetAdjustRadarForGunTurn(true);
        //     TurnGunRight(90); // At this point, the gun is facing right (90 degrees),
        //     but the radar is still facing up.  Note: Calling Robocode.Robot.IsAdjustRadarForGunTurn
        //     will automatically call Robocode.Robot.IsAdjustRadarForRobotTurn with the
        //     same value, unless you have already called it earlier. This behavior is primarily
        //     for backward compatibility with older Robocode robots.  Robocode.Robot.IsAdjustRadarForRobotTurn
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        bool IsAdjustRadarForGunTurn { get; set; }
        //
        // Summary:
        //     Sets the radar to turn independent from the robot's turn.  Ok, so this needs
        //     some explanation: The radar is mounted on the gun, and the gun is mounted
        //     on the robot's body. So, normally, if the robot turns 90 degrees to the right,
        //     the gun turns, as does the radar. Hence, if the robot turns 90 degrees to
        //     the right, then the gun and radar will turn with it as the radar is mounted
        //     on top of the gun. To compensate for this, you can call Robocode.Robot.IsAdjustRadarForRobotTurn
        //     = true.  When this is set, the radar will turn independent from the robot's
        //     turn, i.e. the radar will compensate for the robot's turn.  Note: This method
        //     is additive until you reach the maximum the radar can turn. The "adjust"
        //     is added to the amount you set for turning the robot, then capped by the
        //     physics of the game. If you turn infinite, then the adjust is ignored (and
        //     hence overridden).  Assuming the robot, gun, and radar all start Out facing
        //     up (0 degrees): // Set radar to turn with the robots's turn SetAdjustRadarForRobotTurn(false);
        //     // This is the default TurnRight(90); // At this point, the body, gun, and
        //     radar are all facing right (90 degrees); -- or -- // Set radar to turn independent
        //     from the robot's turn SetAdjustRadarForRobotTurn(true); TurnRight(90); //
        //     At this point, the robot and gun are facing right (90 degrees), but the radar
        //     is still facing up.  Robocode.Robot.IsAdjustGunForRobotTurn Robocode.Robot.IsAdjustRadarForGunTurn
        bool IsAdjustRadarForRobotTurn { get; set; }
        //
        // Summary:
        //     Returns the robot's name.
        string Name { get; }
        //
        // Summary:
        //     Returns the number of rounds in the current battle.  Robocode.Robot.RoundNum
        int NumRounds { get; }
        //
        // Summary:
        //     Returns how many sentry robots that are left in the current round.
        int NumSentries { get; }
        //
        // Summary:
        //     Returns how many opponents that are left in the current round.
        int Others { get; }
        //
        // Summary:
        //     The Out stream your robot should use to print.  You can view the print-outs
        //     by clicking the button for your robot in the right side of the battle window.
        //      // Print Out a line each time my robot hits another robot  void OnHitRobot(HitRobotEvent
        //     e) { Out.WriteLine("I hit a robot! My energy: " + Energy + " his energy:
        //     " + e.Energy); }
        TextWriter Out { get; }
        //
        // Summary:
        //     Sets the color of the robot's radar.  A null indicates the default (blue)
        //     color.  // Don't forget to using System.Drawing at the top...  using System.Drawing;
        //     ...   void Run() { SetRadarColor(Color.Yellow); ...  } Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetAllColors(System.Drawing.Color) Robocode.Robot.BodyColor
        //     Robocode.Robot.GunColor Robocode.Robot.BulletColor Robocode.Robot.ScanColor
        //     System.Drawing.Color
        Color RadarColor { get; set; }
        //
        // Summary:
        //     Returns the direction that the robot's radar is facing, in degrees.  The
        //     value returned will be between 0 and 360 (is excluded).  Note that the heading
        //     in Robocode is like a compass, where 0 means North, 90 means East, 180 means
        //     South, and 270 means West.  Robocode.Robot.Heading Robocode.Robot.GunHeading
        double RadarHeading { get; }
        //
        // Summary:
        //     Returns the current round number (0 to Robocode.Robot.NumRounds - 1) of the
        //     battle.  Robocode.Robot.NumRounds
        int RoundNum { get; }
        //
        // Summary:
        //     Sets the color of the robot's scan arc.  A null indicates the default (blue)
        //     color.  // Don't forget to using System.Drawing at the top...  using System.Drawing;
        //     ...   void Run() { SetScanColor(Color.White); ...  } Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetAllColors(System.Drawing.Color) Robocode.Robot.BodyColor
        //     Robocode.Robot.GunColor Robocode.Robot.RadarColor Robocode.Robot.BulletColor
        //     System.Drawing.Color
        Color ScanColor { get; set; }
        //
        // Summary:
        //     Returns the sentry border size for a Robocode.BorderSentry that defines the
        //     how far a BorderSentry is allowed to move from the border edges measured
        //     in units.  Hence, the sentry border size defines the width/range of the border
        //     area surrounding the battlefield that BorderSentrys cannot leave (sentry
        //     robots robots must stay in the border area), but it also define the distance
        //     from the border edges where BorderSentrys are allowed/able to make damage
        //     to robots entering this border area.
        int SentryBorderSize { get; }
        //
        // Summary:
        //     Returns the game time of the current round, where the time is equal to the
        //     current turn in the round.  A battle consists of multiple rounds.  Time is
        //     reset to 0 at the beginning of every round.
        long Time { get; }
        //
        // Summary:
        //     Returns the velocity of the robot measured in pixels/turn.  The maximum velocity
        //     of a robot is defined by Robocode.Rules.MAX_VELOCITY (8 pixels / turn). 
        //     Robocode.Rules.MAX_VELOCITY
        double Velocity { get; }
        //
        // Summary:
        //     Returns the width of the robot measured in pixels.  Robocode.Robot.Height
        double Width { get; }
        //
        // Summary:
        //     Returns the X position of the robot. (0,0) is at the bottom left of the battlefield.
        //      Robocode.Robot.Y
        double X { get; }
        //
        // Summary:
        //     Returns the Y position of the robot. (0,0) is at the bottom left of the battlefield.
        //      Robocode.Robot.X
        double Y { get; }

        // Summary:
        //     Immediately moves your robot ahead (forward) by distance measured in pixels.
        //      This call executes immediately, and does not return until it is complete,
        //     i.e. when the remaining distance to move is 0.  If the robot collides with
        //     a wall, the move is complete, meaning that the robot will not move any further.
        //     If the robot collides with another robot, the move is complete if you are
        //     heading toward the other robot.  Note that both positive and negative values
        //     can be given as input, where negative values means that the robot is set
        //     to move backward instead of forward.  // Move the robot 100 pixels forward
        //     Ahead(100); // Afterwards, move the robot 50 pixels backward Ahead(-50);
        //
        // Parameters:
        //   distance:
        //     The distance to move ahead measured in pixels.  If this value is negative,
        //     the robot will move back instead of ahead.
        void Ahead(double distance);
        //
        // Summary:
        //     Immediately moves your robot backward by distance measured in pixels.  This
        //     call executes immediately, and does not return until it is complete, i.e.
        //     when the remaining distance to move is 0.  If the robot collides with a wall,
        //     the move is complete, meaning that the robot will not move any further. If
        //     the robot collides with another robot, the move is complete if you are heading
        //     toward the other robot.  Note that both positive and negative values can
        //     be given as input, where negative values means that the robot is set to move
        //     forward instead of backward.  // Move the robot 100 pixels backward Back(100);
        //     // Afterwards, move the robot 50 pixels forward Back(-50); Robocode.Robot.Ahead(System.Double)
        //     Robocode.Robot.OnHitWall(Robocode.HitWallEvent) Robocode.Robot.OnHitRobot(Robocode.HitRobotEvent)
        //
        // Parameters:
        //   distance:
        //     The distance to move back measured in pixels.  If this value is negative,
        //     the robot will move ahead instead of back.
        void Back(double distance);
        //
        // Summary:
        //     Do nothing this turn, meaning that the robot will skip it's turn.  This call
        //     executes immediately, and does not return until the turn is over.
        void DoNothing();
        //
        // Summary:
        //     Immediately fires a bullet. The bullet will travel in the direction the gun
        //     is pointing.  The specified bullet power is an amount of energy that will
        //     be taken from the robot's energy. Hence, the more power you want to spend
        //     on the bullet, the more energy is taken from your robot.  The bullet will
        //     do (4 * power) damage if it hits another robot. If power is greater than
        //     1, it will do an additional 2 * (power - 1) damage.  You will get (3 * power)
        //     back if you hit the other robot. You can call Robocode.Rules.GetBulletDamage(System.Double)
        //     for getting the damage that a bullet with a specific bullet power will do.
        //      The specified bullet power should be between Robocode.Rules.MIN_BULLET_POWER
        //     and Robocode.Rules.MAX_BULLET_POWER.  Note that the gun cannot Fire if the
        //     gun is overheated, meaning that Robocode.Robot.GunHeat returns a value >
        //     0.  A event is generated when the bullet hits a robot (Robocode.BulletHitEvent),
        //     wall (Robocode.BulletMissedEvent), or another bullet (Robocode.BulletHitBulletEvent).
        //      // Fire a bullet with maximum power if the gun is ready if (GetGunHeat()
        //     == 0) { Fire(Rules.MAX_BULLET_POWER); } Robocode.Robot.FireBullet(System.Double)
        //     Robocode.Robot.GunHeat Robocode.Robot.GunCoolingRate Robocode.Robot.OnBulletHit(Robocode.BulletHitEvent)
        //     Robocode.Robot.OnBulletHitBullet(Robocode.BulletHitBulletEvent) Robocode.Robot.OnBulletMissed(Robocode.BulletMissedEvent)
        //
        // Parameters:
        //   power:
        //     The amount of energy given to the bullet, and subtracted from the robot's
        //     energy.
        void Fire(double power);
        //
        // Summary:
        //     Immediately fires a bullet. The bullet will travel in the direction the gun
        //     is pointing.  The specified bullet power is an amount of energy that will
        //     be taken from the robot's energy. Hence, the more power you want to spend
        //     on the bullet, the more energy is taken from your robot.  The bullet will
        //     do (4 * power) damage if it hits another robot. If power is greater than
        //     1, it will do an additional 2 * (power - 1) damage.  You will get (3 * power)
        //     back if you hit the other robot. You can call Robocode.Rules.GetBulletDamage(System.Double)
        //     for getting the damage that a bullet with a specific bullet power will do.
        //      The specified bullet power should be between Robocode.Rules.MIN_BULLET_POWER
        //     and Robocode.Rules.MAX_BULLET_POWER.  Note that the gun cannot Fire if the
        //     gun is overheated, meaning that Robocode.Robot.GunHeat returns a value >
        //     0.  A event is generated when the bullet hits a robot (Robocode.BulletHitEvent),
        //     wall (Robocode.BulletMissedEvent), or another bullet (Robocode.BulletHitBulletEvent).
        //      // Fire a bullet with maximum power if the gun is ready if (GetGunHeat()
        //     == 0) { Bullet bullet = FireBullet(Rules.MAX_BULLET_POWER); // Get the velocity
        //     of the bullet if (bullet != null) { double bulletVelocity = bullet.Velocity;
        //     } } Returns a Robocode.Bullet That contains information about the bullet
        //     if it was actually fired, which can be used for tracking the bullet after
        //     it has been fired.  If the bullet was not fired, null is returned.  Robocode.Robot.Fire(System.Double)
        //     Robocode.Bullet Robocode.Robot.GunHeat Robocode.Robot.GunCoolingRate Robocode.Robot.OnBulletHit(Robocode.BulletHitEvent)
        //     Robocode.Robot.OnBulletHitBullet(Robocode.BulletHitBulletEvent) Robocode.Robot.OnBulletMissed(Robocode.BulletMissedEvent)
        //
        // Parameters:
        //   power:
        //     power the amount of energy given to the bullet, and subtracted from the robot's
        //     energy.
        Bullet FireBullet(double power);
        //
        void OnBattleEnded(BattleEndedEvent evnt);
        //
        void OnBulletHit(BulletHitEvent evnt);
        //
        void OnBulletHitBullet(BulletHitBulletEvent evnt);
        //
        void OnBulletMissed(BulletMissedEvent evnt);
        //
        void OnHitByBullet(HitByBulletEvent evnt);
        //
        void OnHitRobot(HitRobotEvent evnt);
        //
        void OnHitWall(HitWallEvent evnt);
        //
        void OnRobotDeath(RobotDeathEvent evnt);
        //
        void OnScannedRobot(ScannedRobotEvent evnt);
        //
        void OnStatus(StatusEvent e);
        //
        void OnWin(WinEvent evnt);
        //
        // Summary:
        //     Immediately resumes the movement you stopped by Robocode.Robot.Stop(), if
        //     any.  This call executes immediately, and does not return until it is complete.
        //      Robocode.Robot.Stop() Robocode.Robot.Stop(System.Boolean)
        void Resume();
        //
        // Summary:
        //     Scans for other robots. This method is called automatically by the game,
        //     as long as the robot is moving, turning its body, turning its gun, or turning
        //     its radar.  Scan will cause Robocode.Robot.OnScannedRobot(Robocode.ScannedRobotEvent)
        //     to be called if you see a robot.  There are 2 reasons to call Robocode.Robot.Scan()
        //     manually: You want to scan after you stop moving.  You want to interrupt
        //     the Robocode.Robot.OnScannedRobot(Robocode.ScannedRobotEvent) event. This
        //     is more likely. If you are in Robocode.Robot.OnScannedRobot(Robocode.ScannedRobotEvent)
        //     and call Robocode.Robot.Scan(), and you still see a robot, then the system
        //     will interrupt your Robocode.Robot.OnScannedRobot(Robocode.ScannedRobotEvent)
        //     event immediately and start it from the top.  This call executes immediately.
        //      Robocode.Robot.OnScannedRobot(Robocode.ScannedRobotEvent) Robocode.ScannedRobotEvent
        void Scan();
        //
        // Summary:
        //     Sets all the robot's color to the same color in the same time, i.e. the color
        //     of the body, gun, radar, bullet, and scan arc.  You may only call this method
        //     one time per battle. A null indicates the default (blue) color for the body,
        //     gun, radar, and scan arc, but white for the bullet color.  // Don't forget
        //     to using System.Drawing at the top...  using System.Drawing; ...  
        //     void Run() { SetAllColors(Color.Red); ...  } Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.BodyColor Robocode.Robot.GunColor Robocode.Robot.RadarColor
        //     Robocode.Robot.BulletColor Robocode.Robot.ScanColor System.Drawing.Color
        //
        // Parameters:
        //   color:
        //     The new color for all the colors of the robot
        void SetAllColors(Color color);
        //
        // Summary:
        //     Sets the color of the robot's body, gun, and radar in the same time.  You
        //     may only call this method one time per battle. A null indicates the default
        //     (blue) color.  // Don't forget to using System.Drawing at the top...  using
        //     System.Drawing; ...   void Run() { SetColors(null, Color.Red, Color.fromArgb(150,
        //     0, 150)); ...  } Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetAllColors(System.Drawing.Color) Robocode.Robot.BodyColor
        //     Robocode.Robot.GunColor Robocode.Robot.RadarColor Robocode.Robot.BulletColor
        //     Robocode.Robot.ScanColor System.Drawing.Color
        //
        // Parameters:
        //   bodyColor:
        //     The new body color
        //
        //   gunColor:
        //     The new gun color
        //
        //   radarColor:
        //     The new radar color
        void SetColors(Color bodyColor, Color gunColor, Color radarColor);
        //
        // Summary:
        //     Sets the color of the robot's body, gun, radar, bullet, and scan arc in the
        //     same time.  You may only call this method one time per battle. A null indicates
        //     the default (blue) color for the body, gun, radar, and scan arc, but white
        //     for the bullet color.  // Don't forget to using System.Drawing at the top...
        //      using System.Drawing; ...   void Run() { SetColors(null, Color.Red,
        //     Color.Greeen, null, Color.fromArgb(150, 0, 150)); ...  } Robocode.Robot.SetColors(System.Drawing.Color,System.Drawing.Color,System.Drawing.Color)
        //     Robocode.Robot.SetAllColors(System.Drawing.Color) Robocode.Robot.BodyColor
        //     Robocode.Robot.GunColor Robocode.Robot.RadarColor Robocode.Robot.BulletColor
        //     Robocode.Robot.ScanColor System.Drawing.Color
        //
        // Parameters:
        //   bodyColor:
        //     The new body color
        //
        //   gunColor:
        //     The new gun color
        //
        //   radarColor:
        //     The new radar color
        //
        //   bulletColor:
        //     The new bullet color
        //
        //   scanArcColor:
        //     The new scan arc color
        void SetColors(Color bodyColor, Color gunColor, Color radarColor, Color bulletColor, Color scanArcColor);
        //
        // Summary:
        //     Immediately stops all movement, and saves it for a call to Robocode.Robot.Resume().
        //      If there is already movement saved from a previous stop, this will have
        //     no effect.  This method is equivalent to Robocode.Robot.Stop(System.Boolean).
        //      Robocode.Robot.Resume() Robocode.Robot.Stop(System.Boolean)
        void Stop();
        //
        // Summary:
        //     Immediately stops all movement, and saves it for a call to Robocode.Robot.Resume().
        //      If there is already movement saved from a previous stop, you can overwrite
        //     it by calling Robocode.Robot.Stop(System.Boolean).  Robocode.Robot.Resume()
        //     Robocode.Robot.Stop()
        //
        // Parameters:
        //   overwrite:
        //     If there is already movement saved from a previous stop, you can overwrite
        //     it by calling Robocode.Robot.Stop(System.Boolean).
        void Stop(bool overwrite);
        //
        // Summary:
        //     Immediately turns the robot's gun to the left by degrees.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the gun's turn is 0.  Note that both positive and negative values
        //     can be given as input, where negative values means that the robot's gun is
        //     set to turn right instead of left.  // Turn the robot's gun 180 degrees to
        //     the left TurnGunLeft(180); // Afterwards, turn the robot's gun 90 degrees
        //     to the right TurnGunLeft(-90); Robocode.Robot.TurnGunRight(System.Double)
        //     Robocode.Robot.TurnLeft(System.Double) Robocode.Robot.TurnRight(System.Double)
        //     Robocode.Robot.TurnRadarLeft(System.Double) Robocode.Robot.TurnRadarRight(System.Double)
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's gun to the left.  If degrees >
        //     0 the robot's gun will turn left.  If degrees < 0 the robot's gun will turn
        //     right.  If degrees = 0 the robot's gun will not turn, but execute.
        void TurnGunLeft(double degrees);
        //
        // Summary:
        //     Immediately turns the robot's gun to the right by degrees.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the gun's turn is 0.  Note that both positive and negative values
        //     can be given as input, where negative values means that the robot's gun is
        //     set to turn left instead of right.  // Turn the robot's gun 180 degrees to
        //     the right TurnGunRight(180); // Afterwards, turn the robot's gun 90 degrees
        //     to the left TurnGunRight(-90); Robocode.Robot.TurnGunLeft(System.Double)
        //     Robocode.Robot.TurnLeft(System.Double) Robocode.Robot.TurnRight(System.Double)
        //     Robocode.Robot.TurnRadarLeft(System.Double) Robocode.Robot.TurnRadarRight(System.Double)
        //     Robocode.Robot.IsAdjustGunForRobotTurn
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's gun to the right.  If degrees >
        //     0 the robot's gun will turn right.  If degrees < 0 the robot's gun will turn
        //     left.  If degrees = 0 the robot's gun will not turn, but execute.
        void TurnGunRight(double degrees);
        //
        // Summary:
        //     Immediately turns the robot's body to the left by degrees.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the robot's turn is 0.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     body is set to turn right instead of left.  // Turn the robot 180 degrees
        //     to the left TurnLeft(180); // Afterwards, turn the robot 90 degrees to the
        //     right TurnLeft(-90); Robocode.Robot.TurnRight(System.Double) Robocode.Robot.TurnGunLeft(System.Double)
        //     Robocode.Robot.TurnGunRight(System.Double) Robocode.Robot.TurnRadarLeft(System.Double)
        //     Robocode.Robot.TurnRadarRight(System.Double)
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's body to the left.  If degrees >
        //     0 the robot will turn left.  If degrees < 0 the robot will turn right.  If
        //     degrees = 0 the robot will not turn, but execute.
        void TurnLeft(double degrees);
        //
        // Summary:
        //     Immediately turns the robot's radar to the left by degrees.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the radar's turn is 0.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     radar is set to turn right instead of left.  // Turn the robot's radar 180
        //     degrees to the left TurnRadarLeft(180); // Afterwards, turn the robot's radar
        //     90 degrees to the right TurnRadarLeft(-90); Robocode.Robot.TurnRadarRight(System.Double)
        //     Robocode.Robot.TurnLeft(System.Double) Robocode.Robot.TurnRight(System.Double)
        //     Robocode.Robot.TurnGunLeft(System.Double) Robocode.Robot.TurnGunRight(System.Double)
        //     Robocode.Robot.IsAdjustRadarForRobotTurn Robocode.Robot.IsAdjustRadarForGunTurn
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's radar to the left.  If degrees
        //     > 0 the robot's radar will turn left.  If degrees < 0 the robot's radar will
        //     turn right.  If degrees = 0 the robot's radar will not turn, but execute.
        void TurnRadarLeft(double degrees);
        //
        // Summary:
        //     Immediately turns the robot's radar to the right by degrees.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the radar's turn is 0.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     radar is set to turn left instead of right.  // Turn the robot's radar 180
        //     degrees to the right TurnRadarRight(180); // Afterwards, turn the robot's
        //     radar 90 degrees to the left TurnRadarRight(-90); Robocode.Robot.TurnRadarLeft(System.Double)
        //     Robocode.Robot.TurnLeft(System.Double) Robocode.Robot.TurnRight(System.Double)
        //     Robocode.Robot.TurnGunLeft(System.Double) Robocode.Robot.TurnGunRight(System.Double)
        //     Robocode.Robot.IsAdjustRadarForRobotTurn Robocode.Robot.IsAdjustRadarForGunTurn
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's radar to the right.  If degrees
        //     > 0 the robot's radar will turn right.  If degrees < 0 the robot's radar
        //     will turn left.  If degrees = 0 the robot's radar will not turn, but execute.
        void TurnRadarRight(double degrees);
        //
        // Summary:
        //     Immediately turns the robot's body to the right by degrees.  This call executes
        //     immediately, and does not return until it is complete, i.e. when the angle
        //     remaining in the robot's turn is 0.  Note that both positive and negative
        //     values can be given as input, where negative values means that the robot's
        //     body is set to turn left instead of right.  // Turn the robot 180 degrees
        //     to the right TurnRight(180); // Afterwards, turn the robot 90 degrees to
        //     the left TurnRight(-90); Robocode.Robot.TurnLeft(System.Double) Robocode.Robot.TurnGunLeft(System.Double)
        //     Robocode.Robot.TurnGunRight(System.Double) Robocode.Robot.TurnRadarLeft(System.Double)
        //     Robocode.Robot.TurnRadarRight(System.Double)
        //
        // Parameters:
        //   degrees:
        //     The amount of degrees to turn the robot's body to the right.  If degrees
        //     > 0 the robot will turn right.  If degrees < 0 the robot will turn left.
        //      If degrees = 0 the robot will not turn, but execute.
        void TurnRight(double degrees);
    }

    internal class Dummy : AdvancedRobot
    {

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