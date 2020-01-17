using System.Collections;
using System.Collections.Generic;
using Characters;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTest
    {

        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player/Player"));
            yield return new WaitForEndOfFrame();
            Assert.NotNull(player.GetComponent<ICharacter>());
            Assert.NotNull(player.GetComponent<IPhysicsCharacter>());
            Assert.NotNull(player.GetComponent<IPhysicsCharacter>().getRigidbody());
            Assert.NotNull(player.GetComponent<IPhysicsCharacter>().getStats());
            Assert.NotNull(player.GetComponent<IPhysicsCharacter>().getMovement());
            Object.Destroy(player);
        }
    }
}
