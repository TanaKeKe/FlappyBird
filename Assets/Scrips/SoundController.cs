using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    #region Bật nhạc cho GamePlay
    public void PlayThisSound(string nameClip,float multiVolume)
    {
        AudioSource source = this.gameObject.AddComponent<AudioSource>();
        source.PlayOneShot((AudioClip)Resources.Load("Sounds/" + nameClip,typeof(AudioClip)));
        source.volume *= multiVolume;
    }
    #endregion
}
