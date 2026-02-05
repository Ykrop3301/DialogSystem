using Characters;
using UnityEngine;
namespace Common
{
    public class Trigger : MonoBehaviour
    {
        [field: SerializeField] public System.Type NeedType { get; private set; }
        public event System.Action<Player> Enter;

        private void OnTriggerEnter(Collider other)
        {
            Player player;
            if (other.TryGetComponent(out player))
                Enter?.Invoke(player);
        }
    }
}