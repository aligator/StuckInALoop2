using Constants;
using Generic;
using UnityEngine;

public class DestroyBulletsHandler : MonoBehaviour
{
    private Owner _meta;

    private void Start()
    {
        _meta = GetComponent<Owner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != Name.Shot) return;

        var otherMeta = other.GetComponent<Owner>();
        if (otherMeta == null || otherMeta.OwnerType == _meta.OwnerType) return;

        Debug.Log("asdf");
        Destroy(other);
    }
}