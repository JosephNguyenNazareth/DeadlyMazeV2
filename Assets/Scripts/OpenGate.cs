using System.Collections;
using UnityEngine;

public class OpenGate : MonoBehaviour {
    public int Direction;
	public Transform finish;
	public Transform clue;
	public Hotbar hotbar;
    private Vector3 offset;
    private Vector3 pos;
	private Vector3 pos1;
    void Start()
    {
        if (Direction == 0) offset = new Vector3(0,20,0);
        else if (Direction == 1) offset = new Vector3(0,-10,0);
        else if (Direction == 2) offset = new Vector3(10,0,0);
        else if (Direction == 3) offset = new Vector3(-10,0,0);
        else if (Direction == 4) offset = new Vector3(0,0,10);
        else if (Direction == 5) offset = new Vector3(0,0,-10);

        pos = finish.transform.position;
		pos1 = clue.transform.position;
    }

    void OnTriggerEnter (Collider other) {
        if (other.CompareTag ("key")){
 			int slotsInTotal = hotbar.getSlotsInTotal();
			Debug.Log (slotsInTotal);

			for (int i = 0; i < slotsInTotal; i++)
			{
				if (hotbar.transform.GetChild (1).GetChild (i).childCount != 0 && hotbar.transform.GetChild (1).GetChild (i).GetChild (0).GetComponent<ItemOnObject> ().item.itemID == 18) {
					finish.gameObject.transform.position = pos + offset;
					clue.gameObject.transform.position = pos1 + offset;

				}
			}
        }
    }
}