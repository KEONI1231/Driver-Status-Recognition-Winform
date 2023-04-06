using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semi_Auto_Labeling
{
    public class Metadata
    {
        public string description { get; set; }
        public string video_id { get; set; }
        public string creator { get; set; }
        public string distributor { get; set; }
        public string date { get; set; }
    }

    public class SceneInfo
    {
        public string scene_id { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
    }

    public class OccupantInfo
    {
        public string occupant_id { get; set; }
        public string occupant_sex { get; set; }
        public string occupant_age { get; set; }
        public string occupant_posotion { get; set; }
    }

    public class Occupant
    {
        public string occupant_id { get; set; }
        public double[] body_b_box { get; set; }
        public double[] face_b_box { get; set; }
        public string action { get; set; }
        public string emotion { get; set; }
    }

    public class Data
    {
        public string img_name { get; set; }
        public List<Occupant> occupant { get; set; }
    }

    public class Sensor
    {
        public string occupant_id { get; set; }
        public List<double> ECG { get; set; }
        public List<double> PPG { get; set; }
    }

    public class Scene
    {
        public List<Data> data { get; set; }
        public List<Sensor> sensor { get; set; }
    }

    public class Root
    {
        public Metadata metadata { get; set; }
        public SceneInfo scene_info { get; set; }
        public List<OccupantInfo> occupant_info { get; set; }
        public Scene scene { get; set; }
    }

}
