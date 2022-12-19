using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace KeySystem{
    public class KeyItemController : MonoBehaviour
{

    [SerializeField] private bool redDoor = false;
[SerializeField] private bool redKey = false;
[SerializeField] private KeyInventory _keyInventory = null;
private KeyDoorController doorObject;


// Start is called before the first frame update
private void Start()
{
    if (redDoor)
    {
        doorObject = GetComponent<KeyDoorController>();

    }
}

public void ObjectInteraction()
{
    if (redDoor)
    {
        doorObject.PlayAnimation();
    }
    else if (redKey)
    {
        _keyInventory.hasRedKey = true;
        gameObject.SetActive(false);
    }
}

// Update is called once per frame
void Update()
{

}
}

}
