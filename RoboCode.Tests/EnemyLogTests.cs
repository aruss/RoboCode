using arusslabs.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robocode;

namespace arusslabs.Tests
{
    [TestClass]
    public class BattleLogTests
    {

        [TestMethod]
        public void OnScannedRobot()
        {
            var robot = new TestRobot();
            var log = new EnemyLog(robot);

            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 11, 2.123, 22, 100, 3.12, false));
            robot.OnScannedRobot(new ScannedRobotEvent("Franky", 10, 12, 22, 1, 2, false));

            Assert.AreEqual(2, log.InfoTrace.Count);
            Assert.IsNotNull(log.InfoTrace["Franky"]);
            Assert.IsNotNull(log.InfoTrace["Spanky"]);
        }

        [TestMethod]
        public void OnRobotDeath()
        {
            var robot = new TestRobot();
            var log = new EnemyLog(robot);

            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 11, 2.123, 22, 100, 3.12, false));
            robot.OnScannedRobot(new ScannedRobotEvent("Franky", 10, 12, 22, 1, 2, false));

            robot.OnRobotDeath(new RobotDeathEvent("Spanky"));
            Assert.AreEqual(1, log.InfoTrace.Count);

            robot.OnRobotDeath(new RobotDeathEvent("Franky"));
            Assert.AreEqual(0, log.InfoTrace.Count);
        }

        [TestMethod]
        public void ScanSequence()
        {
            var robot = new TestRobot();
            var log = new EnemyLog(robot, 4);

            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 11, 2.123, 22, 100, 3.12, false));
            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 12, 2.223, 22, 101, 3.22, false));
            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 13, 2.323, 22, 102, 3.32, false));
            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 14, 2.423, 22, 103, 3.42, false));
            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 15, 2.423, 22, 103, 3.42, false));
            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 16, 2.423, 22, 103, 3.42, false));

            var spankyLog = log.InfoTrace["Spanky"].ToArray();
            Assert.AreEqual(16, spankyLog[0].Energy);
            Assert.AreEqual(15, spankyLog[1].Energy);
            Assert.AreEqual(14, spankyLog[2].Energy);
            Assert.AreEqual(13, spankyLog[3].Energy);
        }

        [TestMethod]
        public void PredictionTest()
        {
            var enemy = new TestRobot();

            enemy.Velocity = 3;
            enemy.Heading = 45;
            enemy.X = 100;
            enemy.Y = 100; 


            
        }

        /* TODO: Implement limiting feature 
        [TestMethod]
        public void ScanLimit()
        {
            var robot = new TestRobot();
            var log = new EnemyLog(robot, 4);

            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 10, 12, 22, 1, 2, false));
            Assert.AreEqual(1, log.InfoTrace["Spanky"].Count);

            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 10, 12, 22, 1, 2, false));
            Assert.AreEqual(2, log.InfoTrace["Spanky"].Count);

            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 10, 12, 22, 1, 2, false));
            Assert.AreEqual(3, log.InfoTrace["Spanky"].Count);

            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 10, 12, 22, 1, 2, false));
            Assert.AreEqual(4, log.InfoTrace["Spanky"].Count);

            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 10, 12, 22, 1, 2, false));
            Assert.AreEqual(4, log.InfoTrace["Spanky"].Count);

            robot.OnScannedRobot(new ScannedRobotEvent("Spanky", 10, 12, 22, 1, 2, false));
            Assert.AreEqual(4, log.InfoTrace["Spanky"].Count);
        }
        */
    }
}
