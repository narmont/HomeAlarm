using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _increaseSignaling;
    [SerializeField] private UnityEvent<float> _reduceSignaling;
    
    private float maxVolume;
    private float minVolume;


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            _increaseSignaling?.Invoke(maxVolume);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _reduceSignaling?.Invoke(minVolume);
        }
    }
}
