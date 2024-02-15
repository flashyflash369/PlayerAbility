using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InteractWithItems : MonoBehaviour
{

    //UI to show when Player in Range to pickup a Collectable
    [SerializeField] public GameObject PickupUI;
    public TextMeshProUGUI newItemObtainedUI;
    Item item;


    //Variable to take input
    public bool isPickingUp = false;

    public void OnPickup(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            isPickingUp = true;
        }
    }
    private void Awake()
    {
        PickupUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        PickupUI.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            if (isPickingUp)
            {
                PickupUI.SetActive(false);
                other.GetComponent<Animator>().enabled = true;
                DisplayNewItemObtained(other.gameObject);
              
                StartCoroutine(DelayDestruction(other.gameObject));
                isPickingUp = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickupUI.SetActive(false);
    }

    private IEnumerator DelayDestruction(GameObject interactable)
    {
        yield return new WaitForSeconds(2);
        Destroy(interactable );
    }

    //Code to display UI of the new Item
    private void DisplayNewItemObtained(GameObject collectable)
    {
        //Get item and display UI
        item = collectable.GetComponent<Item>();
        newItemObtainedUI.text = $"You have obtained [{item.itemInfos.itemName}]";
        newItemObtainedUI.transform.parent.gameObject.SetActive(true);
    }
}
