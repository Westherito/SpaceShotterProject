using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    private Vector2 movPlayer;
    [SerializeField] private float vel;
    [SerializeField] private GameObject tiros;
    private int lifePlayer = 3;
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
        // Pegando o Input do usuário e adicionando velocidade
        movPlayer.x = Input.GetAxis("Horizontal");
        movPlayer.y = Input.GetAxis("Vertical");
        // Normalizando a direção
        movPlayer.Normalize();
        // Passando para o player
        rbPlayer.velocity = movPlayer * vel;
        TirosPlayer();
    }
    // Método para instanciar os tiros do player
    private void TirosPlayer()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(tiros, transform.position, transform.rotation);
        }
    }

    public void PlayerLife(int dano)
    {
        lifePlayer -= dano;
        // Testando a colisão
        // Debug.Log(lifePlayer + " de vida do player!");
    }
}
