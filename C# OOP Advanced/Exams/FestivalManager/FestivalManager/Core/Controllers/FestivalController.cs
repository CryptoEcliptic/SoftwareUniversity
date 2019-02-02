namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private readonly IStage stage;
        private SetFactory setFactory;
        private InstrumentFactory instrumentFactory;
        private PerformerFactory performerFactory;
        private SongFactory songFactory;
        private SetController setController;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
            this.setFactory = new SetFactory();
            this.instrumentFactory = new InstrumentFactory();
            this.performerFactory = new PerformerFactory();
            this.songFactory = new SongFactory();
            this.setController = new SetController(stage);
        }


        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(set);
            return $"Registered {type} set";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);
            string[] instrumentArgs = args.Skip(2).ToArray();

            IInstrument[] instruments = instrumentArgs
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            IPerformer performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            string timeAsString = args[1];
            TimeSpan duration = TimeSpan.ParseExact(timeAsString, TimeFormat, CultureInfo.InvariantCulture); ;

            ISong song = this.songFactory.CreateSong(name, duration);
            stage.AddSong(song);

            return $"Registered song {song.ToString()}";
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            ISet set = this.stage.GetSet(setName);
            ISong song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song.ToString()} to {set.Name}";
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);
            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        public string ProduceReport()
        {
            
            //--Set1 (15:00):
            //---Gosho(Microphone[80 %])
            //---Pesho(Guitar[60 %])
            //--Songs played:
            //----Song1 (05:00)
            //----Song2 (05:00)
            //----Song3 (05:00)
            //--Set2 (00:00):
            //---Ivan (Drums[100 %])
            //--No songs played
            //--Set3 (00:00):
            //--No songs played

            StringBuilder result = new StringBuilder();

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            result.AppendLine("Results:");
            result.AppendLine($"Festival length: {FormatTime(totalFestivalLength)}");

            foreach (var set in this.stage.Sets)
            {
                result.AppendLine($"--{set.Name} ({FormatTime(set.ActualDuration)}):");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                    result.AppendLine("--No songs played");
                else
                {
                    result.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        result.AppendLine($"----{song.ToString()}");
                    }
                }
            }

            return result.ToString();
        }

        private string FormatTime(TimeSpan timeSpan)
        {
            var formatted = string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
            return formatted;
        }

    }
}