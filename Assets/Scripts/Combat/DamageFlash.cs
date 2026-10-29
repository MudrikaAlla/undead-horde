using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float flashDuration = 0.15f;

    private Health health;
    private Renderer[] renderers;
    private List<MaterialColorCache> colorCache = new List<MaterialColorCache>();

    private struct MaterialColorCache
    {
        public Material mat;
        public string propertyName;
        public Color originalColor;
    }

    void Start()
    {
        health = GetComponent<Health>();
        renderers = GetComponentsInChildren<Renderer>();

        // Cache all material colors — check both _Color and _BaseColor
        foreach (var rend in renderers)
        {
            foreach (var mat in rend.materials)
            {
                if (mat.HasProperty("_Color"))
                {
                    colorCache.Add(new MaterialColorCache
                    {
                        mat = mat,
                        propertyName = "_Color",
                        originalColor = mat.GetColor("_Color")
                    });
                }
                else if (mat.HasProperty("_BaseColor"))
                {
                    colorCache.Add(new MaterialColorCache
                    {
                        mat = mat,
                        propertyName = "_BaseColor",
                        originalColor = mat.GetColor("_BaseColor")
                    });
                }
            }
        }

        health.OnHealthChanged += OnDamaged;
    }

    void OnDestroy()
    {
        if (health != null) health.OnHealthChanged -= OnDamaged;
    }

    void OnDamaged(float current, float max)
    {
        if (!health.IsDead)
        {
            StartCoroutine(FlashRoutine());
        }
    }

    IEnumerator FlashRoutine()
    {
        // Flash to color
        foreach (var entry in colorCache)
            entry.mat.SetColor(entry.propertyName, flashColor);

        yield return new WaitForSeconds(flashDuration);

        // Restore originals
        foreach (var entry in colorCache)
            entry.mat.SetColor(entry.propertyName, entry.originalColor);
    }
}
