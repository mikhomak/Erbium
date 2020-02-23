using System.Collections;
using Characters.Movement;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Tests {
    public class AttackTest : AbstractTest {


        [UnityTest]
        public IEnumerator attackManagerTest() {
            yield return new WaitForEndOfFrame();
            Assert.IsNotNull(player.getAttackManager());
        }
        
        [UnityTest]
        public IEnumerator attackingMovementTest() {
            player.getAttackManager().fastAttack();
            yield return new WaitForFixedUpdate();
            Assert.IsTrue(player.getMovement() is AttackingMovement);
        }
    }
}