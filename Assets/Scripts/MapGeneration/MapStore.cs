using System.Collections.Generic;
using UnityEngine;

public class MapStore
{
	// mock store - will later implement some form of persistence (JSON maybe)
	private Dictionary<Vector2Int, CompleteChunk> chunkStore = new Dictionary<Vector2Int, CompleteChunk>();

	public void PushChunkToStore(CompleteChunk chunk)
	{
		if (chunk.Status == ChunkGenerationStatus.Done)
		{
			chunkStore[chunk.Location] = chunk;
		}
	}

	public Chunk GetChunkAt(Vector2Int location)
	{
		return chunkStore[location];
	}

	public void ClearStore()
	{
		chunkStore = new Dictionary<Vector2Int, CompleteChunk>();
	}
}
