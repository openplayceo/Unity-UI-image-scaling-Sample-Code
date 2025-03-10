using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerHpTestButton : MonoBehaviour
{
    [SerializeField] managerHpBarUpdate mngrBarUpdate;
    [SerializeField] Button btnHpAdd;
    [SerializeField] Button btnHpMinus;
    //
    [SerializeField] int hpMax = 100;
    [SerializeField] int testValue = 10;
    [SerializeField] int hpCurrent = 0;
    // Start is called before the first frame update
    void Start()
    {
        btnHpAdd.onClick.AddListener(() => HpUpdate(true));
        btnHpMinus.onClick.AddListener(() => HpUpdate(false));
        //
        hpCurrent = hpMax; // initialize
    }

    void HpUpdate (bool isHpPlus)
    {
        if(isHpPlus) // hp plus
        {
            if (hpCurrent < hpMax)
            {
                hpCurrent += testValue;
                hpCurrent = Mathf.Clamp(hpCurrent, 0, hpMax);
                //
                mngrBarUpdate.SetHpBarUpdate (hpCurrent, hpMax);
            }
            else
            {
                Debug.Log("Current hp is max");
            }
            
        }
        else // hp minus
        {
            if (hpCurrent <= 0)
            {
                Debug.Log("Current hp is 0");
            }
            else
            {
                hpCurrent -= testValue;
                hpCurrent = Mathf.Clamp(hpCurrent, 0, hpMax);
                //
                mngrBarUpdate.SetHpBarUpdate(hpCurrent, hpMax);
            }
            
        }
    }

}
