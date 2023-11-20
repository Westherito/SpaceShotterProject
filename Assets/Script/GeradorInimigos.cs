using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;
    [SerializeField] private int pontos = 0;
    [SerializeField] private int level = 1;
    private float timer = 0f;
    [SerializeField] private float intervaloTimer = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GeraInimigo();
    }

    private void GeraInimigo()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0f)
        {
            int numInimigos = level * 4;
            int qteInimigos = 0;
            while (numInimigos > qteInimigos)
            {
                GameObject inimigoCriado;

                float chance = Random.Range(0, level);
                if (chance > 2f)
                {
                    inimigoCriado = inimigos[1];
                }
                else
                {
                    inimigoCriado = inimigos[0];
                }

                Vector3 pos = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 17f), 0f);

                Instantiate(inimigoCriado, pos, transform.rotation);

                qteInimigos++;

                timer = intervaloTimer;
            }
        }
    }

    public void GanhaPontos(int pontos)
    {
        this.pontos = pontos;
        if (this.pontos <= 100)
        {
            this.level++;
        }
    }
}
