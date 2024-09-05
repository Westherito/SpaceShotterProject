using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private AudioControler AudioControler;
    void Start()
    {
        AudioControler.BGMusic(0);
    }

    public void CarregarCena()
    {
        SceneManager.LoadScene(1);                                                
        AudioControler.BGMusic(1);
    }

    public void Exit()
    {
        Application.Quit(1);
    }
}

