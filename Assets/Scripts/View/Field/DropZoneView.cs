using UnityEngine;
using UnityEngine.UI;

public class DropZoneView : MonoBehaviour
{
    public Vector2 point;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PieceView>() != null)
        {
            Recolor(Color.red);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PieceView>() != null)
        {
            Recolor(Color.red);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PieceView>() != null)
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

    public void Liberate()
    {
        if(transform.GetChild(0).gameObject != null)
            Destroy(transform.GetChild(0).gameObject);
    }
    //Ќазвание метода шутка и отсылка к helldivers 2.
    //ѕравильное название должно быть что-то типо "Release"
}
