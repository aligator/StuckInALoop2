using Constants;
using UnityEngine;

namespace Generic
{
    public class Owner : MonoBehaviour
    {
        [SerializeField]
        private PlayerType _ownerType;
        public PlayerType OwnerType { get; private set; }

        public static GameObject Apply(GameObject gameObject, PlayerType owner) 
        {
            var meta = gameObject.AddComponent<Owner>();
            meta.OwnerType = owner;

            return gameObject;
        }
    }
}
