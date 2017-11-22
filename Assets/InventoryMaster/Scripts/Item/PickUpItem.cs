using UnityEngine;
using System.Collections;
public class PickUpItem : MonoBehaviour
{
    public Item item;
    private Inventory _inventory;
    public GameObject _player;
    // Use this for initialization

    void Start()
    {
        if (_player != null)
            _inventory = _player.GetComponent<_MAINPLAYER>().inventory;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Pickup");
            bool check = _inventory.checkIfItemAllreadyExist(item.itemID, item.itemValue);
            if (!check)
            {
                _inventory.addItemToInventory(item.itemID, item.itemValue);
                _inventory.updateItemList();
                _inventory.stackableSettings();
            }
            Destroy(this.gameObject);
        }

    }

}