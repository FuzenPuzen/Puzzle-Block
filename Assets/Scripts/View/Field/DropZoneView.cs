using UnityEngine;
using UnityEngine.UI;

public class DropZoneView : MonoBehaviour
{
    public Vector2 Point;

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
        Recolor(Color.white);
        if (transform.childCount != 0)
            return !transform.GetChild(0).GetComponent<PieceView>().IsActive();
        return true;
    }

    public void Clear()
    {
        if (transform.childCount > 0)
            transform.GetChild(0).GetComponent<PieceView>().Disable(0);
    }


    public void Liberate(int i)
    {
        if (transform.childCount > 0)
            transform.GetChild(0).GetComponent<PieceView>().Disable(i);
        Recolor(Color.white);
    }
    //Ќазвание метода шутка и отсылка к helldivers 2.
    //ѕравильное название должно быть что-то типо "Release"
}
