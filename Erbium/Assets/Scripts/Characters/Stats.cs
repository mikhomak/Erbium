using UnityEngine;

namespace Characters {
    public class Stats : MonoBehaviour {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float rotationSpeed = 0.1f;
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