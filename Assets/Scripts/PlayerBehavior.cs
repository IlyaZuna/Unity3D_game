using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public GameObject bullet;
    public GameObject sphere;
    public float bulletSpeed = 50f;
    public float sphereSpeed = 10f;

    private float vInput;
    private float hInput;
    private float sInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private GameBehavior _gameManager;
    private MeshRenderer _rend;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        _rend = GetComponent<MeshRenderer>();

    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        sInput = Input.GetAxis("Jump") * jumpVelocity;
        
        /* 
        this.transform.Translate(Vector3.forward * vInput *
        Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput *
        Time.deltaTime);
        */
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject newSphere = Instantiate(sphere, transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
            Rigidbody sphereRB = newSphere.GetComponent<Rigidbody>();
            sphereRB.velocity = this.transform.forward * sphereSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.P_HP -= 1;
            if (_gameManager.P_HP <= 7) 
            { 
               _rend.material.SetColor("_Color", Color.yellow);

                if (_gameManager.P_HP <= 5) 
                {
                    _rend.material.SetColor("_Color", Color.red);
                }
            } 

        }
    }


    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            //_rend.material.SetColor("_Color", Color.green);

            //_mat.renderer.material.color = Color.blue;
        }
    }
}
