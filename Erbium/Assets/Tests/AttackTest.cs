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

        [UnityTest]
        public IEnumerator rootMotionTest() {
            Assert.IsFalse(player.getAnimatorFacade().getAnimator().applyRootMotion);
            player.getAttackManager().fastAttack();
            yield return new WaitForFixedUpdate();
            Assert.IsTrue(player.getAnimatorFacade().getAnimator().applyRootMotion);
        }

        [UnityTest]
        public IEnumerator characterHasMovedDuringFastAttack() {
            var initPos = player.getRigidbody().position;
            player.getAttackManager().fastAttack();
            yield return new WaitForSeconds(1);
            Assert.IsFalse(Equals(initPos, player.getRigidbody().position));
        }

        [UnityTest]
        public IEnumerator characterHasMovedDuringStrongAttack() {
            var initPos = player.getRigidbody().position;
            player.getAttackManager().strongAttack();
            yield return new WaitForSeconds(1);
            Assert.IsFalse(Equals(initPos, player.getRigidbody().position));
        }
    }
}