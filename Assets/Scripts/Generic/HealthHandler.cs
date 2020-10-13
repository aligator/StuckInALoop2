using Constants;
using UnityEngine;

namespace Generic
{
    public class HealthHandler : MonoBehaviour
    {
        
        [SerializeField]
        private int health = 1;

        private Owner _meta;
        
        private void Start()
        {
            _meta = GetComponent<Owner>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.name != Name.Shot)
            {
                return;
            }

            var otherMeta = other.GetComponent<Owner>();
            if (otherMeta == null || otherMeta.OwnerType == _meta.OwnerType)
            {
                return;
            }
            
            Destroy(other);
            health--;
            Debug.Log("KIIIILLLLLL" + name + " " + other.name);
        }
    }
}