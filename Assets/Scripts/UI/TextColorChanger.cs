using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChanger : MonoBehaviour
{
    public Color colorSel;
    public Color colorUnsel;
    public void changeColorSelected()
    {
        Text target = transform.GetComponent<Text>();
        target.color = colorSel;
    }
    public void changeColorUnselected()
    {
        Text target = transform.GetComponent<Text>();
        target.color = colorUnsel;
    }
}
