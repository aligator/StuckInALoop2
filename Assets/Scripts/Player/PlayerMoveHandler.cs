using System.Data;
using UnityEngine;

namespace Player {
    public class PlayerMoveHandler : MonoBehaviour {
        private const float Speed = 0.1f;

        private Rigidbody2D body;
        private Vector2 max;

        private Vector2 min;

        private void Start() {
            body = GetComponent<Rigidbody2D>();
            var cam = Camera.main;

            if (cam == null) throw new NoNullAllowedException();

            var playerSize = GetComponent<SpriteRenderer>().sprite.bounds.extents;

            min = cam.ViewportToWorldPoint(new Vector3()) + playerSize;
            max = cam.ViewportToWorldPoint(cam.rect.size) - playerSize;
        }

        private void FixedUpdate() {
            var newPosition = transform.position;

            if (Input.GetKey(KeyCode.W)) newPosition.y += Speed;
            if (Input.GetKey(KeyCode.S)) newPosition.y -= Speed;
            if (Input.GetKey(KeyCode.A)) newPosition.x -= Speed;
            if (Input.GetKey(KeyCode.D)) newPosition.x += Speed;

            if (newPosition.x < min.x) newPosition.x = min.x;
            if (newPosition.x > max.x) newPosition.x = max.x;

            if (newPosition.y < min.y) newPosition.y = min.y;
            if (newPosition.y > max.y) newPosition.y = max.y;

            body.MovePosition(newPosition);
        }
    }
}