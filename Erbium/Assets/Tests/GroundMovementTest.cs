using System.Collections;
using Characters.Movement;
using NSubstitute;
using NUnit.Framework;
using Player.MovementDirection;
using UnityEngine;
using UnityEngine.TestTools;
using static NSubstitute.Substitute;

namespace Tests {
    public class GroundMovementTest : AbstractTest {
        [UnityTest]
        public IEnumerator InitalizeGroundMovementTest() {
            yield return new WaitForEndOfFrame();

            Assert.NotNull(player);

            IMovement movement = player.getMovement();
            Assert.NotNull(movement);

            Assert.True(movement is GroundMovement);
        }

        [UnityTest]
        public IEnumerator MoveTest() {
            IMovementDirection moveDirection = For<IMovementDirection>();
            var direction = new Vector3(0, 0, 1);
            player.ChangeMovementDirection(moveDirection);
            moveDirection.GetDirection().Returns(direction);
            Vector3 playerInitPosition = playerGo.transform.position;
            Assert.True(player.getMovement() is GroundMovement);
            yield return new WaitForSeconds(1f);

            Vector3 expectedPosition = playerInitPosition + direction * (player.getStats().speed * 1f);
            Assert.True(Vector3.Distance(expectedPosition, playerGo.transform.position) <= 2f);
            Assert.True(player.getMovement() is GroundMovement);
        }
    }
}