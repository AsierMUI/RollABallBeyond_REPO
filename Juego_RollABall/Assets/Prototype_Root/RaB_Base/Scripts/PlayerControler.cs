using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControler : MonoBehaviour
{
    [Header("Public References")] //para ordenar y añadir espacios
    public Rigidbody playerRb; //Variable para referenciar el Rigidbody del jugador y asi modificarlo cuando quiera por codigo

    [Header("Movement Variables")] 
    public float speed;
    private float horInput; //Almacen del vector x del input
    private float verInput; //Almacen del vector y del input (se lo pasare al eje z)

    [Header("Jump Variables")]
    public float jumpForce;
    public bool isGrounded = true;



    void Start()
    {
        
    }

    void Update()
    {
        //Conectar las variables floar al input de teclado
        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");
        Jump();

    }

    private void FixedUpdate()
    {
        Movement();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Movement()
    {
        //Velocidad del rigidbody = Vector 3(movimiento en x, constante y; movimiento en z)
        playerRb.velocity = new Vector3(horInput * speed, playerRb.velocity.y, verInput * speed);
    }

    void Jump()
    {
            if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                isGrounded = false;
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }


}
