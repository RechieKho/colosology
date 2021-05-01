using General.Other;
using UnityEngine;

/* This namespace is use for:
 * Storing function
 */
namespace General.Movement
{
    // This class is use for storing movement function and give easier interface

    /* Dependencies:
     * Motion.Legacy
     * Motion.BranchOut
     * Motion.SecondGen
     */
    public class MController
    {
        #region Variable
        // private
        private Rigidbody2D _rigidbody;
        private Vector2 _lastVelocity; // for freezing function
        private RigidbodyConstraints2D _lastConstraint;
        #endregion

        public bool IsFalling { get { return _rigidbody.velocity.y < 0; } }

        #region Method
        // constructor
        public MController(Rigidbody2D rigidbody, bool isFreezable = false)
        {
            _rigidbody = rigidbody;
            _lastConstraint = _rigidbody.constraints;
            if (isFreezable) Freezer.trigger += Freeze;
        }

        // Accelerate
        public void Accelerate(Vector2 direction, Force_SO motionData)
        {
            Vector2 acceleration = CalculateAcceleration(_rigidbody.velocity, direction, motionData.maxVelocity, motionData.maxAcceleration);
            _rigidbody.AddForce(acceleration * _rigidbody.mass, ForceMode2D.Impulse); // Force per frame (make force exert precise) **NOTE: try to multiply acceleration with mass and set ForceMode2D to normal
        }

        public void ImmediateAccelerate(Vector2 direction, ForcePrec_SO motionData, float limiter, bool brakeAffectX = true, bool brakeAffectY = true)
        {
            if (Vector2.Dot(_rigidbody.velocity, direction) < limiter) RelativeBrake(motionData.endMultiply, brakeAffectX, brakeAffectY);
            Accelerate(direction, motionData);
        }

        // RelativeBrake (reduce velocity to certain percent [0-1])
        public void RelativeBrake(float endMultiply, bool affectX = true, bool affectY = true)
        {
            // Calculate Force to reduce to certain velocity
            Vector2 targetVelocity = _rigidbody.velocity * endMultiply;
            Vector2 deceleration = targetVelocity - _rigidbody.velocity;
            _rigidbody.AddForce(new Vector2(
                affectX? deceleration.x : 0,
                affectY? deceleration.y : 0
                ) * _rigidbody.mass, ForceMode2D.Impulse);
        }

        // Decelerate
        public void Decelerate(float maxDeceleration, bool affectX = true, bool affectY = true)
        {
            Vector2 deceleration = CalculateDeceleration(_rigidbody.velocity, maxDeceleration, affectX ? 1 : 0, affectY ? 1 : 0);
            _rigidbody.AddForce(deceleration * _rigidbody.mass, ForceMode2D.Impulse); // Force per frame (make force exert precise)
        }

        // turn of gravity
        public void SetGravity(float __scale)
        {
            _rigidbody.gravityScale = __scale;
        }

        #region Impact

        public void Impact(Vector2 direction, Impact_SO motionData)
        {
            _rigidbody.AddForce(direction * motionData.thrust, ForceMode2D.Impulse);
        }

        public void ImpactBON(Vector2 direction, ImpactBON_SO motionData, bool flipGradient = false )
        {
            float radiens = -Mathf.PI * motionData.gradient / 2 * (flipGradient?-1:1);
            Vector2 calculatedDir = GTM.CalculateRotatedDirection(direction, radiens);
            _rigidbody.AddForce(calculatedDir * motionData.thrust, ForceMode2D.Impulse);
        }

        public void ImmediateImpact(Vector2 direction, ImpactPrec_SO motionData, float limiter, bool brakeAffectX = true, bool brakeAffectY = true)
        {
            if (Vector2.Dot(_rigidbody.velocity, direction) < limiter) RelativeBrake(motionData.endMultiply, brakeAffectX, brakeAffectY);
            Impact(direction, motionData);
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

        #region freezer
        private void Freeze(bool __freeze)
        {
            if(__freeze)
            {
                _lastVelocity = _rigidbody.velocity;
                _rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            }
            else if(!__freeze)
            {
                _rigidbody.constraints = _lastConstraint;
                _rigidbody.velocity = _lastVelocity;
            }
        }
        #endregion

        #endregion
    }
}