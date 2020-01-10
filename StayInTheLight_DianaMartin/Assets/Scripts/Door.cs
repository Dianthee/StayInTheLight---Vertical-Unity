using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject exit;
    
    [SerializeField]
    private GameObject door;

    private bool isOpen;

    public void ActiveDoor(){
        exit.SetActive(true);
    }

    //-90 z

    [ContextMenu("Open This Door")]
    private void OpenDoor()
    {
        StartCoroutine(OpeningDoor());
    }

    IEnumerator  OpeningDoor(){

        Debug.Log("Opening door");
        Quaternion newRotation = door.transform.rotation;
        newRotation *= Quaternion.Euler(0, 0, -90); // this add a 90 degrees Y rotation

        while (true)
        {

            door.transform.rotation = Quaternion.RotateTowards(door.transform.rotation, newRotation, 25f * Time.deltaTime);




            yield return null;
        }

    }

     public void Invoke()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerStay(Collider other) {

         if(other.tag == "Player"){
             if (FindObjectOfType<Triggers>().haveKey && Input.GetKeyDown(KeyCode.F)){
                 
                if (!isOpen){
                     StartCoroutine(OpeningDoor());
                     isOpen = true;
                     FindObjectOfType<Triggers>().notSave = false;
                     FindObjectOfType<Triggers>().Finish.SetActive(true);
                     FindObjectOfType<Triggers>().finishLev.SetTrigger("Finish");
                     Invoke("Invoke",5f);
                 }
             }
        }
    }
}
