using UnityEngine;

public class Room
{
	private Vector2Int location;
	private int radius;
	private RoomType type;

	public Room(int x, int y)
	{
		this.location = new Vector2Int(x, y);
		this.radius = 0;
		this.type = RoomType.None;
	}
}

public enum RoomType
{
	None
}
