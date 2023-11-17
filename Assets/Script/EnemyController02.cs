using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController02 : EnemyFatherController
{
    // Movimentação
    [SerializeField] private float posMovY;
    [SerializeField] private Rigidbody2D rb;
    private bool podeMov = true;
    // Tiro do inimigo
    [SerializeField] private GameObject enemyBullet;
    private float timerBullet = 1f;
    [SerializeField] private float velTiro; 
    [SerializeField] private Transform posTiro;

    // Start is called before the first frame update
    void Start()
    {
        timerBullet = Random.Range(0.5f, 2f);
        // Alterando a velocidade inicial
        rb.velocity = new Vector2(0f, vel);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMov();
    }
    private void EnemyMov()
    {
        // Verificando se a sprite está visivel na tela
        bool visible = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (visible)
        {
            // Movimento do inimigo
            // Alterando a direção do inimigo
            if (transform.position.y < posMovY && podeMov == true)
            {
                if (transform.position.x < 0)
                {
                    rb.velocity = new Vector2(vel * -1f, vel);
                    podeMov = false;
                }
                else
                {
                    rb.velocity = new Vector2(vel * 1f, vel);
                    podeMov = false;
                }
            }
            // Metodo de tiros
            EnemyTiros();
        }
    }
    private void EnemyTiros()
    {
        var player = FindAnyObjectByType<PlayerController>();
        if (player)
        {
            // instanciando tiros com delay
            timerBullet -= Time.deltaTime;
            if (timerBullet < 0f)
            {
                // Instanciando o tiro
                var enemyTiro = Instantiate(enemyBullet, posTiro.position, posTiro.rotation);
                // Aplicando velocidade para baixo
                enemyTiro.GetComponent<Rigidbody2D>().velocity = Vector2.down * velTiro;
                // Randomizando o próximo tiro
                timerBullet = Random.Range(1.5f, 2f);
            }
        }
    }
}



