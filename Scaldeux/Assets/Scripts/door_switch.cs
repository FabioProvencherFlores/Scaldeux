using UnityEngine;

public class door_switch : MonoBehaviour
{
    [SerializeField]
    public GameObject door;

    bool interactable = false;


    void Update()
    {
        if(interactable)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interact switch)");
                door.GetComponent<sliding_door>().doorInteract();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            interactable = true;
            Debug.Log("look at switch");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable = false;
            Debug.Log("no look at switch");
        }
    }
}
