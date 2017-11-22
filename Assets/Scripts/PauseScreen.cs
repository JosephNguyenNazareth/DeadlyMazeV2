using System.Collections;
using UnityEngine;

public class PauseScreen : MonoBehaviour {
    /// <summary>
    /// Pause canvas appears when user press "Esc"
    /// </summary>
    public Transform PauseCanvas;
    /// <summary>
    /// Finish canvas appears when user reach finish zone
    /// At this time, pause canvas deactivated
    /// </summary>
    public Transform FinishCanvas;
    public Transform FPSController;
    public Transform FirstPerson;
    private Vector3 rot1;
    private Vector3 rot2;
	GameObject MainPlayer;
	void Start(){
		MainPlayer = GameObject.Find ("FirstPersonCharacter");
	}
    void Update () {
		
        if (!FinishCanvas.gameObject.activeInHierarchy) {
            if (Input.GetKeyDown (KeyCode.Escape)) {
                rot1 = FPSController.gameObject.transform.rotation.eulerAngles;
                rot2 = FirstPerson.gameObject.transform.rotation.eulerAngles;
                ResumeTask ();
            }
			if (PauseCanvas.gameObject.activeInHierarchy) {
                FPSController.gameObject.transform.eulerAngles = rot1;
                FirstPerson.gameObject.transform.eulerAngles = rot2;
            }
        }
    }
    /// <summary>
    /// Resume task will back to game play
    /// </summary>
    public void ResumeTask () {
        if (!PauseCanvas.gameObject.activeInHierarchy) {
            PauseCanvas.gameObject.SetActive (true);
            Time.timeScale = 0;

        } else {
            PauseCanvas.gameObject.SetActive (false);
            Time.timeScale = 1;
            FPSController.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
        }
    }
    /// <summary>
    /// Save task will store your game progress in game slot.
    /// User can store multiple slot, or overwrite slot
    /// at any time in stage
    /// </summary>
    public void SaveTask () {

    }
    /// <summary>
    /// Load task will read your game progress in game slot.
    /// User can read in any slot, although that slot does not load currently
    /// at any time in stage
    /// </summary>
    public void LoadTask () {
		
    }
	public void OptionTask(){
	}
    public void Quit () {
        Application.Quit ();
    }
}