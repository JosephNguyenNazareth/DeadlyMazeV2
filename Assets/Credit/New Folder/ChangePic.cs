using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangePic : MonoBehaviour {

	public Image t;
	public Sprite t1;
	public Sprite t2;
	public Sprite t3;
	public Sprite t4;
	public Sprite t5;
	public Sprite t6;
	public Sprite t7;
	public Sprite t8;
	public Sprite t9;
	public Sprite t10;


	public float TimeLoad;

	IEnumerator Start()
	{
		Sprite[] spr = { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 };
		for (int i = 0; i < 10; i++) 
		{
				SetImage (spr [i]);
				yield return new WaitForSeconds (5.0f);
		}
		yield return new WaitForSeconds (0.0f);
	}

	public void SetImage(Sprite spr) //method to set our first image
	{
		t.GetComponent<Image> ().sprite = spr;
	}
}
