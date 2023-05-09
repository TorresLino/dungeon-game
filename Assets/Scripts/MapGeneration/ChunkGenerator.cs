using System;
using System.Collections.Generic;
using UnityEngine;

public class ChunkGenerator : MonoBehaviour
{
	[SerializeField]
	private MapManager mapManager;
	public delegate void LayerGenerationFunction(Chunk chunk);

	public void GenerateChunks(List<Chunk> chunks, Vector2Int playerChunkLocation)
	{
		this.GenerateLayer(ChunkGenerationStatus.RandomLocation, GenerateLayer1);

		this.GenerateLayer(ChunkGenerationStatus.LocationAndRadius, GenerateLayer2);

		this.GenerateLayer(ChunkGenerationStatus.Connections, GenerateLayer3);
	}

	public void GenerateLayer(ChunkGenerationStatus status, LayerGenerationFunction function)
	{
		List<Chunk> chunks = this.Chunks.FindAll(c =>
			c.Status == status &&
			this.GetDistanceFromPlayerChunk(c) >= this.mapManager.LoadDistance - (int)status
		);

		foreach (Chunk chunk in chunks)
		{
			function(chunk);
		}
	}

	private int GetDistanceFromPlayerChunk(Chunk chunk)
	{
		return Math.Max(
			Math.Abs(chunk.Location.x - this.mapManager.PlayerChunkCoorinate.x),
			Math.Abs(chunk.Location.y - this.mapManager.PlayerChunkCoorinate.y)
		);
	}

	private void GenerateLayer1(Chunk chunk)
	{

	}

	private void GenerateLayer2(Chunk chunk)
	{

	}

	private void GenerateLayer3(Chunk chunk)
	{

	}

	private List<Chunk> GetNeighboringChunks(Chunk chunk)
	{
		List<Chunk> chunks = new List<Chunk>();

		for(int x=-1; x<=1; x++)
		{
			for(int y=-1; y<=1; y++)
			{
				if (x == 0 && y == 0)
					continue;

				chunks.Add(this.Chunks.Find(c => c.Location == (chunk.Location + new Vector2Int(x, y)) ));
			}
		}

		return chunks;
	}

	private List<Chunk> Chunks { get { return this.mapManager.Chunks; } }
}

public enum ChunkGenerationStatus
{
	RandomLocation = 0,
	LocationAndRadius = 1,
	Connections = 2,
	Done = 3
}