using System.Collections;
using Characters.Movement;
using General;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class MidAirMovementTest : AbstractTest {
        [UnityTest]
        public IEnumerator initTest() {
            Assert.NotNull(player);
            var transformPosition = playerGo.transform.position;
            transformPosition.y = 100f;
            playerGo.transform.position = transformPosition;
            IMovement movement = player.getMovement();
            Assert.True(movement is GroundMovement);

            yield return new WaitForSeconds(1f);
            movement = player.getMovement();
            Assert.NotNull(movement);

            //Assert.True(movement is MidairMovement);
        }

        [UnityTest]
        public IEnumerator fallingTest() {
            var initPos = playerGo.transform.position;
            initPos.y = 100f;
            playerGo.transform.position = initPos;
            yield return new WaitForSeconds(1f);
            Vector3 yPos = initPos;
            yPos.y -= player.getStats().additionalGravityForce;
            Assert.True(Vector3.Distance(playerGo.transform.position, yPos) <= 7f);
        }

        [UnityTest]
        public IEnumerator landingTest() {
            var initPos = playerGo.transform.position;
            initPos.y += CommonMethods.LANDING_RAT_DISTANCE_MIN;
            playerGo.transform.position = initPos;
            yield return new WaitForSeconds(0.1f);
            IMovement movement = player.getMovement();
            Assert.True(CommonMethods.isAboutToLand(playerGo.transform.position, Vector3.down,
                CommonMethods.normalizeValue(player.getRigidbody().velocity.y, player.getStats().maxDownVelocity)));
            //Assert.True(movement is MidairMovement);
            yield return new WaitForSeconds(1f);
            movement = player.getMovement();
            Assert.True(movement is GroundMovement);
        }
    }
}