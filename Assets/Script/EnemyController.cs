using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : EnemyFatherController
{
    // Movimento
    [SerializeField] private Rigidbody2D rb;
    // Tiros do inimigo
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float timerBullet = 3f;
    [SerializeField] private float velTiro;
    [SerializeField] private Transform posTiro;
    // Start is called before the first frame update
    void Start()
    {
        ponto = Random.Range(1, 100);
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
        float limiteY = 5.16f;

        if (this != null)
        {
            // Alterando a velocidade 
            rb.velocity = new Vector2(0f, vel);
            // Metodo de tiros
            if (transform.position.y < limiteY)
            {
                EnemyTiros();
            }
        }
    }
    private void EnemyTiros()
    {
        // Instanciando tiros com delay
        // Encontrando o player pelo script dele
        var player = FindAnyObjectByType<PlayerController>();
        if (player)
        {
            timerBullet -= Time.deltaTime;
            if (timerBullet < 0f)
            {
                // Instanciando o tiro
                var enemyTiro = Instantiate(enemyBullet, posTiro.position, posTiro.rotation);
                // Aplicando velocidade para baixo
                enemyTiro.GetComponent<Rigidbody2D>().velocity = Vector2.down * velTiro;
                // Randomizando o próximo tiro
                timerBullet = Random.Range(1f, 1.5f);
            }
        }
    }
}
