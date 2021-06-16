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
        private GameObject _projectileGo;
        private IProjectile _projectile;

        [SetUp]
        public new void SetUpTestScene() {
            _projectileGo = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Enemies/Projectile"));
            _projectileGo.transform.position = new Vector3(10, 10, 10);
            gameObjects.Add(_projectileGo);
            _projectile = _projectileGo.GetComponent<IProjectile>();
        }

        [TearDown]
        public new void AfterTest() {
            _projectile = null;
        }


        [UnityTest]
        public IEnumerator PlayerTakeDamage() {
            float healthBeforeTakingDamage = player.getStats().health;
            DamageInfo damageInfo = new DamageInfo(10, DamageType.Physical);
            player.getHealthComponent().TakeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(Math.Abs(healthBeforeTakingDamage - player.getStats().health) > 0.2f);
        }

        [UnityTest]
        public IEnumerator PlayerTakeDamageFromProjectile() {
            float healthBeforeTakingDamage = player.getStats().health;
            _projectileGo.transform.position = Vector3.zero;

            yield return new WaitForSeconds(1f);

            Assert.True(Math.Abs(healthBeforeTakingDamage - player.getStats().health) > 0.2f);
        }

        [UnityTest]
        public IEnumerator Die() {
            player.getStats().health = 10;
            player.getStats().physicArmour = 0;
            DamageInfo damageInfo = new DamageInfo(100, DamageType.Physical);
            player.getHealthComponent().TakeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(Math.Abs(player.getStats().health) < 0.2f);
        }

        [UnityTest]
        public IEnumerator PlayerTakeDamageWithPhysicArmour() {
            float healthBeforeTakingDamage = player.getStats().health;
            DamageInfo damageInfo = new DamageInfo(10, DamageType.Physical);
            player.getHealthComponent().TakeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(Math.Abs(healthBeforeTakingDamage - damageInfo.damage + player.getStats().physicArmour -
                                 player.getStats().health) < 0.2f);
        }

        [UnityTest]
        public IEnumerator PlayerTakeDamageWithMagicArmour() {
            float healthBeforeTakingDamage = player.getStats().health;
            DamageInfo damageInfo = new DamageInfo(10, DamageType.Magical);
            player.getHealthComponent().TakeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(Math.Abs(healthBeforeTakingDamage - damageInfo.damage + player.getStats().magicArmour -
                                 player.getStats().health) < 0.2f);
        }

        [UnityTest]
        public IEnumerator PlayerTakeDamageWithToxicArmour() {
            float healthBeforeTakingDamage = player.getStats().health;
            DamageInfo damageInfo = new DamageInfo(10, DamageType.Toxic);
            player.getHealthComponent().TakeDamage(damageInfo);

            yield return new WaitForEndOfFrame();

            Assert.True(Math.Abs(healthBeforeTakingDamage - damageInfo.damage + player.getStats().toxicArmour -
                                 player.getStats().health) < 0.2f);
        }
    }
}