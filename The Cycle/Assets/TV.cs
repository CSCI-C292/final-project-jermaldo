using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TV : MonoBehaviour
{
    int _currentChannel = 1;
    public int _wantedChannel;
    public Text _label;
    public Text _safeCombo;
    public Safe _safe;



    public Animator _anim;
    void Update()
    {
        if (_currentChannel == _wantedChannel){
            _anim.SetBool("CorrectChannel", true);
            _safeCombo.changeLabel(_safe._realCombo);
        }else{
            _anim.SetBool("CorrectChannel", false);
            _safeCombo.changeLabel("");
        }
        if (Input.GetButtonDown("Down")){
            if (_currentChannel > 2){
                _currentChannel--; 
            }
        }
        if(Input.GetButtonDown("Up")){
            if (_currentChannel < 99){
                _currentChannel++;
            }
        }
        _label.changeLabel("" + _currentChannel);
    }
    void Awake()
    {
        _wantedChannel = Random.Range(0, 99);
    }
    
}
