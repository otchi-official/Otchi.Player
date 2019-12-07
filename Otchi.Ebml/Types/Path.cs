using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Otchi.Ebml.Types
{
    public class Path
    {
        private readonly string _fullPath;
        public int? MinOccurrence { get; }
        public int? MaxOccurrence { get; }
        public List<string> ParentPaths { get; }
        public string? ParentPath => ParentPaths.AsEnumerable().Reverse().Skip(1).FirstOrDefault();

        public Path(string fullPath)
        {
            _fullPath = fullPath ?? throw new ArgumentNullException(nameof(fullPath));

            var counter = 0;
            MinOccurrence = ParseMinOccurrence(ref counter);
            // Skip '*'
            counter++;
            MaxOccurrence = ParseMaxOccurrence(ref counter);

            var startMaster = fullPath.IndexOf("(", StringComparison.InvariantCulture);
            var endMaster = fullPath.IndexOf(")", StringComparison.InvariantCulture);
            var paths = fullPath.Substring(startMaster, endMaster - startMaster);
            ParentPaths = paths.Split("\\").ToList()
                .Select(x => 
                    x.Contains("(", StringComparison.InvariantCulture)
                        ? x.Substring(0, x.IndexOf('(', StringComparison.InvariantCulture))
                        : x)
                .ToList();
        }

        private int? ParseMinOccurrence(ref int counter)
        {
            if (_fullPath[counter] == '*')
            {
                return null;
            }
            var i = int.Parse(_fullPath.Substring(counter, 1), NumberStyles.Any, CultureInfo.InvariantCulture);
            counter++;
            return i;
        }

        private int? ParseMaxOccurrence(ref int counter)
        {
            if (_fullPath[counter] == '(')
                return null;

            var i = int.Parse(_fullPath.Substring(counter, 1), NumberStyles.Any, CultureInfo.InvariantCulture);
            counter++;
            return i;
        }

        public static Path FromString(string instance)
        {
            return new Path(instance);
        }

        public static string ToString(Path instance)
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            return instance._fullPath;
        }

        public static implicit operator Path(string instance)
        {
            return FromString(instance);
        }

        public static implicit operator string(Path instance)
        {
            return ToString(instance);
        }
    }
}