using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{   
    private AudioSource _audioSource;

    private float _volume;
    private float _endVolume;
    private float _speed—hangesVolume = 0.1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SwitchVolume(float volumeValue)
    {
        _audioSource.Play();

        _endVolume = volumeValue;

        if (_volume == _audioSource.volume)
        {
            StopCoroutine(ChangeVolume());
        }

        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        var wait = new WaitForSeconds(1f);

        while (_audioSource.volume != _endVolume)
        {
            _volume = Mathf.MoveTowards(_audioSource.volume, _endVolume, _speed—hangesVolume);

            _audioSource.volume = _volume;

            Debug.Log(_audioSource.volume);

            yield return wait;
        }
        
        if(_audioSource.volume <= 0)
        {
            _audioSource.Stop();
        }
    }
}


