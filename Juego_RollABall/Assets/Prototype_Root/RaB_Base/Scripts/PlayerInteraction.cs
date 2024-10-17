using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Libreria para poder refereciar elementos de User Interface
using TMPro;
using Unity.VisualScripting; //Libreria para poder referenciar elementos de Text Mesh Pro
public class PlayerInteraction : MonoBehaviour
{


    [Header("UI References")]
    public TMP_Text pointsText; //Ref al texto de UI que quiero que cambie dinamicamente segun los puntos del player

    [Header("Scene Management")]
    public SceneChanger sceneManagerScript;
    public int sceneToLoad;

    //Variable para definir los puntos del jugador
    [Header("Point System Parameters")]
    public int currentPoints;
    public int winPoints;
    public GameObject winGoal;

    [Header("Respawn Parameters")]
    public Transform respawnPoint;
    public float respawnFallLimit;

    void Update()
    {
        if (currentPoints < 0) { currentPoints = 0; }
        if (transform.position.y <= respawnFallLimit) { Respawn(); }
        if (currentPoints >= winPoints) { winGoal.SetActive(true); }
        UIUpdater();
        

        
    }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                currentPoints += 1;
                other.gameObject.SetActive(false);
                //Destoy(other.gameObject); es otra forma de desactivarlo
            }

            if (other.gameObject.CompareTag("PickDown"))
            {
                currentPoints -= 1;
                other.gameObject.SetActive(false);
                //Destoy(other.gameObject); es otra forma de desactivarlo
            }
            if (other.gameObject.CompareTag("Finish"))
            {
                WinCall();
                other.gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstacle")) { Respawn(); }
        }

        void Respawn()
        {
            transform.position = respawnPoint.position;
        }

        void UIUpdater()
        {
            pointsText.text = "Points: " + currentPoints.ToString() + "/" + winPoints.ToString();
        }
        void WinCall()
        {
        //Accion del cambio de escena
        sceneManagerScript.SceneLoader(sceneToLoad);
        }
    }
