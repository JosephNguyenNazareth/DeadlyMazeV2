using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Monster;
using UnityEngine.UI;
public class Shooting1 : MonoBehaviour {

	public float damage = 20f;
	public float range = 100f;
	public float fireRate = 15f;
	public Camera FpsCam;
	public ParticleSystem ShootEffect;
	public GameObject ImpactEffect;
	public float impactForce = 30f;
    public Text bullet_number;

	private float nextTimeToFire=0f;
    void Start()
    {
        bullet_number.text = _MAINPLAYER.CurrentPlayer.PlayerGun.GetHGBullet().ToString()+"/40";
    }
	void Update ()
	{
		if (Input.GetKeyDown (_MAINPLAYER.CurrentPlayer.Shoot) && Time.time >= nextTimeToFire )
		{
			//getbuttondown để bắn từng phát
			nextTimeToFire = Time.time + 1f / fireRate;
            if (_MAINPLAYER.CurrentPlayer.PlayerGun.GetHGBullet() > 0)
            {
                Shoot();
                int tmp = _MAINPLAYER.CurrentPlayer.PlayerGun.GetHGBullet();
                _MAINPLAYER.CurrentPlayer.PlayerGun.SetHGBullet(tmp - 1);
                --tmp;
                bullet_number.text = tmp.ToString() + "/40";
            }
		}

	}
	public void Shoot()
	{
		ShootEffect.Play ();

		RaycastHit hit;
		if (Physics.Raycast (FpsCam.transform.position, FpsCam.transform.forward, out hit, range)) {
			Debug.Log (hit.transform.name);
			Monster.Monster target = hit.transform.GetComponent<Monster.Monster> ();

			if (target != null) {
				target.TakeDamage (damage);
			}
			if (hit.rigidbody != null) {
				hit.rigidbody.AddForce (hit.normal * impactForce);
			}
			GameObject impactGO = Instantiate (ImpactEffect, hit.point, Quaternion.LookRotation (hit.normal));
			Destroy (impactGO, 2f);
		}
	}
}
