var springRecords = File.ReadLines("example.txt")
                        .Select(SpringRecord.Parse)
                        .ToList();