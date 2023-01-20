using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//enemy 인터페이스
public interface Enemy
{
    public void Move();
    public void Attack();
    public void Die();
    public void SetTarget(Transform target_);

}
