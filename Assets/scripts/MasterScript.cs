using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterScript : MonoBehaviour
{
    public bool canContinue = false;

    public GameObject winPanel;

    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    private void Start()
    {
        winPanel.SetActive(false);
    }

    void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        if (Input.GetKeyDown(KeyCode.Return) && canContinue)
        {
            //next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
