using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_movimiento : MonoBehaviour
{
    public float velocidad;
    public LayerMask capaSuelo;
    private Rigidbody2D rb;
    private bool mirarDerecha = true;
    private BoxCollider2D boxCollider;
    public float fuerzaSalto;
    private Animator animator; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movimiento();
        Salto();
    }

    void Movimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        if(inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true );
        }
        else
        {
            animator.SetBool("isRunning", false );
        }
        rb.linearVelocity = new Vector2(inputMovimiento * velocidad, rb.linearVelocity.y);
        GestionarOrientacion(inputMovimiento);
    }
    void GestionarOrientacion(float inputMovimiento)
    {
        if ((mirarDerecha == true && inputMovimiento < 0) || (mirarDerecha == false && inputMovimiento > 0))
        {
            mirarDerecha = !mirarDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    void Salto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstaEnSuelo())
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    bool EstaEnSuelo()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.3f, capaSuelo);
        return raycast.collider != null;
    }
}
