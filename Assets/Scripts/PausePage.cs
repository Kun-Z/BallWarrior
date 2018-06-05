using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePage : MonoBehaviour {

	// Use this for initialization
    UnityEngine.Events.UnityAction [] actions ;

	void Start () {
        Button[] PauseButton = GetComponentsInChildren<Button>();
        for (int i = 0; i < PauseButton.Length; i++)
        {
            var b = PauseButton[i];
            b.onClick.AddListener(()=> {
                Invoke(b.name, 0);
            });
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Share()
    {
        print("22222222222222222222");
    }

    private void Restart()
    {
        SceneManager.LoadScene(1);
    }

    private void Exit()
    {
        SceneManager.LoadScene(1);
    }

    private void Continue()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}
