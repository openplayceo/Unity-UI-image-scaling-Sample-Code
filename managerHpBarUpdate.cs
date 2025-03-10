using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerHpBarUpdate : MonoBehaviour
{
    [SerializeField] Image imgHpBar;
    float hpCurrent;
    //
    float hpLengthDefault; // default length of the bar
    float hpLengthHeight; // vector2.y of the bar
    float hpLengthParent; // parent length of the Bar

    // Start is called before the first frame update
    void Start()
    {
        Image tempHpParent = imgHpBar.transform.parent.GetComponent<Image>();
        hpLengthParent = tempHpParent.rectTransform.sizeDelta.x;

        // For Width
        //hpLengthDefault = imgHpBar.rectTransform.sizeDelta.x;
        //hpLengthHeight = imgHpBar.rectTransform.sizeDelta.y;

        // For Stretch Right
        // Test
        /*Debug.Log("Stretch Right : " + imgHpBar.rectTransform.offsetMax.x);
        Debug.Log("Stretch Left : " + imgHpBar.rectTransform.offsetMin.x);
        Debug.Log("Stretch Botton : " + imgHpBar.rectTransform.offsetMin.y);
        Debug.Log("Stretch Top : " + imgHpBar.rectTransform.offsetMax.y);*/
        hpLengthDefault = imgHpBar.rectTransform.offsetMax.x;
        hpLengthHeight = imgHpBar.rectTransform.offsetMax.y;
    }

    public void SetHpBarUpdate(int currentHp, int maxHp)
    {

        // Filled & Scale X
        //hpCurrent = remap(currentHp, 0, maxHp, 0, 1);
        //imgHpBar.fillAmount = hpCurrent;
        //imgHpBar.rectTransform.localScale = new Vector3(hpCurrent, 1, 1);

        // Width
        //hpCurrent = remap(currentHp, 0, maxHp, 0, hpLengthDefault);
        //imgHpBar.rectTransform.sizeDelta = new Vector2(hpCurrent, hpLengthHeight);

        // Stretch Right
        hpCurrent = remap(currentHp, 0, maxHp, hpLengthParent, hpLengthDefault);
        imgHpBar.rectTransform.offsetMax = new Vector2(-hpCurrent, hpLengthHeight);

    }

    float remap (float value, float in1, float in2, float out1, float out2)
    {
        return out1 + (value - in1) * (out2 - out1) / (in2 - in1);
    }

}
