using UnityEngine;

public class ArrastrarSprite : MonoBehaviour
{
    private Vector3 offset;
    private Rigidbody2D rb;
    private Animator anim; // Variable para el motor de animaciones

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Vinculamos el componente
    }

    void OnMouseDown()
    {
        // Al interactuar/seleccionar el objeto, disparamos el estado de animación
        if (anim != null)
        {
            anim.SetTrigger("Activar");
        }

        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
    }

    void OnMouseDrag()
    {
        Vector3 nuevaPosicion = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)) + offset;
        rb.MovePosition(new Vector2(nuevaPosicion.x, nuevaPosicion.y));
    }
}