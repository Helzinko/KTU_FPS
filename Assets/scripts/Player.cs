using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
   public void HittedByBullet()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
