using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string[] genres, int[] plays) {
        List<int> result = new List<int>();
        Dictionary<string, int> genreDict = new Dictionary<string, int>();
        Dictionary<string, Dictionary<int, int>> playDict = new Dictionary<string, Dictionary<int, int>>();

        var count = genres.Length;
        for (int i = 0; i < count; i++)
        {
            if (!genreDict.ContainsKey(genres[i]))
            {
                genreDict.Add(genres[i], plays[i]);
                playDict.Add(genres[i], new Dictionary<int, int>());
            }
            else
            {
                genreDict[genres[i]] += plays[i];
            }
            playDict[genres[i]].Add(i, plays[i]);
        }

        foreach (var genreKvp in genreDict.OrderByDescending(x => x.Value))
        {
            string genreName = genreKvp.Key;

            var topSongs = playDict[genreName]
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Take(2);

            foreach (var song in topSongs)
            {
                result.Add(song.Key);
            }
        }

        return result.ToArray();
    }
}