using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerWalk : Photon.MonoBehaviour


{

    public PhotonView photonView;
    public Game game;

    public int _speed;//variable vitesse
    public SpriteRenderer sR;
    private Vector3 velocity = Vector3.zero;
    public int _runSpeed;
    public int dashpower;
    public int dashStaminaUsing;

    public Sprite[] images;
    private bool movement = false;
    private int zone = 0;
    private float _angle = 0f;

    private float _hM;
    private float _vM;

    float doubleTapTime;
    KeyCode lastKeyCode;

    public MultiplayerStamina player;

    void Update()
    {
        if (photonView.isMine)
        {
        _hM = Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;
        _vM = Input.GetAxisRaw("Vertical") * _speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift))//courrir ou pas courrir
        {
            _hM = Input.GetAxisRaw("Horizontal") * _speed * _runSpeed * Time.deltaTime;
            _vM = Input.GetAxisRaw("Vertical") * _speed * _runSpeed * Time.deltaTime;
        }

        _Vmovement(_vM);
        _Hmovement(_hM);

        photonView.RPC("_Animation",PhotonTargets.AllBuffered);

        }

    }

    void _Hmovement(float _horizontalmovement)
    {
        transform.position += (Vector3)new Vector2(_horizontalmovement * _speed * Time.deltaTime, 0);
    }

    void _Vmovement(float _verticalmovement)
    {
        transform.position += (Vector3)new Vector2(0, _verticalmovement * _speed * Time.deltaTime);
    }

    [PunRPC]
    void _Animation()
    {
        _angle = game.mouseAngle;

        if (_angle >= 135)
            zone = 2;
        else if (_angle >= 90)
            zone = 3;
        else if (_angle >= 45)
            zone = 4;
        else if (_angle >= 0)
            zone = 5;
        else if (_angle >= -45)
            zone = 6;
        else if (_angle >= -90)
            zone = 7;
        else if (_angle >= -135)
            zone = 0;
        else
            zone = 1;

        movement = _hM != 0 || _vM != 0;
        sR.sprite = images[zone + System.Convert.ToInt32(movement) * 16 + System.Convert.ToInt32(game.turboBool) * 8];
    }
}
