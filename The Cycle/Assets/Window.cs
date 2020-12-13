using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public Text _label;
    public TV _tv;

    int _streetName;

    
    void Update()
    {
        _streetName = _tv._wantedChannel;
        Debug.Log(_streetName);
        _label.changeLabel("" + _streetName);
    }
}
