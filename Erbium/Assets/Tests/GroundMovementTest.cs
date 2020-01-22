using System.Collections;
using System.Collections.Generic;
using Camera;
using Characters;
using Characters.Movement;
using General;
using NSubstitute;
using NUnit.Framework;
using Player.MovementDirection;
using UnityEngine;
using UnityEngine.TestTools;
using static NSubstitute.Substitute;

namespace Tests {
    public class GroundMovementTest {
        private readonly List<GameObject> gameObjects = new List<GameObject>();
        private GameObject playerGo;
        private Player.IPlayer player;

        [SetUp]
        public void setUpTestScene() {
            gameObjects.Add(Object.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Main Camera")));
            gameObjects.Add(
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Always Forward Camera")));
            gameObjects.Add(Object.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Camera Manager")));
            gameObjects.Add(Object.Instantiate(Resources.Load<GameObject>("Prefabs/Enviroments/Test Floor")));
            GameObject inputManagerGo =
                Object.Instantiate(Resources.Load<GameObject>("Prefabs/General/Input Manager"));
            playerGo = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"));
            gameObjects.Add(inputManagerGo);
            gameObjects.Add(playerGo);
            var inputManager = inputManagerGo.GetComponent<InputManager>();
            inputManager.playerGameObject = playerGo;
            player = playerGo.GetComponent<Player.IPlayer>();
        }

        [TearDown]
        public void afterTest() {
            gameObjects.ForEach(Object.Destroy);
            player = null;
        }

        [UnityTest]
        public IEnumerator initalizeGroundMovementTest() {
            yield return new WaitForEndOfFrame();

            Assert.NotNull(player);

            IMovement movement = player.getMovement();
            Assert.NotNull(movement);

            Assert.True(movement is GroundMovement);
        }

        [UnityTest]
        public IEnumerator moveTest() {
            IMovementDirection moveDirection = For<IMovementDirection>();
            var direction = new Vector3(0, 0, 1);
            player.changeMovementDirection(moveDirection);
            moveDirection.getDirection().Returns(direction);
            Vector3 playerInitPosition = playerGo.transform.position;
            Assert.True(player.getMovement() is GroundMovement);
            yield return new WaitForSeconds(1f);

            Vector3 expectedPosition = playerInitPosition + direction * (player.getStats().Speed * 1f);
            Assert.True(Vector3.Distance(expectedPosition, playerGo.transform.position) <= 0.2f);
            Assert.True(player.getMovement() is GroundMovement);
        }
    }
}