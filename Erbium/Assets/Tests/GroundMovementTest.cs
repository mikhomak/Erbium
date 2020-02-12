using System.Collections;
using System.Collections.Generic;
using Characters.Movement;
using General;
using NSubstitute;
using NUnit.Framework;
using Player;
using Player.MovementDirection;
using UnityEngine;
using UnityEngine.TestTools;
using static NSubstitute.Substitute;

namespace Tests {
    public class GroundMovementTest: AbstractTest {

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
            IMovementDirection moveDirection = For<IMovementDirection>();
            var direction = new Vector3(0, 0, 1);
            player.changeMovementDirection(moveDirection);
            moveDirection.getDirection().Returns(direction);
            Vector3 playerInitPosition = playerGo.transform.position;
            Assert.True(player.getMovement() is GroundMovement);
            yield return new WaitForSeconds(1f);

            Vector3 expectedPosition = playerInitPosition + direction * (player.getStats().Speed * 1f);
            Assert.True(Vector3.Distance(expectedPosition, playerGo.transform.position) <= 0.2f);
            Assert.True(player.getMovement() is GroundMovement);
        }
    }
}