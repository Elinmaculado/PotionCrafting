using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PotionCollisionDetection : MonoBehaviour
{
    public GameObject liquid;
    public ParticleSystem particleSystem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Potion"))
        {
            Renderer potionRenderer = other.GetComponent<Renderer>();
            AddPotion(potionRenderer);
            Destroy(other.gameObject);
            
        }
    }

    public void AddPotion(Renderer potionRenderer)
    {
        MeshRenderer renderer = liquid.GetComponent<MeshRenderer>();
        var main = particleSystem.main;
        main.startColor = potionRenderer.material.color;
        particleSystem.Play();
        renderer.material.color = potionRenderer.material.color;
    }
}
