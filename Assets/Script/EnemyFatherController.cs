using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFatherController : MonoBehaviour
{

    [SerializeField] protected GameObject Morte;
    [SerializeField] protected float vel;
    [SerializeField] protected int lifeEnemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyLife(int dano)
    {
        lifeEnemy -= dano;
        if (lifeEnemy <= 0)
        {
            Destroy(gameObject);
            Instantiate(Morte, transform.position, transform.rotation);
        }
    }
}
