using System.Collections;
using System.Collections.Generic;
using General.Data.Motion.Legacy;
using General.Data.Motion.BranchOut;
using General.Data.Motion.SecondGen;
using General.Operation;
using UnityEngine;

/* This namespace is use for:
 * Storing function
 */
namespace General.Operation.Motion
{
    // This class is use for storing movement function and give easier interface

    /* Dependencies:
     * Motion.Legacy
     * Motion.BranchOut
     * Motion.SecondGen
     */
    public class Movement
    {
        #region Variable
        // private
        private Rigidbody2D _rigidbody;
        #endregion

        #region Method
        // constructor
        public Movement(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        // Accelerate
        public void Accelerate(Vector2 direction, MotionNormal motionData)
        {
            Vector2 acceleration = CalculateAcceleration(_rigidbody.velocity, direction, motionData.maxVelocity, motionData.maxAcceleration);
            _rigidbody.AddForce(acceleration * _rigidbody.mass, ForceMode2D.Impulse); // Force per frame (make force exert precise) **NOTE: try to multiply acceleration with mass and set ForceMode2D to normal
        }

        // RelativeBrake (reduce velocity to certain percent [0-1])
        public void RelativeBrake(MotionNormalPrec motionData)
        {
            // Calculate Force to reduce to certain velocity
            Vector2 targetVelocity = _rigidbody.velocity * motionData.endMultiply;
            Vector2 deceleration = targetVelocity - _rigidbody.velocity;
            _rigidbody.AddForce(deceleration * _rigidbody.mass, ForceMode2D.Impulse);
        }

        // Decelerate
        public void Decelerate(float maxDeceleration, bool affectX = true, bool affectY = true)
        {
            Vector2 deceleration = CalculateDeceleration(_rigidbody.velocity, maxDeceleration, affectX ? 1 : 0, affectY ? 1 : 0);
            _rigidbody.AddForce(deceleration * _rigidbody.mass, ForceMode2D.Impulse); // Force per frame (make force exert precise)
        }

        #region Impact

        public void Impact(Vector2 direction, MotionImpact motionData)
        {
            _rigidbody.AddForce(direction * motionData.thrust, ForceMode2D.Impulse);
        }

        public void ImpactGrad(Vector2 direction, MotionImpactGrad motionData, bool flipGradient = false )
        {
            float radiens = -Mathf.PI * motionData.gradient / 2 * (flipGradient?-1:1);
            Vector2 calculatedDir = GTM.CalculateRotatedDirection(direction, radiens);
            _rigidbody.AddForce(calculatedDir * motionData.thrust, ForceMode2D.Impulse);
        }

        #endregion

        #region General

        private Vector2 CalculateAcceleration(Vector2 currentVelocity, Vector2 direction, float maxVelocity, float maxAcceleration)
        {
            Vector2 acceleration = new Vector2();
            float safeMaxAcceleration = Mathf.Clamp(maxAcceleration, 0, maxVelocity); // max acceleration should not exceed max velocity
            acceleration.x = (-Mathf.Abs((safeMaxAcceleration / maxVelocity) * currentVelocity.x) + safeMaxAcceleration) * direction.x;
            acceleration.y = (-Mathf.Abs((safeMaxAcceleration / maxVelocity) * currentVelocity.y) + safeMaxAcceleration) * direction.y;
            return acceleration;
        }

        private Vector2 CalculateDeceleration(Vector2 currentVelocity, float maxDeceleration, float xMultiply, float yMultiply)
        {
            Vector2 deceleration = new Vector2();
            deceleration.x = Mathf.Clamp(-currentVelocity.x * xMultiply, -maxDeceleration, maxDeceleration);
            deceleration.y = Mathf.Clamp(-currentVelocity.y * yMultiply, -maxDeceleration, maxDeceleration);
            return deceleration;
        }

        #endregion

        #endregion
    }
}