using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour {
	public Transform player1;
	public float tickInterval;

	private float sinceLastTick = 0;
	private Model.WorldState worldState;

	void Start() {
		worldState = new Model.WorldState {
			player1Pos = new Model.IntVec2 {x = 0, y = 0},
			player2Pos = new Model.IntVec2 {x = 0, y = 0}
		};
	}

	// TODO: record world states over time so I can rollback or replay
	void Update() {
		var input = new Model.PlayerInput {
			right = Input.GetKey(KeyCode.D),
			left = Input.GetKey(KeyCode.A)
		};
		sinceLastTick += Time.deltaTime;
		while (sinceLastTick >= tickInterval) {
			Model.Tick(input, worldState);
			sinceLastTick -= tickInterval;
		}
		player1.position = new Vector3(worldState.player1Pos.x, worldState.player1Pos.y);
	}
}
