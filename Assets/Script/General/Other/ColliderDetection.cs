using UnityEngine;

namespace General.Other
{
    public class ColliderDetection2D
    {
        private Transform _detectionPoint;
        private float _radius;
        private int _layerMask;

        public bool IsDetected
        {
            get
            {
                return Physics2D.OverlapCircle(_detectionPoint.position, _radius, _layerMask);
            }
        }

        public ColliderDetection2D (Transform __detectionPoint, float __radius, int __layerMask)
        {
            _detectionPoint = __detectionPoint;
            _radius = __radius;
            _layerMask = __layerMask;
        }

    }

    public class ColliderDetection
    {
        private Transform _detectionPoint;
        private float _radius;
        private int _layerMask;

        public bool IsDetected
        {
            get
            {
                return Physics.OverlapSphere(_detectionPoint.position, _radius, _layerMask).Length != 0;
            }
        }

        public ColliderDetection(Transform __detectionPoint, float __radius, int __layerMask)
        {
            _detectionPoint = __detectionPoint;
            _radius = __radius;
            _layerMask = __layerMask;
        }

    }
}
