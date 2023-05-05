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

	public Chunk(int x, int y, int roomsPerChunk, int chunkWidth, uint seed)
	{
		this.location = new Vector2Int(x, y);
		this.connections = new List<Connection>();
		this.rooms = new List<Room>();
		for (int i=0; i<roomsPerChunk*2; i+=2)
		{
			this.rooms.Add(new Room(
				(int) NoiseRNG.Noise3d((uint)x, (uint)y, (uint)i, seed) % chunkWidth,
				(int) NoiseRNG.Noise3d((uint)x, (uint)y, (uint)i+1, seed) % chunkWidth
			));
		}

		this.status = ChunkGenerationStatus.RandomLocation;
	}
}