using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadePic : MonoBehaviour {

	public Image t;
	public float TimeLoad;
	IEnumerator Start()
	{
		yield return new WaitForSeconds (TimeLoad*10.5f);
		t.gameObject.SetActive (true);
		t.canvasRenderer.SetAlpha (0.0f);
		t.CrossFadeAlpha (1.0f, 1.0f, false);
		yield return new WaitForSeconds (8.0f);
		t.CrossFadeAlpha (0.0f, 2.5f, false);
		yield return new WaitForSeconds (2.5f);
	}
}