using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    public Transform followTarget; //Referencia al objeto de la camara tiene que seguir
    public Vector3 offset; //Variable para almacenar la diferencia vectorial entre cámara y objetivo

    // Start is called before the first frame update
    void Start()
    {
        //El vector comparativo entre dos posiciones surge de:
        //Vector del objetivo - vector original (en este caso, la cámara)
        offset = followTarget.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Los movimientos de camara se suelen codear en el LateUpdate
        Follower();
    }

    void Follower()
    {
        //La posicion de la camara = la posicion del objeto
        transform.position = followTarget.position - offset;
    }


}