using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcastner.Models
{
    public class SavedWord
    {
        public int Id { get; set; }
        public string Word { get; set; } = "";
        public string? Phonetic { get; set; }
        public string PartOfSpeech { get; set; } = "";
        public string Definition { get; set; } = "";
        public string? Example { get; set; }
        public string? Examples
        {
            get; set;
        }
    }
}
