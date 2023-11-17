using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Main : MonoBehaviour
{
    static private Main S;
    public ScoreCounter scoreCounter;
    public GameObject CrateGameObject;
    public Text TimeLeft;
    public float timeLeft = 200;

    [Header("Inscribed")]          
    public float CrateSpawnPerSecond = 0.3f;

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeLeft / 60);
            float seconds = Mathf.FloorToInt(timeLeft % 60);
            TimeLeft.text = string.Format("Time Remaining {0:00}:{1:00}", minutes, seconds);
        }
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
   
    }

    private void Awake()
    {
        S = this;

        Invoke(nameof(SpawnCrate), 1f / CrateSpawnPerSecond);
    }
    
    public void SpawnCrate()
    {
        GameObject Crate = Instantiate<GameObject>(CrateGameObject);
        Vector3 pos = Vector3.zero;
        pos.x = Random.Range(-7.5f, 7.5f);
        pos.y = 11f;
        Crate.transform.position = pos;

        Invoke(nameof(SpawnCrate), 1f / CrateSpawnPerSecond);
    }
}
