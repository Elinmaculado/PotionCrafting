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
            PotionDescription pdd;
            other.gameObject.TryGetComponent(out pdd);
            if (pdd)
            {
                AddPotion(pdd.gameObject.GetComponent<PotionDescription>().TakeColor());
                Destroy(other.gameObject);
            }
        }
    }

    public void AddPotion(Color NewColor)
    {
        Renderer renderer = liquid.GetComponent<MeshRenderer>();
        var main = particleSystem.main;
        main.startColor = NewColor;
        particleSystem.Play();
        renderer.material.color = NewColor;
        Color temp = renderer.material.color;
        if (globalVolume)
        {
            colorAdjustments.colorFilter.value = NewColor;
        }
    }
}
