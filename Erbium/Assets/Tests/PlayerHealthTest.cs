using System;
using System.Collections;
using Characters.Damage;
using NUnit.Framework;
using Projectiles;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

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
            float healthBeforeTakingDamage = player.getStats().health;
            DamageInfo damageInfo = new DamageInfo(10, DamageType.Physical);
            player.getHealthComponent().takeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(Math.Abs(healthBeforeTakingDamage - player.getStats().health) > 0.2f);
        }

        [UnityTest]
        public IEnumerator playerTakeDamageFromProjectile() {
            float healthBeforeTakingDamage = player.getStats().health;
            projectileGo.transform.position = Vector3.zero;

            yield return new WaitForSeconds(1f);

            Assert.True(Math.Abs(healthBeforeTakingDamage - player.getStats().health) > 0.2f);
        }

        [UnityTest]
        public IEnumerator die() {
            player.getStats().health = 10;
            player.getStats().physicArmour = 0;
            DamageInfo damageInfo = new DamageInfo(100, DamageType.Physical);
            player.getHealthComponent().takeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(Math.Abs(player.getStats().health) < 0.2f);
        }

        [UnityTest]
        public IEnumerator playerTakeDamageWithPhysicArmour() {
            float healthBeforeTakingDamage = player.getStats().health;
            DamageInfo damageInfo = new DamageInfo(10, DamageType.Physical);
            player.getHealthComponent().takeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(Math.Abs(healthBeforeTakingDamage - damageInfo.Damage + player.getStats().physicArmour -
                                 player.getStats().health) < 0.2f);
        }

        [UnityTest]
        public IEnumerator playerTakeDamageWithMagicArmour() {
            float healthBeforeTakingDamage = player.getStats().health;
            DamageInfo damageInfo = new DamageInfo(10, DamageType.Magical);
            player.getHealthComponent().takeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(Math.Abs(healthBeforeTakingDamage - damageInfo.Damage + player.getStats().magicArmour -
                                 player.getStats().health) < 0.2f);
        }

        [UnityTest]
        public IEnumerator playerTakeDamageWithToxicArmour() {
            float healthBeforeTakingDamage = player.getStats().health;
            DamageInfo damageInfo = new DamageInfo(10, DamageType.Toxic);
            player.getHealthComponent().takeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(Math.Abs(healthBeforeTakingDamage - damageInfo.Damage + player.getStats().toxicArmour -
                                 player.getStats().health) < 0.2f);
        }
    }
}