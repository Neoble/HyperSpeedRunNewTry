using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarCountDown : MonoBehaviour
{
    public Text textObjekt;
    public GameObject menueObjekt;
    private float timer = 4;
    public static bool play = false;
    private bool textbool = true;

    void Start()
    {
        menueObjekt.SetActive(true);
        textObjekt.text = string.Empty;
    }

    void Update()
    {
        if (textbool)
        {
            timer -= Time.deltaTime;
            textObjekt.text =((int)timer).ToString();
            if (timer <= 0)
            {
                play = true;
                menueObjekt.SetActive(false);
                textbool = false;
            }
        }
    }
}
