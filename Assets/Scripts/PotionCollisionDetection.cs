using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class PotionCollisionDetection : MonoBehaviour
{
    public GameObject liquid;
    public ParticleSystem particleSystem;
    public Volume globalVolume;
    public ColorAdjustments colorAdjustments;

    private void Start()
    {
        if (globalVolume != null)
        {
            globalVolume.profile.TryGet(out colorAdjustments);
        }
    }

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
        Color temp = renderer.material.color;
        if (globalVolume != null)
        {
            colorAdjustments.colorFilter.value = renderer.material.color;
        }
    }
}
