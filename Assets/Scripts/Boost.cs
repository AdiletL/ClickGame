using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    [SerializeField] Image _Freezing, _Distruction;
    public static bool freezing, distruction;
    private float counterFreez, countDistr;

    private void Update()
    {
        if (!Menu._MENU)
        {
            if (_Freezing.fillAmount != 0)
            {
                _Freezing.fillAmount -= .001f;
                if (freezing)
                {
                    counterFreez += Time.deltaTime;
                    if (counterFreez >= 3)
                    {
                        freezing = false;

                    }
                }
                else
                {
                    counterFreez = 0;
                }
            }
            else
            {
                freezing = true;
                _Freezing.fillAmount = 1;
            }

            if (_Distruction.fillAmount != 0)
            {
                _Distruction.fillAmount -= .0005f;
                if (distruction)
                {
                    countDistr += Time.deltaTime;
                    if (countDistr > 1.7f)
                    {
                        distruction = false;
                    }
                }
                else
                {
                    countDistr = 0;
                }
            }
            else
            {
                distruction = true;
                _Distruction.fillAmount = 1;
            }
        }
    }
}
