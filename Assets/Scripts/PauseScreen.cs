using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {
    /// <summary>
    /// Pause canvas appears when user press "Esc"
    /// </summary>
    public Transform PauseCanvas;
    public Transform LoadCanvas;
    public Transform SettingCanvas;
	public Transform CreditCanvas;
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
        MainPlayer.transform.position = new Vector3(_MAINPLAYER.CurrentPlayer.x, _MAINPLAYER.CurrentPlayer.y, _MAINPLAYER.CurrentPlayer.z);
    }
    void Update () {
        if (!FinishCanvas.gameObject.activeInHierarchy) {
            if (Input.GetKeyDown (KeyCode.Escape)) {
                rot1 = FPSController.gameObject.transform.rotation.eulerAngles;
                rot2 = FirstPerson.gameObject.transform.rotation.eulerAngles;
				CreditCanvas.gameObject.SetActive (false);
                ResumeTask ();               
            }
			if (PauseCanvas.gameObject.activeInHierarchy || LoadCanvas.gameObject.activeInHierarchy || SettingCanvas.gameObject.activeInHierarchy || CreditCanvas.gameObject.activeInHierarchy) {
                FPSController.gameObject.transform.eulerAngles = rot1;
                FirstPerson.gameObject.transform.eulerAngles = rot2;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (LoadCanvas.gameObject.activeInHierarchy)
            {
                LoadCanvas.gameObject.SetActive(false);
                PauseCanvas.gameObject.SetActive(true);
            }
            if (SettingCanvas.gameObject.activeInHierarchy)
            {
                SettingCanvas.gameObject.SetActive(false);
                PauseCanvas.gameObject.SetActive(true);
            }
        }
    }
    /// <summary>
    /// Resume task will back to game play
    /// </summary>
    public void ResumeTask () {
		if (!PauseCanvas.gameObject.activeInHierarchy || CreditCanvas.gameObject.activeInHierarchy) {
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
        _MAINPLAYER.CurrentPlayer.x = MainPlayer.transform.position.x;
        _MAINPLAYER.CurrentPlayer.y = MainPlayer.transform.position.y;
        _MAINPLAYER.CurrentPlayer.z = MainPlayer.transform.position.z;
        _MAINPLAYER.CurrentPlayer.SetScene(SceneManager.GetActiveScene().name);
        Player.SaveDataProcessing.Save(ref _MAINPLAYER.CurrentPlayer);
    }
    /// <summary>
    /// Load task will read your game progress in game slot.
    /// User can read in any slot, although that slot does not load currently
    /// at any time in stage
    /// </summary>
    public void LoadTask () {
        PauseCanvas.gameObject.SetActive(false);
        LoadCanvas.gameObject.SetActive(true);
        // Cursor.visible = true;
    }
	public void SettingTask(){
        PauseCanvas.gameObject.SetActive(false);
        SettingCanvas.gameObject.SetActive(true);
        // Cursor.lockState = CursorLockMode.None;
        // Cursor.visible = true;
    }
    public void Quit () {
        Application.Quit ();
    }
}