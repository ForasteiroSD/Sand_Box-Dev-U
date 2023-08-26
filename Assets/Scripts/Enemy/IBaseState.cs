using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseState {
    public void EnterState(EnemyStateMachine stateMachine);

    public void UpdateState(EnemyStateMachine stateMachine);
}