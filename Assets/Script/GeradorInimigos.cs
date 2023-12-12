using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;
    [SerializeField] private int pontos = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private int baseLevel = 100;
    private float timer = 0f;
    [SerializeField] private float intervaloTimer = 5f;
    [SerializeField] private int qteInimigos = 0;
    [SerializeField] private GameObject bossAnim;
    private bool checkBoss = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (level < 10)
        {
            GeraInimigo();
        }
        else
        {
            GeraBoss();
        }
    }
    // Gerando Inimigos
    private void GeraInimigo()
    {
        // Timer para controla o tempo que gera os inimigos
        if (timer > 0f && qteInimigos <= 0)
        {
            timer -= Time.deltaTime;
        }
        // Gerando os inimigos
        if (timer <= 0f && qteInimigos <= 0)
        {
            // Quantide de inimigos na tela
            int numInimigos = level * 4;
            int tentativas = 0;
            while (numInimigos > qteInimigos)
            {
                // Controlando o laço para evitar travamentos
                tentativas++;
                if (tentativas > 500)
                {
                    break;
                }

                // Inicio da geração de inimigos
                GameObject inimigoCriado;
                // Chance de gerar outro tipod e inimigo
                float chance = Random.Range(0, level);
                if (chance > 1f)
                {
                    inimigoCriado = inimigos[1];
                }
                else
                {
                    inimigoCriado = inimigos[0];
                }
                // Posição onde Gera o inimigo
                Vector3 pos = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 17f), 0f);
                // Checando se existe algum inimigo no local
                bool check = CheckPos(pos, inimigoCriado.transform.localScale);
                // Criando o inimigo no jogo
                if (check)
                {
                    // Pulando etapa de criação de inimigo caso exista colisão com outro inimigo
                    continue;
                }
                Instantiate(inimigoCriado, pos, transform.rotation);
                qteInimigos++;

                timer = intervaloTimer;
            }
        }
    }

    private void GeraBoss()
    {
        if (qteInimigos <= 0 && timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        if (!checkBoss && timer <= 0f)
        {
            GameObject animBoss = Instantiate(bossAnim, Vector3.zero, transform.rotation);
            Destroy(animBoss, 6.05f);
            checkBoss = true;
        }
    }
    // Ganhando pontos
    public void GanhaPontos(int pontos)
    {
        // Ganhando e acumulando pontos
        this.pontos += pontos;
        if (this.pontos >= baseLevel)
        {
            // Aumentando o nivel
            this.level++;
            // Aumentando o requisito para o nivel
            baseLevel *= this.level;
        }
    }
    // Checando se existe um colisor no local criado
    private bool CheckPos(Vector3 pos, Vector3 size)
    {
        // Usando a fisica para checa se existe colisor
        Collider2D hit = Physics2D.OverlapBox(pos,size,0f);
        // retornando valores booleanos
        if (hit == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void DiminuiQte()
    {
        qteInimigos--;
    }
}
