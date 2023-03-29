using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{   
    private AudioSource _audioSource;
    private Coroutine _changeVolume;

    private float _speedChangesVolume = 0.1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SwitchVolume(float volumeValue)
    {
        _audioSource.Play();

        if (_changeVolume != null)
        {
            StopCoroutine(_changeVolume);
        }

        _changeVolume = StartCoroutine(ChangeVolume(volumeValue));
    }

    private IEnumerator ChangeVolume(float volumeValue)
    {
        var wait = new WaitForSeconds(1f);

        while (_audioSource.volume != volumeValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volumeValue, _speedChangesVolume);

            yield return wait;
        }
        
        if(_audioSource.volume <= 0)
        {
            _audioSource.Stop();
        }
    }
}


