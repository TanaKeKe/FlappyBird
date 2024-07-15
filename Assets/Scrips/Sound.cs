using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume *= 0.5f;
        button.GetComponent<Button>().onClick.AddListener(audioSource.Play);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
