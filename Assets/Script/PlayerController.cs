using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movimentação
    [SerializeField] private Rigidbody2D rbPlayer;
    private Vector2 movPlayer;
    [SerializeField] private float vel;
    // Tiros do Player
    [SerializeField] private float timerBullet = 0.1f;
    [SerializeField] private GameObject tiros;
    [SerializeField] private GameObject tiros2;
    private float velTiro = 10f;
    [SerializeField] private int levelTiro = 1;
    [SerializeField] Rigidbody2D rbEscudo;
    // Vida do player
    [SerializeField] private int lifePlayer = 3;
    [SerializeField] private GameObject Morte;
    // Limite de tela
    [SerializeField] private float xMin, yMin, xMax, yMax;
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
    // Movimentação
    private void MovimentoPlayer()
    {
        // Pegando o Input do usuário e adicionando velocidade
        movPlayer.x = Input.GetAxis("Horizontal");
        movPlayer.y = Input.GetAxis("Vertical");
        // Normalizando a direção
        movPlayer.Normalize();
        // Passando para o player
        rbPlayer.velocity = movPlayer * vel;
        rbEscudo.velocity = movPlayer * vel;
        // Checando os limites do player na tela com Clamp
        float limiteX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float limiteY = Mathf.Clamp(transform.position.y, yMin, yMax);
        // Aplicando o limite 
        transform.position = new Vector3(limiteX, limiteY, transform.position.z);
        rbEscudo.transform.position = new Vector3(limiteX, limiteY, transform.position.z);

    }
    // Criando os tiros no jogo com sistema de level
    private void TirosPlayer()
    {

        if (Input.GetButton("Fire1"))
        {
            timerBullet -= Time.deltaTime;
            switch (levelTiro)
            {
                case 1:
                    if (timerBullet < 0f)
                    {
                        CriaTiro(tiros, transform.position);
                        timerBullet = 0.18f;
                    }
                    break;

                case 2:
                    if (timerBullet < 0f)
                    {
                        // Tiro esquerdo
                        Vector3 posTiro = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiro);
                        // Tiro direito
                        posTiro = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiro);
                        timerBullet = 0.12f;
                    }
                    break;
                case 3:
                    if (timerBullet < 0f)
                    {
                        CriaTiro(tiros, transform.position);
                        // Tiro esquerdo
                        Vector3 posTiroE = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiroE);
                        // Tiro direito
                        Vector3 posTiroD = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiroD);
                        timerBullet = 0.05f;
                    }
                    break;
                case 4:
                    if (timerBullet < 0f)
                    {
                        CriaTiro(tiros2, transform.position);
                        // Tiro esquerdo
                        Vector3 posTiroE = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros, posTiroE);
                        // Tiro direito
                        Vector3 posTiroD = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros, posTiroD);
                        timerBullet = 0.05f;
                    }
                    break;
            }
        }
    }
    // Criando os tiros com base no tipo de tiro recebido
    private void CriaTiro(GameObject playerTiro, Vector3 pos)
    {
        GameObject Tiro;
        Tiro = Instantiate(playerTiro, pos, transform.rotation);
        Tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velTiro);
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
    // Colisão com o PowerUp
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            levelTiro++;
            Destroy(collision.gameObject);
            if (levelTiro >= 4)
            {
                levelTiro = 4;
            }
        }
        
    }
    // Reinicio 
    private void Recomecar()
    {

    }
}
