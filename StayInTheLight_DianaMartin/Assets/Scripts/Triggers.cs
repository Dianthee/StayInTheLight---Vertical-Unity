﻿using System.Collections;
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
    public GameObject soundKey;
    public GameObject soundOpen;

    public GameObject pressE;
    public GameObject Finish;
    public GameObject textoDerrota;

    public AudioSource audios;
    public AudioSource keys;
    public AudioSource openDoor;

    public float timeVal;

    
    public Text tiempoPartida;

    public bool notSave;
    public bool haveKey;

    public Animator getKey, finishLev;


    void Start()
    {
        haveKey = false;
        audios = crying.GetComponent<AudioSource>();
        keys = soundKey.GetComponent<AudioSource>();
        openDoor = soundOpen.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(notSave){
            counter.SetActive(true);
            Timer();
        }else{

        }

    }

    public void Invoke()
    {
        SceneManager.LoadScene(1);
    }

    void Timer(){

        tiempoPartida.text=timeVal.ToString("00");
        timeVal -= Time.deltaTime;

        if(timeVal<= 0){
             timeVal = 0;
         }

        if(timeVal<=0.0f){
            Debug.Log("Tiempo a 0");
            textoDerrota.gameObject.SetActive(true);
            FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().GetComponent<CharacterController>().enabled = false;
            Invoke("TestInvoke",2f);
        }


    }

    public void TestInvoke()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    void OnTriggerStay(Collider Save) {
                
        switch (Save.tag)
        {
            case "YouAreSaveHere":
                Debug.Log("Now you are on a safe place!");
                counter.SetActive(false);
                notSave = false;
                timeVal=4f;
                tiempoPartida.text=timeVal.ToString("00");
            break;

            case "Key":
                pressE.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E)){
                    keys.Play();
                    Key.SetActive(false);
                    haveKey = true;
                    getKey.SetTrigger("Start");
                    pressE.SetActive(false);
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

        switch (Save.tag)
        {
         case "Key":
                pressE.SetActive(false);
            break;
        }
    }
}
