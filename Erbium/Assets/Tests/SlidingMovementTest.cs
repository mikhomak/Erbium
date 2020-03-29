using System.Collections;
using Characters.Movement;
using NSubstitute;
using NUnit.Framework;
using Player.MovementDirection;
using UnityEngine;
using UnityEngine.TestTools;
using static NSubstitute.Substitute;


namespace Tests {
    public class SlidingMovementTest : AbstractTest {
        [UnityTest]
        public IEnumerator slideTest() {
            IMovementDirection moveDirection = For<IMovementDirection>();
            var direction = new Vector3(0, 0, 1);
            player.changeMovementDirection(moveDirection);
            moveDirection.getDirection().Returns(direction);
            player.changeMovement(MovementEnum.Slide);
            Vector3 playerInitPosition = playerGo.transform.position;
            Assert.True(player.getMovement() is SlidingMovement);
            yield return new WaitForSeconds(1f);

            Vector3 expectedPosition = playerInitPosition + direction * player.getStats().slidingSpeed;

            Assert.True(Vector3.Distance(expectedPosition, playerGo.transform.position) <= 1f);
            Assert.True(player.getMovement() is SlidingMovement);
        }
    }
}