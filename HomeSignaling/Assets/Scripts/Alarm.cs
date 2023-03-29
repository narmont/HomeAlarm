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
        float oneSecond = 1f;

        WaitForSeconds waitForOneSecond = new WaitForSeconds(oneSecond);

        while (_audioSource.volume != volumeValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volumeValue, _speedChangesVolume);

            yield return waitForOneSecond;
        }
        
        if(_audioSource.volume <= 0)
        {
            _audioSource.Stop();
        }
    }
}


