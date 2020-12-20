using System.Collections.Generic;

public class AStar {

    public static void FindPath<NodeType>(
            IWeightedGraph<NodeType> graph,
            NodeType startNode, NodeType endNode, 
            List<NodeType> outputPath, int maxiterations=1000)
    {
        Dictionary<NodeType, NodeType> cameFrom = new Dictionary<NodeType, NodeType>();
        Dictionary<NodeType, float> costSoFar = new Dictionary<NodeType, float>();
        PriorityQueue<NodeType> openQueue = new PriorityQueue<NodeType>();

        openQueue.Enqueue(startNode, 0f);
        cameFrom.Add(startNode, startNode); // is set to start, None in example
        costSoFar.Add(startNode, 0f);

        while (openQueue.Count > 0)
        {
            NodeType curr = openQueue.Dequeue();
            if (curr.Equals(endNode)) break;

            foreach (var neighbor in graph.Neighbors(curr))
            {
                float newCost = costSoFar[curr] + graph.Distance(curr, neighbor);
                if (!costSoFar.ContainsKey(neighbor) || newCost < costSoFar[neighbor])
                {
                    if (costSoFar.ContainsKey(neighbor))
                    {
                        costSoFar.Remove(neighbor);
                        cameFrom.Remove(neighbor);
                    }
                    costSoFar.Add(neighbor, newCost);
                    cameFrom.Add(neighbor, curr);
                    float priority = newCost + graph.AirDistance(neighbor, endNode);
                    openQueue.Enqueue(neighbor, priority);
                }
            }
        }
        NodeType current = endNode;
        outputPath.Add(current);
        while (!current.Equals(startNode))
        {
            if (!cameFrom.ContainsKey(current))
            {
                outputPath =  new List<NodeType>();
                break;
            }
            outputPath.Add(current);
            current = cameFrom[current];
        }
        outputPath.Add(startNode);
        outputPath.Reverse();
    }

    public static List<NodeType> GetPath<NodeType>(IWeightedGraph<NodeType> graph, NodeType startNode, NodeType endNode, int maxiterations=1000) {
        List<NodeType> path = new List<NodeType>();
        FindPath(graph, startNode, endNode, path, maxiterations);
        return path;
    }

    public class PriorityQueue<T>
    {
        private List<KeyValuePair<T, float>> elements = new List<KeyValuePair<T, float>>();

        public int Count
        {
            get { return elements.Count; }
        }

        public void Enqueue(T item, float priority)
        {
            elements.Add(new KeyValuePair<T, float>(item, priority));
        }

        // Returns the Location that has the lowest priority
        public T Dequeue()
        {
            int bestIndex = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].Value < elements[bestIndex].Value)
                {
                    bestIndex = i;
                }
            }

            T bestItem = elements[bestIndex].Key;
            elements.RemoveAt(bestIndex);
            return bestItem;
        }
    }


}