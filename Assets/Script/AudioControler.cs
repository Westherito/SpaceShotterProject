using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : GeradorInimigos
{
    [SerializeField] private AudioSource AudioMain;
    [SerializeField] private AudioClip Nivel1;
    [SerializeField] private AudioClip BossMusic;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (bossAnim != null)
        {
            AudioMain.clip = BossMusic;
        }
        else
        {
            AudioMain.clip = Nivel1;
        }
    }
}
