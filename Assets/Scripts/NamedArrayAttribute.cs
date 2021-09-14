using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NamedArrayAttribute : PropertyAttribute
{
    public readonly string[] names;
    public NamedArrayAttribute(string[] names) { this.names = names; }
}


