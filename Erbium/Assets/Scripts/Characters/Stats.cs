using UnityEngine;

namespace Characters {
    public class Stats : MonoBehaviour {
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float health;

        public float RotationSpeed {
            get => rotationSpeed;
            set => rotationSpeed = value;
        }

        public float Speed {
            get => speed;
            set => speed = value;
        }

        public float Health {
            get => health;
            set => health = value;
        }


    }
}