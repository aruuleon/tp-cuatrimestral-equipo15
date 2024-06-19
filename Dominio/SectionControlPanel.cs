using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio {
    public class SectionControlPanel {
        public string Name { get; set; }
        public string WebForm { get; set; }
        public string Icon { get; set; }
        public SectionControlPanel(string name, string webForm, string icon) {
            Name = name;
            WebForm = webForm;
            Icon = icon;
        }
    }
}
