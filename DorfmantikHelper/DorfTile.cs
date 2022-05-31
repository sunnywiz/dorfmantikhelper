using System;

namespace DorfmantikHelper
{
    public partial class MainWindow
    {
        public class DorfTile
        {
            public DorfTile(string line)
            {
                if (line == null) throw new ArgumentNullException(nameof(line));
                if (line.Length < 6) line = line.PadRight(6, '.');
                var firstSix = line.Substring(0, 6);
                var remaining = line.Substring(6);
                Definition = firstSix;
                Description = remaining; 
            }
            public string Definition { get; set; }
            public string Description { get; set; }

            private static string Permute(string definition)
            {
                return definition.Substring(0,1) + definition.Substring(1);
            }

            public bool Match(DorfTile tile2)
            {
                var def1 = Definition;
                var def2 = tile2.Definition; 
                for (int i=0; i<6; i++)
                {
                    if (Match(def1, def2)) return true;
                    def1 = Permute(def1); 
                }
                return false;
            }

            private static bool Match(string def1, string def2)
            {
                for (int pos = 0; pos< def1.Length; pos++)
                {
                    var ch1 = def1[pos];
                    var ch2 = def2[pos];
                    // either side blank matches
                    if (ch1 == '.' || ch2 == '.') continue;
                    if (ch1 == ch2) continue;
                    // two types of water match
                    if ((ch1 == 'r' && ch2 == 'L') || (ch1 == 'L' && ch2 == 'r')) continue;
                    if ((ch1 == 'L' && ch2 == 'p') || (ch1 == 'p' && ch2 == 'L')) continue;
                    return false;
                }
                return true; 
            }
        }
    }
}
