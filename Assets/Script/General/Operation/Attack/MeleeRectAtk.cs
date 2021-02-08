﻿using System.Collections;
using System.Collections.Generic;
using General.Data.AttackData.Melee;
using General.Operation.GizmoDebug;
using General.Operation;
using UnityEngine;

namespace General.Operation.AttackSystem.Melee
{
    public class MeleeRectAtk
    {

        #region Variable
        private MeleeRectData _data;
        private Transform _transform;
        private Timer.Timer _timer;
        private bool _inCoolDown;
        private GameObject _attacker;

        #region Debug
        private GizBoxData _debugBox;
        #endregion

        #endregion

        public MeleeRectAtk(MeleeRectData __data, GameObject __attacker)
        {
            _data = __data;
            _attacker = __attacker;
            _transform = __attacker.transform;
            _inCoolDown = false;
            _timer = new Timer.Timer(Timer.Timer.Timing.scaledTime, _data.coolDown, false, isAutoStart: false, ExitCoolDown);
        }

        #region Cooldown Control
        private void StartCoolDown()
        {
            EnterCoolDown();
            _timer.StartTimer();
        }

        private void EnterCoolDown()
        {
            _inCoolDown = true;
        }

        private void ExitCoolDown()
        {
            _inCoolDown = false;
        }
        #endregion

        public void Attack(Vector2 __direction)
        {
            if (_inCoolDown) return;

            #region Hitbox Position
            Vector2 hitBoxPosition = __direction.normalized * _data.stretch;
            hitBoxPosition.x += _transform.position.x + _data.offset.x;
            hitBoxPosition.y += _transform.position.y + _data.offset.y;
            #endregion

            #region Get Valid Target
            List<GameObject> validTargets = new List<GameObject>();
            if (!_data.atkMultiple) // attack single
            {
                List<GameObject> filteredTargets = new List<GameObject>();

                // get all the targets in hitbox
                List<GameObject> targets = new List<GameObject>();
                foreach (var targetCollider in Physics2D.OverlapBoxAll(hitBoxPosition, _data.size, 0f, _data.targetLayer))
                {
                    targets.Add(targetCollider.gameObject);
                }

                // filter out targets which is blocked
                foreach (var target in targets)
                {
                    Vector2 direction = new Vector2();
                    direction.x = (target.transform.position.x - hitBoxPosition.x);
                    direction.y = (target.transform.position.y - hitBoxPosition.y);
                    RaycastHit2D hit2D = Physics2D.Raycast(_data.damageFromCentreOfHitBox ? hitBoxPosition : (Vector2)_attacker.transform.position, direction.normalized, Vector2.Distance(hitBoxPosition, target.transform.position), _data.blockingLayer);
                    if (!hit2D)
                    {
                        filteredTargets.Add(target);
                    }
                }
                
                validTargets.Add(GTM.GetClosestGameObject(filteredTargets, _data.damageFromCentreOfHitBox ? hitBoxPosition : (Vector2)_attacker.transform.position));
            }
            else // attack multiple
            {

                // get all the data
                List<GameObject> targets = new List<GameObject>();
                foreach(var targetCollider in Physics2D.OverlapBoxAll(hitBoxPosition, _data.size, 0f, _data.targetLayer))
                {
                    targets.Add(targetCollider.gameObject);
                }


                // get target that is not blocked
                foreach (var target in targets)
                {
                    Vector2 direction = new Vector2();
                    direction.x = (target.transform.position.x - hitBoxPosition.x);
                    direction.y = (target.transform.position.y - hitBoxPosition.y);
                    RaycastHit2D hit2D = Physics2D.Raycast(_data.damageFromCentreOfHitBox ? hitBoxPosition : (Vector2) _attacker.transform.position, direction.normalized, Vector2.Distance(hitBoxPosition, target.transform.position), _data.blockingLayer);
                    if (!hit2D)
                    {
                        validTargets.Add(target);
                    }
                }


            }
            #endregion

            #region Apply Attack
            // apply attack
            foreach (var target in validTargets)
            {
                try
                {
                    #region Apply Damage
                    if (target.GetComponent<HealthSystem.NormalHealthSystem>())
                    {
                        HealthSystem.NormalHealthSystem targetHealth = target.GetComponent<HealthSystem.NormalHealthSystem>();
                        if (_data.reduceHealthOnly)
                        {
                            targetHealth.health.ReduceHealth(_data.damage);
                        }
                        else
                        {
                            Data.AttackData.DamageData damageData = new Data.AttackData.DamageData(_data.damage, _attacker, new Vector2(target.transform.position.x - hitBoxPosition.x, target.transform.position.y - hitBoxPosition.y));
                            targetHealth.health.Damage(damageData);
                        }
                    }
                    else
                    {
                        HealthSystem.StaticHealthSystem targetHealth = target.GetComponent<HealthSystem.StaticHealthSystem>();
                        if (_data.reduceHealthOnly)
                        {
                            targetHealth.health.ReduceHealth(_data.damage);
                        }
                        else
                        {
                            Data.AttackData.DamageData damageData = new Data.AttackData.DamageData(_data.damage, _attacker, new Vector2(target.transform.position.x - hitBoxPosition.x, target.transform.position.y - hitBoxPosition.y));
                            targetHealth.health.Damage(damageData);
                        }
                    }
                    #endregion
                }
                catch (System.Exception)
                {
                    Debug.LogError(string.Format("Enemy '{0}' is do not attach Health System script", target.name));
                }

                #region Debug
                // WARNING: POORLY DESIGNED CODE
                Debug.DrawLine(_data.damageFromCentreOfHitBox ? hitBoxPosition : (Vector2)_attacker.transform.position, target.transform.position, Color.red, 3f);
                #endregion

            }
        #endregion

            // start cooldown
            StartCoolDown();

            #region Debug
            // WARNING: POORLY DESIGN CODE (but it is for debugging so don't worry)
            if (_debugBox == null) _debugBox = new GizBoxData(hitBoxPosition, _data.size, Color.red);
            else
            {
                _debugBox.ChangePosition(hitBoxPosition);
                _debugBox.ChangeSize(_data.size);
            }
            #endregion
        }
    }
}


/**
 * Problem Statement:
 * 1. Attack can pass through wall when single attacking // done
 * 2. Origin of attack is inaccurate in multiple attacking // done
 * 3. Fix the same thing in MeleeCircAtk.cs 
 */