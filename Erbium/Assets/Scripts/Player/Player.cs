using Characters;
using UnityEngine;

namespace Player {
    public class Player : MonoBehaviour, ICharacter {
        public void die() {
            throw new System.NotImplementedException();
        }

        public float getPhysicArmor() {
            throw new System.NotImplementedException();
        }

        public float getMagicArmor() {
            throw new System.NotImplementedException();
        }
    }
}