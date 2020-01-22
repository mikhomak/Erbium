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
        private ICharacter player;
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
            player = playerGo.GetComponent<ICharacter>();

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
            
            
            
            
            player.getMovement().move(new Vector3(10,0,10));
            yield return new WaitForSeconds(3f);
            Debug.Log(playerGo.transform.position);
            Assert.Equals(1, 1);
        }
    }
}