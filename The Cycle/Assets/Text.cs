using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Text : MonoBehaviour
{
    public void changeLabel(string name)
    {
        GetComponent<TextMeshProUGUI>().text = name;
    }
}
