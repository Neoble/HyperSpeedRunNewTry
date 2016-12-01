using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public GameObject uiObjektPC;
    public GameObject uiObjektAndroid;
    public GameObject Player;
    public Slider uiSlider;
    public UIHandler handle;
#if UNITY_STANDALONE
    
    void Start()
    {
        uiObjektPC.SetActive(true);
        uiObjektAndroid.SetActive(false);
    }

#endif

#if UNITY_ANDROID
    void Start()
    {
        uiObjektPC.SetActive(false);
        uiObjektAndroid.SetActive(true);
        uiSlider.value = 0.5f;
    }

    void Update()
    {
        if (Player.transform.position.x<Player.transform.position.x-1.0f*Time.deltaTime)
        {
            uiSlider.value--;
        }
        if (Player.transform.position.x > Player.transform.position.x - 1.0f * Time.deltaTime)
        {
            uiSlider.value++;
        }
        else
            uiSlider.value=0.5f;
    }
#endif
}
