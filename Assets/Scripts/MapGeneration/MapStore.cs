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

	public void PushCompleteChunks(List<Chunk> chunks)
	{
		foreach (var chunk in chunks)
		{
			if (chunk.Status == ChunkGenerationStatus.Done)
			{
				this.PushChunkToStore((CompleteChunk)chunk);
			}
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
