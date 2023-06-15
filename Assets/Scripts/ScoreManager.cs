using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score_textholder;
    public static int score = 0;

    void Update()
    {
        score_textholder.text = score.ToString();
    }
}
