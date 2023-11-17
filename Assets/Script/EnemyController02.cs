using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController02 : EnemyFatherController
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject enemyBullet;

    private float timerBullet = 1f;
    [SerializeField] private float velTiro; 

    [SerializeField] private Transform posTiro;
    // Start is called before the first frame update
    void Start()
    {
        timerBullet = Random.Range(0.5f, 2f);
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
            // Alterando a velocidade 
            rb.velocity = new Vector2(0f, vel);
            // Metodo de tiros
            EnemyTiros();
        }
    }
    private void EnemyTiros()
    {
        // instanciando tiros com delay
        timerBullet -= Time.deltaTime;
        if (timerBullet < 0f)
        {
            // Instanciando o tiro
            var enemyTiro = Instantiate(enemyBullet, posTiro.position, posTiro.rotation);
            // Encontrando o player pelo script dele
            var player = FindAnyObjectByType<PlayerController>();
            // Subitraindo a posição do alvo com o tiro para dar a direção
            Vector2 dir = player.transform.position - enemyTiro.transform.position;
            dir.Normalize();
            // Aplicando a direçao e velocidade para o tiro
            enemyTiro.GetComponent<Rigidbody2D>().velocity = dir * velTiro;
            // Intervalos de tiros
            timerBullet = Random.Range(1f, 1.5f);
        }
    }
}



