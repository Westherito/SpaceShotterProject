using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    private Vector2 movPlayer;
    [SerializeField] private float vel;
    [SerializeField] private float timerBullet = 0.2f;
    [SerializeField] private GameObject tiros;
    private float velTiro = 10f;
    private int lifePlayer = 3;
    [SerializeField] private GameObject Morte;
    [SerializeField] private float  xMin, yMin, xMax, yMax;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovimentoPlayer();
        TirosPlayer();
    }
    // Movimenta��o
    private void MovimentoPlayer()
    {
        // Pegando o Input do usu�rio e adicionando velocidade
        movPlayer.x = Input.GetAxis("Horizontal");
        movPlayer.y = Input.GetAxis("Vertical");
        // Normalizando a dire��o
        movPlayer.Normalize();
        // Passando para o player
        rbPlayer.velocity = movPlayer * vel;

        // Checando os limites do player na tela com Clamp
        float limiteX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float limiteY = Mathf.Clamp(transform.position.y, yMin, yMax);
        // Aplicando o limite 
        transform.position = new Vector3(limiteX, limiteY, transform.position.z);

    }
    // Criando os tiros
    private void TirosPlayer()
    {
        if (Input.GetButton("Fire1"))
        {
            timerBullet -= Time.deltaTime;
            if (timerBullet < 0f)
            {
                var playerTiro = Instantiate(tiros, transform.position, transform.rotation);
                playerTiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velTiro);
                timerBullet = 0.2f;
            }
        }
    }
    // Destruindo player caso ele perda todas as vidas e reiniciando o jogo
    public void PlayerLife(int dano)
    {
        lifePlayer -= dano;
        if (lifePlayer <= 0)
        {
            Destroy(gameObject);
            Instantiate(Morte, transform.position, transform.rotation);
            Recomecar();
        }
    }
    // Reinicio 
    private void Recomecar()
    {
        
    }
}
