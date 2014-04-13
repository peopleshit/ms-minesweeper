using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    /// <summary>
    /// Сводное описание для UnitTest
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        Game testGame;

        public UnitTest()
        {
            //
            // TODO: добавьте здесь логику конструктора
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Получает или устанавливает контекст теста, в котором предоставляются
        ///сведения о текущем тестовом запуске и обеспечивается его функциональность.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Дополнительные атрибуты тестирования
        //
        // При написании тестов можно использовать следующие дополнительные атрибуты:
        //
        // ClassInitialize используется для выполнения кода до запуска первого теста в классе
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // ClassCleanup используется для выполнения кода после завершения работы всех тестов в классе
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // TestInitialize используется для выполнения кода перед запуском каждого теста 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // TestCleanup используется для выполнения кода после завершения каждого теста
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestingCountingTheBombsAroundSafeCells()
        {
            testGame = new Game(9, 9, 10, true);

            Assert.AreEqual(3, testGame.countBombs(1));
            Assert.AreEqual(1, testGame.countBombs(79));
        }

        [TestMethod]
        public void TestingRandomlyGeneratedBombsPLacing()
        {
            testGame = new Game(9, 9, 10, false);
            int temp = testGame.testRandom();
            bool state = false;
            if (temp > 70)
                state = true;
            Assert.AreEqual(false, state);
        }
    }
}
