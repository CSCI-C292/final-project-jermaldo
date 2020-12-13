using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    //Objects
    Rigidbody2D _rb;
    Animator _am;
    public Text _label;

    public Safe _safe;
    public TV _tv;
    public Window _win;

    //Variables
    public float _moveSpeed = 10f;
    Vector2 _movement;
    bool _onSafe = false;
    bool _onDoor = false;
    public  bool _hasKey = false;
    public bool _onItem = false;
    public bool _onTV = false;
    public bool _onWin = false;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _am = GetComponent<Animator>();
        _safe.gameObject.SetActive(true);
        _tv.gameObject.SetActive(true);
        _win.gameObject.SetActive(true);


        
        _win.gameObject.SetActive(false);
        _safe.gameObject.SetActive(false);
        _tv.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_onItem == false){
            Move();
        }
        
        
        

        if (Input.GetButtonDown("Use") && _onSafe){
            _safe.gameObject.SetActive(true);
            _onItem = true;
            _label.changeLabel("");
        }
        if (Input.GetButtonDown("Use") && _onDoor && _hasKey){
            SceneManager.LoadScene("EndScreen");
        }
        if (Input.GetButtonDown("Use") && _onTV){
            _tv.gameObject.SetActive(true);
        }
        if (Input.GetButtonDown("Use") && _onWin){
            _win.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Escape) && (_onTV || _onSafe || _onWin)){
            _tv.gameObject.SetActive(false);
            _safe.gameObject.SetActive(false);
            _win.gameObject.SetActive(false);
            _onTV = false;
            _onSafe = false;
            _onWin = false;
            _onItem = false;
        }
    }

    void OnTriggerEnter2D(Collider2D ob)
    {
        
        
        if (ob.name == "Safe"){
            _onSafe = true;
            _label.changeLabel("Safe (E)");
        }
        if (ob.name == "Door"){
            _onDoor = true;
            if (_hasKey){
                _label.changeLabel("Door (E)");
            }else{
                _label.changeLabel("You do not have a key to unlock the door.");
            }
        }
        if (ob.name == "TV"){
            _onTV = true;
            _label.changeLabel("Maybe you can find a clue by changing the channel");
        }
        if (ob.name == "Window"){
            _onWin = true;
            _label.changeLabel("There might be clues if you look outside.");
        }
    }


    void OnTriggerExit2D()
    {
        _onSafe = false;
        _onDoor = false;
        _onTV = false;
        _onWin = false;
        _label.changeLabel("");
    }

    void Move()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");

        _am.SetFloat("Speed", Mathf.Abs(_movement.x));
        if (Input.GetAxis("Horizontal") < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else if (Input.GetAxis("Horizontal") > 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        _rb.MovePosition(_rb.position+_movement*_moveSpeed*Time.deltaTime);
    }
}
