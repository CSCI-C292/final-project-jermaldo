using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Safe : MonoBehaviour
{
    public string _realCombo = "";
    string _combo = "";

    //Objects
    public GameObject _redLight;

    public Texture _red;
    
    public Texture _white;

    public Character _player;


    void Awake()
    {
        
        int i, j;
        for (i=0; i<4; i++){
            j = Random.Range(0, 9);
            _realCombo = _realCombo + "" + j;
        }
        Debug.Log(_realCombo);
    }

    public void AddNumber(int num)
    {
        
        _redLight.GetComponent<RawImage>().texture = _white;
        if (_combo.Length < 4){
            _combo = _combo + num;
        }
    }


    void Update()
    {
        
        if (_combo.Length == 4){
            if(checkCombo()){
                OpenSafe();
            }else{
                _combo = "";
                _redLight.GetComponent<RawImage>().texture = _red;
            }
            
        }
    }
    bool checkCombo()
    {
        return _combo.Equals(_realCombo);
    }

    void OpenSafe()
    {
        _player._hasKey = true;
        gameObject.SetActive(false);
        _player._onItem = false;
    }
    
}
