using System.Collections;
using Camera;
using Characters;
using Characters.Movement;
using General;
using NSubstitute;
using NUnit.Framework;
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
            var moveDirection = Substitute.For<IMovementDirection>();
            var direction = new Vector3(0, 0, 10);
            player.movementDirection = moveDirection;
            moveDirection.getCameraForwardDirection().Returns(direction);

            yield return new WaitForSeconds(2f);

            Debug.Log(playerGo.transform.position);
            Assert.Equals(1, 1);
        }
    }
}