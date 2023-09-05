using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbObj;
    [SerializeField] private float vel;

    // Start is called before the first frame update
    void Start()
    {
        //Movimento do tiro para cima
        rbObj.velocity = Vector2.up * vel;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
}
