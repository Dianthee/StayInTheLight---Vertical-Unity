using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Triggers : MonoBehaviour
{

    public GameObject[] Save;
    public GameObject counter;

    public float timeVal;

    public Text textoVictoria;
    public Text textoDerrota;
    public Text tiempoPartida;

    bool notSave;


    void Start()
    {
        
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

    void OnTriggerEnter(Collider Save) {
                
        switch (Save.tag)
        {
            case "YouAreSaveHere":
                Debug.Log("Now you are on a safe place!");
                counter.SetActive(false);
                notSave = false;
                timeVal=5f;
                tiempoPartida.text=timeVal.ToString("00");
            break;
        }
    }

    void OnTriggerExit(Collider Save) {

        notSave = true;
        Debug.Log("You aren't safe here!");
    }
}
