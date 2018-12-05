using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPJ : MonoBehaviour
{
    public int velocidad;
    private int _velocidad;

    public Vector2 fuerzaSalto;

    private Transform miTransform;
    private Rigidbody2D miRigidbody;

    private Animator miAnimator;
    private bool isGrounded;

    public LayerMask mascaras;
    public Transform topleftpos, bottomrightpos;
    public SpriteRenderer naruto;

    public Transform posDisparo;
    public GameObject miPoolShurikens;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
        miTransform = this.transform;
        miRigidbody = GetComponent<Rigidbody2D>();

        miAnimator = GetComponent<Animator>();
        isGrounded = true;
        miAnimator.SetBool("isGrounded", isGrounded);
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckInput();
        acciones();
        updateAnimaciones();
        _velocidad = 0;

	}

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            miRigidbody.AddForce(fuerzaSalto, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A)) {
            _velocidad = -velocidad;
            naruto.flipX = true;

        } else if (Input.GetKey(KeyCode.D)) {
            _velocidad = velocidad;
            if (naruto.flipX == true) {
                naruto.flipX = false;
            }
        } else if (Input.GetMouseButtonDown(0)) {
            miAnimator.SetTrigger("disparar");
        }
        
    }

    private void updateAnimaciones()
    {
        if(_velocidad < 0 || _velocidad > 0)
        {
            miAnimator.SetInteger("velocidad", 1);
        } else
        {
            miAnimator.SetInteger("velocidad", 0);
        }
        miAnimator.SetBool("isGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        if(miRigidbody.velocity.y < 0 || miRigidbody.velocity.y > 0)
        {
            isGrounded = Physics2D.OverlapArea(topleftpos.position, bottomrightpos.position, mascaras);
        }

    }
    private void acciones()
    {
        miTransform.Translate(Vector3.right * _velocidad * Time.deltaTime);
    }

    public void disparo() {
        
        miPoolShurikens.GetComponent<PoolObject>().CrearShurikens(posDisparo.position);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag.Equals("PlataformaMovil")) {
            if (gameObject.GetComponent<SpriteRenderer>().bounds.min.y > collision.transform.position.y) {
                miTransform.parent = collision.transform;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "PlataformaMovil") {
            miTransform.parent = null;
        }
    }
}
