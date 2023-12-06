using UnityEngine;

public class BossController : EnemyFatherController
{
    // Estados do Boss e movimento
    [SerializeField] private string estadoAtual = "estado1";
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D col;
    [SerializeField] private float limiteX, limiteY;
    private bool dir = true;
    // Tiro do Boss
    [SerializeField] private Transform posTiroMid, posTiroDir, posTiroEsq;
    [SerializeField] private GameObject tiroBoss;
    private float timerBullet;
    [SerializeField] private float delayTiro;
    [SerializeField] private string[] estados;
    [SerializeField] private float timerEstado = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrocaEstado();
        switch (estadoAtual) 
        {
            case "estado1" :
                Estado1();
                break;
            case "estado2":
                Estado2();
                break;
            case "estado3":
                Estado3();
                break;
        }
    }

    private void Estado1()
    {
        // mudando a direção do boss direita e esquerda
        if (dir == true)
        {
            rb.velocity = new Vector2(vel, 0f);
            TiroBoss1();
        }
        else
        {
            rb.velocity = new Vector2(-vel, 0f);
            TiroBoss1();
        }
        // var de controle para o boss
        if (transform.position.x >= limiteX)
        {
            dir = false;
        }
        if (transform.position.x <= -limiteX)
        {
            dir = true;
        }
    }
    private void Estado2()
    {
        TiroBoss2();
    }
    private void Estado3()
    {
        // mudando a direção do boss direita e esquerda
        if (dir == true)
        {
            rb.velocity = new Vector2(vel, 0f);
            TiroBoss3();
        }
        else
        {
            rb.velocity = new Vector2(-vel, 0f);
            TiroBoss3();
        }
        // var de controle para o boss
        if (transform.position.x >= limiteX)
        {
            dir = false;
        }
        if (transform.position.x <= -limiteX)
        {
            dir = true;
        }
    }
    private void TrocaEstado()
    {
        timerEstado -= Time.deltaTime;
        if (timerEstado <= 0f)
        {
            // escolhendo o estado
            int est = Random.Range(0,3);
            estadoAtual = estados[est];
            timerEstado = 10f;
        }
    }
    private void TiroBoss1()
    {
        var player = FindAnyObjectByType<PlayerController>();
        if (player)
        {
            // instanciando tiros com delay
            timerBullet -= Time.deltaTime;
            if (timerBullet < 0f)
            {
                /// Instanciando o tiro do meio 
                var enemyTiro = Instantiate(tiroBoss, posTiroMid.position, posTiroMid.rotation);
                // Aplicando velocidade para baixo
                enemyTiro.GetComponent<Rigidbody2D>().velocity = Vector2.down * vel;
                // Randomizando o próximo tiro
                timerBullet = delayTiro;
            }
        }
    }
    private void TiroBoss2()
    {
        var player = FindAnyObjectByType<PlayerController>();
        if (player)
        {
            // instanciando tiros com delay
            timerBullet -= Time.deltaTime;
            if (timerBullet < 0f)
            {
                /// Instanciando o tiro da direita
                var enemyTiro = Instantiate(tiroBoss, posTiroDir.position, posTiroDir.rotation);
                // Subitraindo a posição do alvo com o tiro para dar a direção
                Vector2 dir = player.transform.position - enemyTiro.transform.position;
                dir.Normalize();
                // Aplicando a direçao e velocidade para o tiro
                enemyTiro.GetComponent<Rigidbody2D>().velocity = dir * vel;
                // Adicionando Angulo que o tiro tem que estar
                // Nesse código ele calcula o angulo em um raio e é multiplicado pela conversão de raio para graus.
                float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                // Executando a rotação em direção ao Alvo
                enemyTiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);

                /// Instanciando o tiro da esquerda
                enemyTiro = Instantiate(tiroBoss, posTiroEsq.position, posTiroEsq.rotation);
                // Subitraindo a posição do alvo com o tiro para dar a direção
                dir = player.transform.position - enemyTiro.transform.position;
                dir.Normalize();
                // Aplicando a direçao e velocidade para o tiro
                enemyTiro.GetComponent<Rigidbody2D>().velocity = dir * vel;
                // Intervalos de tiros
                // Adicionando Angulo que o tiro tem que estar
                // Nesse código ele calcula o angulo em um raio e é multiplicado pela conversão de raio para graus.
                angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                // Executando a rotação em direção ao Alvo
                enemyTiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);

                timerBullet = delayTiro / 2f;
            }
        }
    }
    private void TiroBoss3()
    {
        var player = FindAnyObjectByType<PlayerController>();
        if (player)
        {
            // instanciando tiros com delay
            timerBullet -= Time.deltaTime;
            if (timerBullet < 0f)
            {
                /// Instanciando o tiro da direita
                var enemyTiro = Instantiate(tiroBoss, posTiroDir.position, posTiroDir.rotation);
                // Subitraindo a posição do alvo com o tiro para dar a direção
                Vector2 dir = player.transform.position - enemyTiro.transform.position;
                dir.Normalize();
                // Aplicando a direçao e velocidade para o tiro
                enemyTiro.GetComponent<Rigidbody2D>().velocity = dir * vel;
                // Adicionando Angulo que o tiro tem que estar
                // Nesse código ele calcula o angulo em um raio e é multiplicado pela conversão de raio para graus.
                float angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                // Executando a rotação em direção ao Alvo
                enemyTiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);

                /// Instanciando o tiro da esquerda
                enemyTiro = Instantiate(tiroBoss, posTiroEsq.position, posTiroEsq.rotation);
                // Subitraindo a posição do alvo com o tiro para dar a direção
                dir = player.transform.position - enemyTiro.transform.position;
                dir.Normalize();
                // Aplicando a direçao e velocidade para o tiro
                enemyTiro.GetComponent<Rigidbody2D>().velocity = dir * vel;
                // Intervalos de tiros
                // Adicionando Angulo que o tiro tem que estar
                // Nesse código ele calcula o angulo em um raio e é multiplicado pela conversão de raio para graus.
                angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                // Executando a rotação em direção ao Alvo
                enemyTiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);

                /// Instanciando o tiro do meio 
                enemyTiro = Instantiate(tiroBoss, posTiroMid.position, posTiroMid.rotation);
                // Subitraindo a posição do alvo com o tiro para dar a direção
                dir = player.transform.position - enemyTiro.transform.position;
                dir.Normalize();
                // Aplicando a direçao e velocidade para o tiro
                enemyTiro.GetComponent<Rigidbody2D>().velocity = dir * vel;
                // Intervalos de tiros
                // Adicionando Angulo que o tiro tem que estar
                // Nesse código ele calcula o angulo em um raio e é multiplicado pela conversão de raio para graus.
                angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                // Executando a rotação em direção ao Alvo
                enemyTiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);

                timerBullet = delayTiro;
            }
        }
    }
}
