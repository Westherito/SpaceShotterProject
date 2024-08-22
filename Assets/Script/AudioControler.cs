
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControler : MonoBehaviour
{
    [SerializeField] private AudioSource AudioMain;
    [SerializeField] private AudioClip[] MusicaBG;
    public void BGMusic(string cena)
    {
        SceneManager.LoadScene(cena);
        switch (cena) {
            case "Menu":
                TocarMusica(MusicaBG[0]);
                break;
            case "lvl1":
                TocarMusica(MusicaBG[1]);
                break;
            case "lvl2":
                TocarMusica(MusicaBG[2]);
                break;
            case "lvl3":
                TocarMusica(MusicaBG[3]);
                break;
            case "GameOver":
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
