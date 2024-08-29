
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControler : MonoBehaviour
{
    [SerializeField] private AudioSource AudioMain;
    [SerializeField] private AudioClip[] MusicaBG;

    public void BGMusic(int cena)
    {

        switch (cena) {
            case 0:
                TocarMusica(MusicaBG[0]);
                break;
            case 1:
                TocarMusica(MusicaBG[1]);
                break;
            case 2:
                TocarMusica(MusicaBG[2]);
                break;
            case 3:
                TocarMusica(MusicaBG[3]);
                break;
            case 4:
                TocarMusica(MusicaBG[4]);
                break;
        }        
    }
    public void TocarMusica(AudioClip clip)
    {
        AudioMain.Stop();
        AudioMain.clip = clip;
        AudioMain.loop = true;
        AudioMain.Play();
    }
}
