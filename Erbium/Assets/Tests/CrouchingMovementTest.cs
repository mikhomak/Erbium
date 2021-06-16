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
    public class CrouchingMovementTest: AbstractTest {

        [UnityTest]
        public IEnumerator CrouchTest() {
            IMovementDirection moveDirection = For<IMovementDirection>();
            var direction = new Vector3(0, 0, 1);
            player.ChangeMovementDirection(moveDirection);
            moveDirection.GetDirection().Returns(direction);
            player.ChangeMovement(MovementEnum.Crouch);
            Vector3 playerInitPosition = playerGo.transform.position;
            Assert.True(player.getMovement() is CrouchingMovement);
            yield return new WaitForSeconds(1f);

            Vector3 expectedPosition = playerInitPosition + direction * player.getStats().crouchSpeed;
            Assert.True(Vector3.Distance(expectedPosition, playerGo.transform.position) <= 0.2f);
            Assert.True(player.getMovement() is CrouchingMovement);
        }
    }
}