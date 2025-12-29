using UnityEngine;

public class coin : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;

    private void OnTriggerEnt2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarPuntos(valor);
            Destroy(this.gameObject);
        }
    }
}
