using Generic;
using UnityEngine;

namespace Player {
    public class PlayerShootHandler : MonoBehaviour {
        private ShootingHandler shootingHandler;

        private void Start() {
            shootingHandler = GetComponent<ShootingHandler>();
        }

        private void FixedUpdate() {
            shootingHandler.isShooting = Input.GetKey(KeyCode.Space);
        }
    }
}