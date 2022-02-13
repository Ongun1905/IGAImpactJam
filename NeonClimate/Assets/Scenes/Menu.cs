using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text text;
    private string[] messages;
    private int index = 0;

    void Start()
    {
        messages = new string[] {
            "No",
            "Jk",
            "Or not",
            "Just play bro",
            "..."
        };
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        if (index != messages.Length){
            text.text = messages[index];
            index++;
        }
    }
}
