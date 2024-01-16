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
    [SerializeField] private float timerBullet = 4f;
    [SerializeField] private float velTiro; 
    [SerializeField] private Transform posTiro;

    // Start is called before the first frame update
    void Start()
    {
        //ponto = Random.Range(100, 500);
        ponto = 500;
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
        float limiteY = 5.16f;
        if (this != null)
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
            if (transform.position.y < limiteY)
            {
                EnemyTiros();
            }
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
                // Subitraindo a posição do alvo com o tiro para dar a direção
                Vector2 dir = player.transform.position - enemyTiro.transform.position;
                dir.Normalize();
                // Aplicando a direçao e velocidade para o tiro
                enemyTiro.GetComponent<Rigidbody2D>().velocity = dir * velTiro;
                // Intervalos de tiros
                timerBullet = Random.Range(1f, 1.5f);

                // Adicionando Angulo que o tiro tem que estar
                // Nesse código ele calcula o angulo em um raio e é multiplicado pela conversão de raio para graus.
                float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                // Executando a rotação em direção ao Alvo
                enemyTiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);
            }
        }
    }
}



