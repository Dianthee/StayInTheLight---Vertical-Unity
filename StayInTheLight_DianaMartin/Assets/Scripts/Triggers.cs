using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Triggers : MonoBehaviour
{

    public GameObject[] Save;
    public GameObject counter;
    public GameObject Key;
    public GameObject crying;

    public AudioSource audios;

    public float timeVal;

    public Text textoVictoria;
    public Text textoDerrota;
    public Text tiempoPartida;

    bool notSave;
    public bool haveKey;

    public Animator getKey;


    void Start()
    {
        haveKey = false;
        audios = crying.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(notSave){
            counter.SetActive(true);
            Timer();
        }else{

        }

    }

    void Timer(){

        tiempoPartida.text=timeVal.ToString("00");
        timeVal -= Time.deltaTime;

        if(timeVal<= 0){
             timeVal = 0;
         }

        if(timeVal<=0.0f){
            Debug.Log("Tiempo a 0");
             //scriptBola.GetComponent<BALLCONTROLLER>().ballSpeed = 0;
             textoDerrota.gameObject.SetActive(true);
        }


    }

    void OnTriggerStay(Collider Save) {
                
        switch (Save.tag)
        {
            case "YouAreSaveHere":
                Debug.Log("Now you are on a safe place!");
                counter.SetActive(false);
                notSave = false;
                timeVal=5f;
                tiempoPartida.text=timeVal.ToString("00");
            break;

            case "Key":
                if (Input.GetKeyDown(KeyCode.E)){
                Key.SetActive(false);
                haveKey = true;
                getKey.SetBool("GetKet",true);
                }
                    
            break;

            case "Door":

                if(Input.GetKeyDown(KeyCode.F) && Key){
                    
                }
            break;

            case "Crying":
                audios.Play();
            break;
        }
    }

    void OnTriggerExit(Collider Save) {

        notSave = true;
        Debug.Log("You aren't safe here!");
    }
}
