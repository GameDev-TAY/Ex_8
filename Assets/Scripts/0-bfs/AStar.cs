using System.Collections.Generic;

/**
 * A generic implementation of the BFS algorithm.
 * @author Erel Segal-Halevi
 * @since 2020-02
 */
public class AStar {

    public static void FindPath<Vector3Int>(
            IGraph<Vector3Int> graph, 
            Vector3Int startNode, Vector3Int endNode, 
            List<Vector3Int> outputPath, int maxiterations=1000)
    {
        






        /**
         * **/
        Queue<Vector3Int> openQueue = new Queue<Vector3Int>();
        HashSet<Vector3Int> closedSet = new HashSet<Vector3Int>();
        Dictionary<Vector3Int, Vector3Int> previous = new Dictionary<Vector3Int, Vector3Int>();
        openQueue.Enqueue(startNode);
        int i; for (i = 0; i < maxiterations; ++i) { // After maxiterations, stop and return an empty path
            if (openQueue.Count == 0) {
                break;
            } else {
                Vector3Int searchFocus = openQueue.Dequeue();

                if (searchFocus.Equals(endNode)) {
                    // We found the target -- now construct the path:
                    outputPath.Add(endNode);
                    while (previous.ContainsKey(searchFocus)) {
                        searchFocus = previous[searchFocus];
                        outputPath.Add(searchFocus);
                    }
                    outputPath.Reverse();
                    break;
                } else {
                    // We did not found the target yet -- develop new nodes.
                    foreach (var neighbor in graph.Neighbors(searchFocus)) {
                        if (closedSet.Contains(neighbor)) {
                            continue;
                        }
                        openQueue.Enqueue(neighbor);
                        previous[neighbor] = searchFocus;
                    }
                    closedSet.Add(searchFocus);
                }
            }
        }
        /**
        **/
    }

    public static List<NodeType> GetPath<NodeType>(IGraph<NodeType> graph, NodeType startNode, NodeType endNode, int maxiterations=1000) {
        List<NodeType> path = new List<NodeType>();
        FindPath(graph, startNode, endNode, path, maxiterations);
        return path;
    }

}