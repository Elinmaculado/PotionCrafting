using UnityEngine;

public class PotionDescription : MonoBehaviour
{
    public GameObject insidePotion;

    public Color TakeColor()
    {
        return insidePotion.GetComponent<MeshRenderer>().material.color;
    }
}
