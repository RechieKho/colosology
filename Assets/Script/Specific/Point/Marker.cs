using General.Other;
using UnityEngine;
using System;

namespace Specific.Location
{
    public class Marker : MonoBehaviour
    {
        public SemiDictTransform[] marks;

        public Vector2 GetMark(string __key)
        {
            return Array.Find(marks, (mark) =>
            {
                return mark.key == __key;
            }).value.position;
        }

        public static Marker GetMarker()
        {
            return GameObject.FindGameObjectWithTag("SceneScript").GetComponent<Marker>();
        }
    }

}
