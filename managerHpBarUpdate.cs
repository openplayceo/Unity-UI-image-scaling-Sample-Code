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
        // 필요 셋업
        Image tempHpParent = imgHpBar.transform.parent.GetComponent<Image>();
        hpLengthParent = tempHpParent.rectTransform.sizeDelta.x; // Stretch 사용시 필요한 부모 width 값

        // For Fill Amount + Scale : 초기값은 필요없을 수 있습니다!

        // For Width : Width 변경 시 초기값
        hpLengthDefault = imgHpBar.rectTransform.sizeDelta.x;
        hpLengthHeight = imgHpBar.rectTransform.sizeDelta.y;

        // For Stretch Right
        // Test : Stretch의 각 변수의 값 확인
        /*
        Debug.Log("Stretch Right : " + imgHpBar.rectTransform.offsetMax.x);
        Debug.Log("Stretch Left : " + imgHpBar.rectTransform.offsetMin.x);
        Debug.Log("Stretch Botton : " + imgHpBar.rectTransform.offsetMin.y);
        Debug.Log("Stretch Top : " + imgHpBar.rectTransform.offsetMax.y);
        */
        // 실제 사용되어야 하는 변수
        /*
        hpLengthDefault = imgHpBar.rectTransform.offsetMax.x; // 변경되어야 하는 변수
        hpLengthHeight = imgHpBar.rectTransform.offsetMax.y;
        */
    }

    public void SetHpBarUpdate(int currentHp, int maxHp)
    {

        // Filled & Scale X
        /*
        hpCurrent = remap(currentHp, 0, maxHp, 0, 1);
        imgHpBar.fillAmount = hpCurrent;
        imgHpBar.rectTransform.localScale = new Vector3(hpCurrent, 1, 1);
        */

        // Width
        hpCurrent = remap(currentHp, 0, maxHp, 0, hpLengthDefault);
        imgHpBar.rectTransform.sizeDelta = new Vector2(hpCurrent, hpLengthHeight);

        // Stretch Right
        /*
        hpCurrent = remap(currentHp, 0, maxHp, hpLengthParent, hpLengthDefault);
        imgHpBar.rectTransform.offsetMax = new Vector2(-hpCurrent, hpLengthHeight);
        */
    }

    // Hp의 범위와 이미지의 크기 범위를 변경
    float remap (float value, float in1, float in2, float out1, float out2)
    {
        return out1 + (value - in1) * (out2 - out1) / (in2 - in1);
    }

}
