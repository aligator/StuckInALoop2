using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    public Vector2 direction;
    
    private void Start() { }

    private void FixedUpdate()
    {
        var position = transform.position;
        position.Set(position.x + direction.x, position.y + direction.y, 0);
        transform.position = position;
    }
}