using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
	protected Vector2Int location;
	protected List<Connection> connections;
	protected List<Room> rooms;
	protected ChunkGenerationStatus status;

	public ChunkGenerationStatus Status { get => status; }
	public Vector2Int Location { get => location; }
}

public enum ChunkGenerationStatus
{
	None = 0,
	RoughLocation = 1,
	RoomSize = 2,
	ConnectionsDone = 3,
	Done = 4
}
