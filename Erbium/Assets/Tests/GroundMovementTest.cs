using System.Collections;
using Characters;
using Characters.Movement;
using General;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class GroundMovementTest {
        private GameObject playerGo;

        [SetUp]
        public void setUpTestScene() {
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Main Camera"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Always Forward Camera"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Cameras/Camera Manager"));
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Enviroments/Test Floor"));
            GameObject inputManagerGO = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/General/Input Manager"));
            playerGo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"));
            var inputManager = inputManagerGO.GetComponent<InputManager>();
            inputManager.playerGameObject = playerGo;
        }

        [UnityTest]
        public IEnumerator initalizeGroundMovement() {
            yield return new WaitForEndOfFrame();

            ICharacter player = playerGo.GetComponent<ICharacter>();
            Assert.NotNull(player);

            IMovement movement = player.getMovement();
            Assert.NotNull(movement);
            
            Assert.True(movement is GroundMovement);
        }
    }
}