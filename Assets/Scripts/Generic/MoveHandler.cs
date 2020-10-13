using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    public Vector2 direction;
    
    private void Start() { }

    private void FixedUpdate()
    {
        var rigid = GetComponent<Rigidbody2D>();
        var pos = transform.position;
        rigid.MovePosition(new Vector2(pos.x + direction.x, pos.y + direction.y));
    }
}