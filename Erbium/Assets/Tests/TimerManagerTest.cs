using System.Collections;
using General;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class TimerManagerTest {
        private GameObject _timerManagerGO;

        private float _firstAtt = 1f;
        private float _secondAtt = 2f;


        private void ChangeFirst() {
            _firstAtt = 10f;
        }

        private void ChangeSecond() {
            _secondAtt = 20f;
        }
        
        
        [SetUp]
        public void SetUp() {
            _timerManagerGO = Object.Instantiate(Resources.Load<GameObject>("Prefabs/General/Timer Manager"));
        }

        [TearDown]
        public void DestroyEverything() {
            Object.Destroy(_timerManagerGO);
        }

        [UnityTest]
        public IEnumerator TimerTest() {
            Assert.True(_firstAtt == 1f);
            Assert.True(_secondAtt == 2f);
            TimerManager.instance.StartTimer(0.5f, ChangeFirst);
            TimerManager.instance.StartTimer(1f, ChangeSecond);
            yield return new WaitForSecondsRealtime(4);
            Assert.True(_firstAtt == 10f);
            Assert.True(_secondAtt == 20f);
        }

    }
}