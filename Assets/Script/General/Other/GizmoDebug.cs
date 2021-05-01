using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This namespace is use for:
 * store all classes about gizmo Debug
 */
namespace General.Other 
{

    #region Gizmo Data
    public class GizSphereData
    {
        #region Properties
        public Vector3 Position { get { return position; } }
        public float Radius { get { return radius; } }
        public Color Color { get { return color; } }
        public bool IsAdded { get { return isAdded; } }
        #endregion

        #region Variable
        private Vector3 position;
        private float radius;
        private Color color;
        private bool isAdded;
        #endregion

        #region Method
        // constructor
        public GizSphereData(Vector3 dPosition, float dRadius, Color dColor, bool autoAdd = true)
        {
            position = dPosition;
            radius = dRadius;
            color = dColor;

            // append to GizmoDebug
            if(autoAdd)Add();
        }

        public void ChangePosition(Vector3 newPosition)
        {
            position = newPosition;
        }

        public void ChangeRadius(float newRadius)
        {
            radius = newRadius;
        }

        public void ChangeColor(Color newColor)
        {
            color = newColor;
        }

        public void Remove()
        {
            if (!isAdded) return;
            GizmoDebug.RemoveGizmo(this);
            isAdded = false;
        }

        public void Add()
        {
            if (isAdded) return;
            GizmoDebug.StartGizmo(this);
            isAdded = true;
        }

        #endregion
    }

    public class GizBoxData
    {
        #region Properties
        public Vector3 Position { get { return position; } }
        public Vector3 Size { get { return size; } }
        public Color Color { get { return color; } }
        public bool IsAdded { get { return isAdded; } }
        #endregion

        #region Variables
        private Vector3 position;
        private Vector3 size;
        private Color color;
        private bool isAdded;
        #endregion

        #region Method

        // constructor
        public GizBoxData(Vector3 dPosition, Vector3 dSize, Color dColor, bool autoAdd = true)
        {
            position = dPosition;
            size = dSize;
            color = dColor;

            // append to GizmoDebug
            if (autoAdd) Add();
        }

        public void ChangePosition(Vector3 newPosition)
        {
            position = newPosition;
        }

        public void ChangeSize(Vector2 newSize)
        {
            size = newSize;
        }

        public void ChangeColor(Color newColor)
        {
            color = newColor;
        }

        public void Remove()
        {
            if (!isAdded) return;
            GizmoDebug.RemoveGizmo(this);
            isAdded = false;
        }

        public void Add()
        {
            if (isAdded) return;
            GizmoDebug.StartGizmo(this);
            isAdded = true;
        }

        #endregion
    }

    public class GizLineData
    {
        #region Properties
        public DrawLine Line { get { return line; } }
        public Vector3 Origin { get { return origin; } }
        public Vector3 Target { get { return target; } }
        public Color Color { get { return color; } }
        public bool IsAdded { get { return isAdded; } }
        #endregion

        #region enum
        public enum DrawLine
        {
            ray,
            line
        }
        #endregion

        #region Variables
        private DrawLine line;
        private Vector3 origin;
        private Vector3 target;
        private Color color;
        private bool isAdded;
        #endregion

        #region Method

        // constructor
        public GizLineData(DrawLine dline, Vector3 dOrigin, Vector3 dTarget, Color dColor, bool autoAdd = true)
        {
            // Setup
            line = dline;
            origin = dOrigin;
            target = dTarget;
            color = dColor;

            // append to GizmoDebug
            if (autoAdd) Add();
        }

        public void ChangeOrigin(Vector3 newOrigin)
        {
            origin = newOrigin;
        }

        public void ChangeTarget(Vector3 newTarget)
        {
            target = newTarget;
        }

        public void ChangeColor(Color newColor)
        {
            color = newColor;
        }

        public void Remove()
        {
            if (!isAdded) return;
            GizmoDebug.RemoveGizmo(this);
            isAdded = false;
        }

        public void Add()
        {
            if (isAdded) return;
            GizmoDebug.StartGizmo(this);
            isAdded = true;
        }

        #endregion
    }
    #endregion

    // This class is use for singleton for GizmoDebug
    public class GizmoDebug : MonoBehaviour
    {
        #region Variable
        private List<GizLineData> _lines = new List<GizLineData>();
        private List<GizBoxData> _boxes = new List<GizBoxData>();
        private List<GizSphereData> _sphere = new List<GizSphereData>();
        public static GizmoDebug singleton;
        #endregion

        #region Method

        // this method is use to append data to List and initiate singleton if there is not such thing
        public static void StartGizmo<T>(T gizmoData)
        {
            #region init singleton
            if (singleton == null)
            {
                singleton = new GameObject("GizmoDebug").AddComponent<GizmoDebug>();
            }
            #endregion

            #region Append Data to List
            if (gizmoData.GetType() == typeof(GizLineData)) // if gizmoData is a line
            {
                singleton._lines.Add(gizmoData as GizLineData);
            }
            else if (gizmoData.GetType() == typeof(GizBoxData)) // if gizmoData is a Box
            {
                singleton._boxes.Add(gizmoData as GizBoxData);
            }
            else if (gizmoData.GetType() == typeof(GizSphereData)) // if gizmoData is a Sphere
            {
                singleton._sphere.Add(gizmoData as GizSphereData);
            }
            #endregion
        }

        // this method is use to remove data from list
        public static void RemoveGizmo<T>(T gizmoData)
        {
            if (singleton == null) return;

            #region Remove data from list
            if (gizmoData.GetType() == typeof(GizLineData)) // if gizmoData is a line
            {
                singleton._lines.Remove(gizmoData as GizLineData);
            }
            else if (gizmoData.GetType() == typeof(GizBoxData)) // if gizmoData is a Box
            {
                singleton._boxes.Remove(gizmoData as GizBoxData);

            }
            else if (gizmoData.GetType() == typeof(GizSphereData)) // if gizmoData is a Sphere
            {
                singleton._sphere.Remove(gizmoData as GizSphereData);

            }
            #endregion
        }

        private void OnDrawGizmos()
        {
            // draw shape
            foreach (var sphere in _sphere)
            {
                Gizmos.color = sphere.Color;
                Gizmos.DrawWireSphere(sphere.Position, sphere.Radius);
            }

            foreach (var box in _boxes)
            {
                Gizmos.color = box.Color;
                Gizmos.DrawWireCube(box.Position, box.Size);
            }

            // draw line
            foreach (var line in _lines)
            {
                Gizmos.color = line.Color;
                if (line.Line == GizLineData.DrawLine.line) { Gizmos.DrawLine(line.Origin, line.Target); }
                else if (line.Line == GizLineData.DrawLine.ray) { Gizmos.DrawRay(line.Origin, line.Target); }
            }
        }

        private void OnApplicationQuit()
        {
            _sphere.Clear();
            _boxes.Clear();
            _lines.Clear();
        }

        #endregion
    }
}