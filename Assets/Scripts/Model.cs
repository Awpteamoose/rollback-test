public class Model {
	public struct PlayerInput {
		public bool left;
		public bool right;
	}

	public struct IntVec2 {
		public int x;
		public int y;
	}

	public struct WorldState {
		public IntVec2 player1Pos;
		public IntVec2 player2Pos;
	}

	public static void Tick(PlayerInput input, WorldState worldState) {
		if (input.right)
			worldState.player1Pos.x += 1;
		if (input.left)
			worldState.player1Pos.x -= 1;
	}
}
