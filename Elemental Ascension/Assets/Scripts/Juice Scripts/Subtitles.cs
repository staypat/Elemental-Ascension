using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitles : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text subtitleText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowSubtitle(string text)
    {
        subtitleText.text = text;
        subtitleText.gameObject.SetActive(true);
    }
    public void HideSubtitle()
    {
        subtitleText.gameObject.SetActive(false);
    }
}
