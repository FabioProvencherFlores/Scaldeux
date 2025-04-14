using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class sliding_door : MonoBehaviour
{
    [SerializeField]
    Transform closedDoorTrans, openDoorTrans;
    public GameObject doorObj;
    public Animator doorAnim;


    private float timeCount;
    private float speed = 0.1f;
    private bool doorClosed;
    private Transform currentDoorTrans, targetDoorTrans;

    void Start()
    {
        currentDoorTrans = closedDoorTrans;
    }


    //keep track of target transform, function called from door_switch script
    public void doorInteract()
    {
        if(currentDoorTrans == closedDoorTrans)
        {
            Debug.Log("Opening door");
            targetDoorTrans = openDoorTrans;
        }else if(currentDoorTrans == openDoorTrans)
        {
            Debug.Log("Closing door");
            targetDoorTrans = closedDoorTrans;
        }
        slideDoor();
    }

    //to-do : make the door smoothly move to the target position , maybe Lerp or MoveTowards ??
    void slideDoor()
    {
        doorObj.transform.position = new Vector3(targetDoorTrans.transform.position.x, targetDoorTrans.transform.position.y, targetDoorTrans.transform.position.z);
        currentDoorTrans = targetDoorTrans; 
    }
}
