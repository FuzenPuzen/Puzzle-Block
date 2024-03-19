using UnityEngine;
using UnityEngine.UI;

public class DropZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Piece>() != null)
        {
            Recolor(Color.red);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Piece>() != null)
        {
            Recolor(Color.red);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Piece>() != null)
        {
            Recolor(Color.white);
        }
    }

    public void Recolor(Color color)
    {
        transform.GetComponent<Image>().color = color;
    }

    public bool IsFree()
    {
        if (transform.childCount > 0) return false;
        return true;
    }
}
