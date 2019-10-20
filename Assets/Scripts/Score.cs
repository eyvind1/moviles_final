using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int lifes = 0;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        lifes = 0;
        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(int amt)
    {
        lifes += amt;
        UpdateDisplay();
    }
    void UpdateDisplay()
    {
        text.text = "Lifes: "+ lifes;
    }
}
