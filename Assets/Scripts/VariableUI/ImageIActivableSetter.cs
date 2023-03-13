using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ImageIActivableSetter : MonoBehaviour
{
    [SerializeField] ScriptableObject instance;
    [SerializeField] Image image;
    [SerializeField] Color inactiveColor;
    [SerializeField] Color activeColor;
    
    private void Update()
    {
        if (ReferenceEquals(image, null) || ReferenceEquals(image, instance))
            return;

        var activable = instance as IActivable;
        if (ReferenceEquals(activable, null))
            return;

        //https://learn.microsoft.com/pl-pl/dotnet/csharp/language-reference/operators/conditional-operator
        image.color = activable.IsActive ? activeColor : inactiveColor;
    }
}
