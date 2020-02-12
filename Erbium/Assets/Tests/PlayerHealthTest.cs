using System.Collections;
using Characters.Damage;
using NUnit.Framework;
using Projectiles;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class PlayerHealthTest : AbstractTest {
        private GameObject projectileGo;
        private IProjectile projectile;

        [SetUp]
        public new void setUpTestScene() {
            projectileGo = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Projectile"));
            projectileGo.transform.position = new Vector3(10, 10, 10);
            gameObjects.Add(projectileGo);
            projectile = projectileGo.GetComponent<IProjectile>();
        }

        [TearDown]
        public new void afterTest() {
            projectile = null;
        }


        [UnityTest]
        public IEnumerator playerTakeDamage() {
            float healthBeforeTakingDamage = player.getStats().Health;
            DamageInfo damageInfo = new DamageInfo(10, DamageType.Physical);
            player.getHealthComponent().takeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(healthBeforeTakingDamage != player.getStats().Health);
        }

        [UnityTest]
        public IEnumerator playerTakeDamageFromProjectile() {
            float healthBeforeTakingDamage = player.getStats().Health;
            projectileGo.transform.position = Vector3.zero;

            yield return new WaitForSeconds(1f);

            Assert.True(healthBeforeTakingDamage != player.getStats().Health);
        }

        [UnityTest]
        public IEnumerator die() {
            player.getStats().Health = 10;
            player.getStats().PhysicArmour = 0;
            DamageInfo damageInfo = new DamageInfo(100, DamageType.Physical);
            player.getHealthComponent().takeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(0 == player.getStats().Health);
        }

        [UnityTest]
        public IEnumerator playerTakeDamageWithPhysicArmour() {
            float healthBeforeTakingDamage = player.getStats().Health;
            DamageInfo damageInfo = new DamageInfo(10, DamageType.Physical);
            player.getHealthComponent().takeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(healthBeforeTakingDamage - damageInfo.Damage  + player.getStats().PhysicArmour == player.getStats().Health);
        }
    }
}