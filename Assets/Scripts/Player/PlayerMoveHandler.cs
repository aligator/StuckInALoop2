using UnityEngine;

namespace Player {
    public class PlayerMoveHandler : MonoBehaviour {
        private const float Speed = 0.1f;

        private Rigidbody2D body;

        private void Start() {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            var transformPosition = transform.position;

            if (Input.GetKey(KeyCode.W)) transformPosition.y += Speed;
            if (Input.GetKey(KeyCode.S)) transformPosition.y -= Speed;
            if (Input.GetKey(KeyCode.A)) transformPosition.x -= Speed;
            if (Input.GetKey(KeyCode.D)) transformPosition.x += Speed;

            body.MovePosition(transformPosition);
        }
    }
}