using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDB_backend.Models
{
    public abstract class Entry
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public float MyRating { get; private set; }
        public DateTime ReleaseData { get; private set; }
        public string Description { get; private set; }

        protected Entry(int id, string title, float myRating, DateTime releaseData, string description)
        {
            Id = id;
            Title = title;
            MyRating = myRating;
            ReleaseData = releaseData;
            Description = description;
        }
    }
}
