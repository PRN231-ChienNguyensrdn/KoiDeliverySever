using System;
using System.Collections.Generic;

namespace KoiDeliv.DataAccess.Models
{
    public partial class Gsp
    {
        public long Id { get; set; }
        public int Index { get; set; }
        public string VehicleId { get; set; } = null!;
        public string PStart { get; set; } = null!;
        public string PTerm { get; set; } = null!;
        public string PEnd { get; set; } = null!;
        public string PreRouted { get; set; } = null!;
        public int Freg { get; set; }
        public bool Label { get; set; }
        public string Regions { get; set; } = null!;
    }
}
