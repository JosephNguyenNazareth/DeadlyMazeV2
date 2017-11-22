using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class FinishScreen : MonoBehaviour {
    // finishing canvas
    // appearing when reach finishing point in the ground
    public Transform FinishCanvas;
    // HUD canvas which shows player health bar and gun
    public Transform HUD;
    // memory panel: shows slot to save progress
    public Transform FPSController;

    /// <summary>
    ///  when player public static Player.Player CurrentPlayer = new Player.Player(); reach finish point (triggered zone)
    /// 1. Finish theme will be on
    /// 2. Finish panel appears
    /// 3. HUD (healthbar and gun) disappears
    /// </summary>
    /// <param name="other">
    /// our player
    /// </param>
    void OnTriggerEnter (Collider other) {
        // get in finish zone, compare to the player
        if (other.CompareTag ("FinishZone")) {
            // screen freeze
            Time.timeScale = 0;
            // show finish canvas and hide HUD canvas
            if (!FinishCanvas.gameObject.activeInHierarchy) {
                FinishCanvas.gameObject.SetActive (true);
                HUD.gameObject.SetActive (false);
                FPSController.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                FPSController.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

        }

    }
    /// <summary>
    /// Finish canvas contains
    /// 1. Continue button
    /// 2. Save game button
    /// 3. Main menu button
    /// 4. Stage progress
    /// </summary>
    ///

    public void ContinueTask(string levelName)
    {
       Application.LoadLevel(levelName);
    }
    /// <summary>
    /// Finish canvas contains
    /// 1. Continue button
    /// 2. Save game button
    /// 3. Main menu button
    /// 4. Stage progress
    /// </summary>
    public void SaveTask () {

    }
    /// <summary>
    /// Finish canvas contains
    /// 1. Continue button
    /// 2. Save game button
    /// 3. Quit button
    /// 4. Stage progress
    /// </summary>

}