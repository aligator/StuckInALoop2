using UnityEngine;

public class PlayerMoveHandler : MonoBehaviour
{
    private readonly int SPEED = 10;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        var transformPosition = transform.position;

        if (Input.GetKey(KeyCode.W)) transformPosition.y += SPEED * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) transformPosition.y -= SPEED * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) transformPosition.x -= SPEED * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) transformPosition.x += SPEED * Time.deltaTime;

        transform.position = transformPosition;
    }
}