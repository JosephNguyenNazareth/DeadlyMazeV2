using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PicMovement : MonoBehaviour {

	public Image t;
	public float TimeLoad;
	IEnumerator Start()
	{
		yield return new WaitForSeconds (TimeLoad*10.5f);
		t.gameObject.SetActive (true);
		yield return new WaitForSeconds (10.4f);
		t.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.0f);
	}
}
