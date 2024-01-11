using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController03 : EnemyFatherController
{
    // Movimenta��o
    [SerializeField] private Rigidbody2D rb;
    // Tiro do inimigo
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float timerBullet = 2f;
    [SerializeField] private float velTiro;
    [SerializeField] private Transform posTiro;
    // Start is called before the first frame update
    void Start()
    {
        ponto = Random.Range(500, 1000);
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
        // Verificando se a sprite est� visivel na tela
        float limiteY = 5;

        if (this != null)
        {
            // Alterando a velocidade 
            rb.velocity = new Vector2(0f, vel);
            // Metodo de tiros
            if (transform.position.y <= limiteY)
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
                // Subitraindo a posi��o do alvo com o tiro para dar a dire��o
                Vector2 dir = player.transform.position - enemyTiro.transform.position;
                dir.Normalize();
                // Aplicando a dire�ao e velocidade para o tiro
                enemyTiro.GetComponent<Rigidbody2D>().velocity = dir * velTiro;
                // Intervalos de tiros
                timerBullet = Random.Range(0.5f, 0.9f);

                // Adicionando Angulo que o tiro tem que estar
                // Nesse c�digo ele calcula o angulo em um raio e � multiplicado pela convers�o de raio para graus.
                float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                // Executando a rota��o em dire��o ao Alvo
                enemyTiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);
            }
        }
    }
}
