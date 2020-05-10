using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

	public string mainMenu;

	private MenuManager mm;
	public GameObject thePauseScreen;

	private Evo thePlayer;

	// Use this for initialization
	void Start () {

		mm = FindObjectOfType<MenuManager> ();
        StartCoroutine("FindPlayer");
	}

    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.25f);
        thePlayer = FindObjectOfType<Evo> ();
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Cancel")) 
		{
			if (Time.timeScale == 0) 
			{
				ResumeGame ();
			} 
			else 
			{
				PauseGame ();
			}
	
		}
	}

	public void PauseGame()
	{
		Time.timeScale = 0;
		thePauseScreen.SetActive (true);
		
		
	}


	public void ResumeGame ()
	{
		Time.timeScale = 1;
		thePauseScreen.SetActive (false);
		
	}

	public void QuitToMainMenu ()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene (mainMenu);
	}
}
