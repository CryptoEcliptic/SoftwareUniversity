namespace FestivalManager.Entities
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Stage : IStage
	{
		
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();
        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();
        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(x => x.Name == name);
            return set;
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = performers.FirstOrDefault(x => x.Name == name);
            return performer;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(x => x.Name == name);

            return song;
        }

        public bool HasSet(string name) => this.sets.Any(x => x.Name == name);
        public bool HasPerformer(string name) => this.performers.Any(x => x.Name == name);
        public bool HasSong(string name) => this.songs.Any(x => x.Name == name);
	}
}
