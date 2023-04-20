using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio_play : MonoBehaviour
{
    // Start is called bef
    //
    // ore the first frame update
    [SerializeField] private AudioSource _audio;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void audio_play()
    {
        GetComponent<AudioSource>.Play();
    }
}
