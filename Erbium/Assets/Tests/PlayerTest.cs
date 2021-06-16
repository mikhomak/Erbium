using System.Collections;
using Characters;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class PlayerTest {

      
        
        [UnityTest]
        public IEnumerator InitalizePlayer() {
            GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"));
            yield return new WaitForEndOfFrame();
            Assert.NotNull(player.GetComponent<ICharacter>());
            Assert.NotNull(player.GetComponent<IPhysicsCharacter>());
            Assert.NotNull(player.GetComponent<IPhysicsCharacter>().getRigidbody());
            Assert.NotNull(player.GetComponent<IPhysicsCharacter>().getStats());
            Assert.NotNull(player.GetComponent<IPhysicsCharacter>().getMovement());
            Assert.NotNull(player.GetComponent<IPhysicsCharacter>().getHealthComponent());
            Object.Destroy(player);
        }
    }
}