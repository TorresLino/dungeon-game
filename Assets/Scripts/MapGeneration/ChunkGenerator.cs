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
		//this.GenerateLayer(ChunkGenerationStatus.RandomLocation, this.test);
	}

	public void GenerateLayer(ChunkGenerationStatus status, LayerGenerationFunction function)
	{
		List<Chunk> chunks = mapManager.Chunks.FindAll(c => 
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

	private void GenerateLayer0(Chunk chunk)
	{
		
	}

	private void GenerateLayer1(Chunk chunk)
	{

	}

	private void GenerateLayer2(Chunk chunk)
	{

	}
}

public enum ChunkGenerationStatus
{
	RandomLocation = 0,
	LocationAndRadius = 1,
	Connections = 2,
	Done = 3
}