// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {
        private IStage stage;
        private ISetController setController;
        private IPerformer performer;
        private IInstrument instrument;
        private ISet set;

        [SetUp]
        public void Setup()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
            this.performer = new Performer("Gosho", 55);
            this.instrument = new Guitar();
            this.set = new Short("Mile Kitic");
        }

        [Test]
        public void SetNotPerformWithoutPerformer()
        {
            TimeSpan duration = new TimeSpan(00, 05, 00);
            ISong song1 = new Song("Ovca", duration);
            this.set.AddSong(song1);
            this.stage.AddSet(set);

            string actualResult = this.setController.PerformSets();
            string expectedResult = "1. Mile Kitic:\r\n-- Did not perform";

            Assert.AreEqual(expectedResult, actualResult);
		}

        [Test]
        public void SetNotPerformedWithoutSong()
        {
            this.set.AddPerformer(this.performer);
            this.stage.AddSet(set);

            string actualResult = this.setController.PerformSets();
            string expectedResult = "1. Mile Kitic:\r\n-- Did not perform";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void SetDidNorPerformedIfInstrumentsAreBroken()
        {
            this.instrument.WearDown();
            this.instrument.WearDown();
            this.performer.AddInstrument(this.instrument);

            this.stage.AddSet(this.set);
            string actualResult = this.setController.PerformSets();
            string expectedResult = "1. Mile Kitic:\r\n-- Did not perform";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ShouldThrowExceptionIfSongIsOverTheLimit()
        {
            TimeSpan duration = new TimeSpan(00, 55, 00);
            ISong song1 = new Song("Ovca", duration);
    
            this.stage.AddSet(this.set);

            Assert.Throws<InvalidOperationException>(() => set.AddSong(song1));
        }

        [Test]
        public void TestIfInstrumentsWearDown()
        {
            this.performer.AddInstrument(this.instrument);
            this.set.AddPerformer(this.performer);

            TimeSpan duration = new TimeSpan(00, 05, 00);
            ISong song1 = new Song("Ovca", duration);
            this.set.AddSong(song1);

            this.stage.AddSet(this.set);
            this.setController.PerformSets();
            double actualInstrumentHealth = this.instrument.Wear;
            double expectedInstrumentHealth = 40;

            Assert.AreEqual(expectedInstrumentHealth, actualInstrumentHealth);
 
        }

        [Test]
        public void SuccessfulPerformed()
        {
            this.performer.AddInstrument(this.instrument);
            this.set.AddPerformer(performer);

            TimeSpan duration = new TimeSpan(00, 05, 00);
            ISong song1 = new Song("Ovca", duration);
            this.set.AddSong(song1);

            this.stage.AddSet(this.set);

            string actualResult = this.setController.PerformSets();
            string expectedResult = "1. Mile Kitic:\r\n-- 1. Ovca (05:00)\r\n-- Set Successful";

            Assert.AreEqual(expectedResult, actualResult);

        }
	}
}