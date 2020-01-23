using System.Collections;
using System.Collections.Generic;
using Characters.Movement;
using General;
using NUnit.Framework;
using Player;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class MidAirMovementTest {
        private List<GameObject> gameObjects = new List<GameObject>();
        private GameObject playerGo;
        private IPlayer player;

        [SetUp]
        public void setUpTestScene() {
            gameObjects = TestCommonMethods.init();
            GameObject inputManagerGo = TestCommonMethods.initInputManager();
            InputManager inputManager = inputManagerGo.GetComponent<InputManager>();
            playerGo = TestCommonMethods.initPlayer(inputManager);
            gameObjects.Add(inputManagerGo);
            gameObjects.Add(playerGo);
            player = playerGo.GetComponent<IPlayer>();
        }

        [TearDown]
        public void afterTest() {
            gameObjects.ForEach(Object.Destroy);
            player = null;
        }

        [UnityTest]
        public IEnumerator initTest() {
            Assert.NotNull(player);
            var transformPosition = playerGo.transform.position;
            transformPosition.y = 100f;
            playerGo.transform.position = transformPosition;
            IMovement movement = player.getMovement();
            Assert.True(movement is GroundMovement);

            yield return new WaitForSeconds(1f);
            movement = player.getMovement();
            Assert.NotNull(movement);

            Assert.True(movement is MidairMovement);
        }

        [UnityTest]
        public IEnumerator fallingTest() {
            yield return new WaitForSeconds(1f);
        }
    }
}