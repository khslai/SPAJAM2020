using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();
        ShuffleBGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShuffleBGM()
    {
        source.clip = clips[Random.Range(0,clips.Length)];
        source.Play();
    }
}
