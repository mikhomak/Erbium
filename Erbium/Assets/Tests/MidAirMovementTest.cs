using System.Collections;
using Characters.Movement;
using General;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class MidAirMovementTest : AbstractTest {
        [UnityTest]
        public IEnumerator InitTest() {
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
        public IEnumerator FallingTest() {
            var initPos = playerGo.transform.position;
            initPos.y = 100f;
            playerGo.transform.position = initPos;
            yield return new WaitForSeconds(1f);
            Vector3 yPos = initPos;
            yPos.y -= player.getStats().additionalGravityForce;
            Assert.True(Vector3.Distance(playerGo.transform.position, yPos) <= 7f);
        }

        [UnityTest]
        public IEnumerator LandingTest() {
            var initPos = playerGo.transform.position;
            initPos.y += CommonMethods.LandingRatDistanceMIN;
            playerGo.transform.position = initPos;
            yield return new WaitForSeconds(0.1f);
            IMovement movement = player.getMovement();
            Assert.True(CommonMethods.IsAboutToLand(playerGo.transform.position, Vector3.down,
                CommonMethods.NormalizeValue(player.getRigidbody().velocity.y, player.getStats().maxDownVelocity)));
            //Assert.True(movement is MidairMovement);
            yield return new WaitForSeconds(1f);
            movement = player.getMovement();
            Assert.True(movement is GroundMovement);
        }
    }
}