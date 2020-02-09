using System.Collections;
using General;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class TimerManagerTest {
        private GameObject timerManagerGO;

        private float firstAtt = 1f;
        private float secondAtt = 2f;


        private void changeFirst() {
            firstAtt = 10f;
        }

        private void changeSecond() {
            secondAtt = 20f;
        }
        
        
        [SetUp]
        public void setUp() {
            timerManagerGO = Object.Instantiate(Resources.Load<GameObject>("Prefabs/General/Timer Manager"));
        }

        [TearDown]
        public void destroyEverything() {
            Object.Destroy(timerManagerGO);
        }

        [UnityTest]
        public IEnumerator timerTest() {
            Assert.True(firstAtt == 1f);
            Assert.True(secondAtt == 2f);
            TimerManager.Instance.startTimer(0.5f, changeFirst);
            TimerManager.Instance.startTimer(1f, changeSecond);
            yield return new WaitForSecondsRealtime(4);
            Assert.True(firstAtt == 10f);
            Assert.True(secondAtt == 20f);
        }

    }
}