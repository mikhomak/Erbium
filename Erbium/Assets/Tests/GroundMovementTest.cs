using System.Collections;
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
        private GameObject playerGo;
        private Player.Player player;

        [SetUp]
        public void setUpTestScene() {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Main Camera"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Always Forward Camera"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Camera Manager"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Enviroments/Test Floor"));
            GameObject inputManagerGO =
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/General/Input Manager"));
            playerGo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"));
            var inputManager = inputManagerGO.GetComponent<InputManager>();
            inputManager.playerGameObject = playerGo;
            player = playerGo.GetComponent<Player.Player>();
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
            yield return new WaitForSeconds(1f);

            Vector3 expectedPosition = playerInitPosition + direction * (player.getStats().Speed * 1f);
            Assert.True(Vector3.Distance(expectedPosition, playerGo.transform.position) <= 0.2f);
        }
    }
}