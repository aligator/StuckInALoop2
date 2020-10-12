using UnityEngine;

namespace Generic {
    public class ShootingHandler : MonoBehaviour {
        [SerializeField] private GameObject prefabShot;

        [SerializeField] private Vector2 force;

        [SerializeField] private bool flip;

        [SerializeField] private float firePauseTime;

        public bool isShooting;

        private float nextShot;

        private void Start() {
            nextShot = 0.0f;
        }

        private void FixedUpdate() {
            if (!isShooting) return;

            if (Time.fixedTime < nextShot) return;

            nextShot = Time.fixedTime + firePauseTime;
            SpawnShot();
        }

        private GameObject SpawnShot() {
            // Create the new shot.
            var newShot = Instantiate(prefabShot);

            // Position the new shot.
            newShot.transform.position = transform.position;

            newShot.GetComponent<SpriteRenderer>().flipX = flip;

            // Apply a force.
            var move = newShot.GetComponent<MoveHandler>();
            move.direction = new Vector2(force.x * (flip ? -1 : 1), force.y);
            return newShot;
        }
    }
}