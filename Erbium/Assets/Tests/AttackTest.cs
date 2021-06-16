using System.Collections;
using Characters.Movement;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;

namespace Tests {
    public class AttackTest : AbstractTest {
        [UnityTest]
        public IEnumerator AttackManagerTest() {
            yield return new WaitForEndOfFrame();
            Assert.IsNotNull(player.getAttackManager());
        }

        [UnityTest]
        public IEnumerator AttackingMovementTest() {
            player.getAttackManager().FastAttack();
            yield return new WaitForFixedUpdate();
            Assert.IsTrue(player.getMovement() is AttackingMovement);
        }

        [UnityTest]
        public IEnumerator RootMotionTest() {
            Assert.IsFalse(player.getAnimatorFacade().getAnimator().applyRootMotion);
            player.getAttackManager().FastAttack();
            yield return new WaitForFixedUpdate();
            Assert.IsTrue(player.getAnimatorFacade().getAnimator().applyRootMotion);
        }

        [UnityTest]
        public IEnumerator CharacterHasMovedDuringFastAttack() {
            var initPos = player.getRigidbody().position;
            player.getAttackManager().FastAttack();
            yield return new WaitForSeconds(1);
            Assert.IsFalse(Equals(initPos, player.getRigidbody().position));
        }

        [UnityTest]
        public IEnumerator CharacterHasMovedDuringStrongAttack() {
            var initPos = player.getRigidbody().position;
            player.getAttackManager().StrongAttack();
            yield return new WaitForSeconds(1);
            Assert.IsFalse(Equals(initPos, player.getRigidbody().position));
        }

        [UnityTest]
        public IEnumerator FastAttackTest() {
            player.getAttackManager().ResetCombo();
            player.getAttackManager().FastAttack();
            yield return new WaitForFixedUpdate();
            Assert.IsTrue(player.getAttackManager().getCurrentCombo() == 1);
        }

        [UnityTest]
        public IEnumerator StrongAttackTest() {
            player.getAttackManager().ResetCombo();
            player.getAttackManager().StrongAttack();
            yield return new WaitForFixedUpdate();
            Assert.IsTrue(player.getAttackManager().getCurrentCombo() == 1);
        }

        [UnityTest]
        public IEnumerator Combo3() {
            player.getAttackManager().ResetCombo();
            player.getAttackManager().AddCombo();
            player.getAttackManager().AddCombo();
            player.getAttackManager().AddCombo();
            yield return new WaitForFixedUpdate();
            Assert.IsTrue(player.getAttackManager().getCurrentCombo() == 3);
        }


        [UnityTest]
        public IEnumerator ComboFastAttacks() {
            player.getAttackManager().ResetCombo();
            player.getAttackManager().FastAttack();
            player.getAttackManager().AddCombo();
            player.getAttackManager().AddCombo();
            yield return new WaitForFixedUpdate();
            Assert.IsTrue(player.getAttackManager().getCurrentCombo() == 3);
        }   
        
        [UnityTest]
        public IEnumerator ComboStrongAttacks() {
            player.getAttackManager().ResetCombo();
            player.getAttackManager().StrongAttack();
            player.getAttackManager().AddCombo();
            player.getAttackManager().AddCombo();
            yield return new WaitForFixedUpdate();
            Assert.IsTrue(player.getAttackManager().getCurrentCombo() == 3);
        }

        [UnityTest]
        public IEnumerator FastStrongAttack() {
            player.getAttackManager().ResetCombo();
            player.getAttackManager().FastAttack();
            yield return new WaitForSeconds(0.5f);
            player.getAttackManager().StrongAttack();
            yield return new WaitForSeconds(0.5f);
            Assert.IsTrue(player.getAttackManager().getCurrentCombo() == 2);
        }

        [UnityTest]
        public IEnumerator StrongFastAttack() {
            player.getAttackManager().ResetCombo();
            player.getAttackManager().StrongAttack();
            yield return new WaitForSeconds(0.4f);
            player.getAttackManager().FastAttack();
            yield return new WaitForSeconds(0.6f);
            Assert.IsTrue(player.getAttackManager().getCurrentCombo() == 2);
        }
    }
}