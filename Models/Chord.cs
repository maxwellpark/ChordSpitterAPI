using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ChordSpitterAPI.Models
{
    public class Chord
    {
        [Key]
        public long Id { get; set; }

        public string RootNote { get; set; }
        public string Quality { get; set; }
        public string Extension { get; set; }
        public string AlteredNote { get; set; }
        public string NonRootBassNote { get; set; }

        //public string IntegerNotation { get; set; }
    }
}
