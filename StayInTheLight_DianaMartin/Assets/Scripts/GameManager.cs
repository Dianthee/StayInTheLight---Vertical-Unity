using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Door[] doors;

    // Start is called before the first frame update
    void Start()
    {
        doors = FindObjectsOfType<Door>();

        int indexDoorActive = Random.Range(0, doors.Length);
        doors[indexDoorActive].ActiveDoor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
