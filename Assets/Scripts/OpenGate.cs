using System.Collections;
using UnityEngine;

public class OpenGate : MonoBehaviour {
    public int Direction;
	public Transform finish;
	public Hotbar hotbar;
    private Vector3 offset;
    private Vector3 pos;
    void Start()
    {
        if (Direction == 0) offset = new Vector3(0,1,0);
        else if (Direction == 1) offset = new Vector3(0,-1,0);
        else if (Direction == 2) offset = new Vector3(1,0,0);
        else if (Direction == 3) offset = new Vector3(-1,0,0);
        else if (Direction == 4) offset = new Vector3(0,0,1);
        else if (Direction == 5) offset = new Vector3(0,0,-1);

        pos = finish.transform.position;
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag ("key")){
            transform.position = pos + offset;
            pos = transform.position;

			int slotsInTotal = hotbar.getSlotsInTotal();
			Debug.Log (slotsInTotal);

			for (int i = 0; i < slotsInTotal; i++)
			{
				if (transform.GetChild (1).GetChild (i).childCount != 0 && transform.GetChild (1).GetChild (i).GetChild (0).GetComponent<ItemOnObject> ().item.itemID == 18) {
					Debug.Log ("UNLOCK");
				}
			}
        }
    }
}