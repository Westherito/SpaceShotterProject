using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    private Vector2 movPlayer;
    [SerializeField] private float vel;
    [SerializeField] private GameObject tiros;
    private float velTiro = 10f;
    private int lifePlayer = 5;
    [SerializeField] GameObject Morte;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovimentoPlayer();
    }

    private void MovimentoPlayer()
    {
        // Pegando o Input do usu�rio e adicionando velocidade
        movPlayer.x = Input.GetAxis("Horizontal");
        movPlayer.y = Input.GetAxis("Vertical");
        // Normalizando a dire��o
        movPlayer.Normalize();
        // Passando para o player
        rbPlayer.velocity = movPlayer * vel;
        TirosPlayer();
    }
    // M�todo para instanciar os tiros do player
    private void TirosPlayer()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var playerTiro = Instantiate(tiros, transform.position, transform.rotation);
            playerTiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velTiro);
            
        }
    }

    public void PlayerLife(int dano)
    {
        lifePlayer -= dano;
        if (lifePlayer <= 0)
        {
            Destroy(gameObject);
            Instantiate(Morte, transform.position, transform.rotation);
            Recomecar();
        }
        // Testando a colis�o
        // Debug.Log(lifePlayer + " de vida do player!");
    }
    private void Recomecar()
    {
        
    }
}
