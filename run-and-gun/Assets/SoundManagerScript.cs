using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip fireShotSound, enemyScreamSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        fireShotSound = Resources.Load<AudioClip>("fireShotSFX");
        enemyScreamSound = Resources.Load<AudioClip>("enemyScreamSFX");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "shot":
                audioSrc.PlayOneShot(fireShotSound);
                break;
            case "scream":
                audioSrc.PlayOneShot(enemyScreamSound);
                break;
        }
    }
}
