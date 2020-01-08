using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    IEnumerator  OpenDoor(){

        Debug.Log("Opening door");
        while (true)
        {
            yield return null;
        }

    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player")
            if (FindObjectOfType<Triggers>().haveKey && Input.GetKeyDown(KeyCode.F))
                if (!isOpen)
                {
                    StartCoroutine(OpenDoor());
                    isOpen = true;
                }
    }
}
