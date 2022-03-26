using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestioneFileAvanzata.BaseDati
{
    public class NFile
    {
        public static implicit operator NFile(string path)
        {
            return new NFile() { Percorso = path };
        }
        /// <summary>
        /// Effettivo percorso
        /// </summary>
        public string Percorso { get; set; }
        /// <summary>
        /// Valori Semantici
        /// </summary>
        [JsonIgnore]
        public List<string> tag
        {
            get
            {
                var ret = new List<string>();
                ret.AddRange(Path.GetFileNameWithoutExtension(Percorso).Split(" "));
                ret.AddRange(Contenitori);

                return ret;
            }
        }

        /// <summary>
        /// Logicmanerte dove trovare i file
        /// </summary>
        public List<string> Contenitori { get; set; }

        public bool Valid(List<string> parole)
        {
            if (parole == null)
                return false;
            var ret = false;

            parole.ForEach(x =>
                {
                    if (tag.Contains(x.ToString()))
                        ret = true;
                });
            return ret;
        }
    }

    public class NFiles : List<NFile>
    {
        public NFiles()
        {
        }
        public NFiles(List<NFile> vals)
        {
            AddRange(vals);
        }

        public void Salva()
        {
            DB.Salva(this);
        }
    }

    public static class DB
    {

        public static string BASE { get; set; }

        public static NFiles NFiles
        {
            get
            {
                var ret = new NFiles();
                if (File.Exists(BASE))
                {
                    string jsonString = File.ReadAllText(BASE);
                    NFiles res = JsonSerializer.Deserialize<NFiles>(jsonString)!;
                    if (res != null)
                        ret = res;
                }
                return ret;
            }
        }

        public static Dictionary<string,NFiles> Divisi
        {
            get {
                var ret = new Dictionary<string,NFiles>();

                var chiavi = new List<string>();
                NFiles.ForEach(x => chiavi.AddRange(x.Contenitori));
                chiavi = chiavi.Distinct().ToList();

                foreach (var k in chiavi)
                {
                    ret[k] = new NFiles(NFiles.Where(x => x.Contenitori.Contains(k)).ToList());
                }
                return ret;
            }
        }

        internal static void Salva(NFiles valori)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            File.WriteAllText(BASE, JsonSerializer.Serialize<NFiles>(valori, options));
        }

    }

}