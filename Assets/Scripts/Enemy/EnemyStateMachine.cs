using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour {
    public IBaseState CurrentStage {get; private set;}

    // Start is called before the first frame update
    private void Start() {
        SwitchState(new MovingLeftState());
    }

    // Update is called once per frame
    private void Update() {
        CurrentStage.UpdateState(this);
    }

    public void SwitchState(IBaseState baseState) {
        CurrentStage = baseState;
        CurrentStage.EnterState(this);
    }
}