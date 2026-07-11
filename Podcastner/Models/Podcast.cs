using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podcastner.Models
{
    public class Podcast
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public string AudioPath { get; set; }
    }
}
