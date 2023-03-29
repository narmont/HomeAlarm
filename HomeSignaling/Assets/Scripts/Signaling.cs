using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _increaseSignaling;
    [SerializeField] private UnityEvent<float> _reduceSignaling;
    
    private float _maxVolume;
    private float _minVolume;


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out Player player))
        {
            _increaseSignaling?.Invoke(_maxVolume);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _reduceSignaling?.Invoke(_minVolume);
        }
    }
}
