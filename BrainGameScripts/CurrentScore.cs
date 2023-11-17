using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     // We need this line for uGUI to work.

public class CurrentScore : MonoBehaviour
{
    static private Text _UI_TEXT;                                        // a
    static private int _CSCORE = 0;                                   // b


    private Text txtCom;  // txtCom is a reference to this GO’s Text component

    void Awake()
    {                                                           // c
        _UI_TEXT = GetComponent<Text>();                                      // d
                                                                              // If the PlayerPrefs CScore already exists, read it
        if (PlayerPrefs.HasKey("CScore"))
        {                                        // a
            SCORE = PlayerPrefs.GetInt("CScore");
        }
        // Assign the C score to CScore
        PlayerPrefs.SetInt("CScore", SCORE);                                       // b
    }

    static public int SCORE
    {                                                 // e
        get { return _CSCORE; }
        private set
        {                                                        // f
            _CSCORE = value;
            PlayerPrefs.SetInt("CScore", value);                                   // c
            if (_UI_TEXT != null)
            {                                         // g
                _UI_TEXT.text = "Your Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_C_SCORE(int scoreToTry)
    {                 // h
        if (scoreToTry == SCORE) return; // If scoreToTry is the same
        SCORE = scoreToTry;
    }
    [Tooltip("Check this box to reset the CScore in PlayerPrefs")]
    public bool resetCScoreNow = false;                                           // d

    void OnDrawGizmos()
    {                                                            // e
        if (resetCScoreNow)
        {
            resetCScoreNow = false;
            PlayerPrefs.SetInt("CScore", 0);
            Debug.LogWarning("PlayerPrefs CScore reset to 0.");
        }
    }
}