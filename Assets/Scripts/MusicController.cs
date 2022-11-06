using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip main;
    public AudioClip buildup;
    public AudioClip fanfare;
    public float volume = 0.5f;
    private bool kiteCollected = false;
    private bool buildupPlayed = false;
    private bool fanfarePlayed = true;
    private bool inZone = false;
    private AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!src.isPlaying)
        {
            if (kiteCollected && !fanfarePlayed) {
                src.PlayOneShot(fanfare, volume);
                fanfarePlayed = true;
            } else if (inZone && !kiteCollected) {
                if (!buildupPlayed)
                {
                    buildupPlayed = true;
                    src.PlayOneShot(buildup, volume);
                }
            } else {
                src.PlayOneShot(main, volume);
            }
        }
    }

    public void SetInZone(bool state)
    {
        if (state && !inZone) {
            inZone = true;
            if (!buildupPlayed)
            {
                src.Stop();
            }
        } else if (!state && inZone) {
            inZone = false;
        }
    }

    public void KiteCollected()
    {
        kiteCollected = true;
        src.Stop();
    }
}
