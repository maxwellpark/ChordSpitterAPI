using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChordSpitterAPI.Models
{
    public class ChordContext : DbContext
    {
        public ChordContext(DbContextOptions<ChordContext> options) : base(options)
        {
            LoadChords(); 
        }

        public void LoadChords()
        {
            Chord chord = new Chord() { RootNote = "C", Quality = "Major", Extension = "7" };
            Chords.Add(chord); 
            chord = new Chord() { RootNote = "A", Quality = "Minor", Extension = "6" };
            Chords.Add(chord);
        }

        public DbSet<Chord> Chords { get; set; }
        public List<Chord> GetChords() => Chords.Local.ToList();
        // add more CRUD fns: getById, addChord, editChord, etc. 
    }
}
