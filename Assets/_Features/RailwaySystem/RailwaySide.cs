using System.ComponentModel;

public enum RailwaySide : byte {
	Front, Rear
}

[EditorBrowsable(EditorBrowsableState.Never)]
public static class RailwaySideExtensions {

	public static RailwaySide Opposite(this RailwaySide side) => side switch {
		RailwaySide.Front => RailwaySide.Rear,
		RailwaySide.Rear => RailwaySide.Front,
		_ => side
	};

}