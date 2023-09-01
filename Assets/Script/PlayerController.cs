using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    private Vector2 movPlayer;
    [SerializeField] private float vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movPlayer.x = Input.GetAxis("Horizontal") * vel;
        movPlayer.y = Input.GetAxis("Vertical") * vel;
        rbPlayer.velocity = movPlayer;

    }
}
