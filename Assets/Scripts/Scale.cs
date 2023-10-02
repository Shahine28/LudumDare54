using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Scale : MonoBehaviour
{
    [SerializeField] float _sizeScale;
    Transform _playerTransform;

    Vector3 scaleAmount = new Vector3(0.53f, 0.53f, 0.53f); // L'échelle souhaitée

    private void Start()
    {
        _playerTransform = GetComponent<Transform>();
        transform.localScale = scaleAmount;
    }

    public void scale(float sizeFactor)
     {
        // Obtenez la valeur actuelle de localScale
        Vector3 currentScale = transform.localScale;

        // Ajoutez le facteur à chaque composant de localScale
        currentScale.x += sizeFactor;
        currentScale.y += sizeFactor;
        currentScale.z += sizeFactor;

        // Réassignez la nouvelle valeur de localScale
        transform.localScale = currentScale;
    }

    [Button] void ScaleUp() => scale(_sizeScale);
    [Button] void ResetScale() => Start();
}
